using System;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Miner.Data;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// The main game field. It contains all the cells.
    /// </summary>
    public class MineField: Grid
    {
        //By default - it is square 8x8 with 10 mines
        public int DefaultXSize = 8;
        public int DefaultYSize = 8;
        public int DefaultBombsAmount = 10;
        private Cell[,] Cells;
        private Image Face;
        private TextBlock BombsLeft;
        //Initialize current settings of the game
        private GameSettings gameSettings = GameSettings.Instance();
        private System.Threading.Timer Timer;
        private AutoResetEvent autoEvent = new AutoResetEvent(false);
        private int SecondsPast = 0;

        //Mouse events
        private DelegateCommand LeftButtonClickCommand { get; }
        private DelegateCommand RightButtonClickCommand { get; }

        public GameSettings FieldGameSettings { get => gameSettings; set { gameSettings = value; } }

        public MineField()
        {
            LeftButtonClickCommand = new DelegateCommand(LeftButtonClick);
            RightButtonClickCommand = new DelegateCommand(RightButtonClick);
            Face = (Image)Application.Current.MainWindow.FindName("Face");
            BombsLeft = (TextBlock)Application.Current.MainWindow.FindName("BombsLeft");
            if(gameSettings.BombAmount == 0) gameSettings.BombAmount = DefaultBombsAmount;
            if (gameSettings.GameFieldSizeColumns == 0) gameSettings.GameFieldSizeColumns = DefaultXSize;
            if (gameSettings.GameFiledSizeRows == 0) gameSettings.GameFiledSizeRows = DefaultYSize;
            //Create timer for future work
            Timer = new Timer(TimerTick, autoEvent, 0, 1000);
            CreateNewField();
        }

        public void StartNewGame()
        {
            CreateNewField();
        }

        //Create new mine field.
        private void CreateNewField()
        {            
            ClearData();
            Cells = new Cell[FieldGameSettings.GameFieldSizeColumns, FieldGameSettings.GameFiledSizeRows];
            //Create rows and columns of the grid
            for (int i = 0; i < FieldGameSettings.GameFieldSizeColumns; i++)
            {
                RowDefinition definition = new RowDefinition() { Height = GridLength.Auto };
                RowDefinitions.Add(definition);
            }
            for (int j = 0; j < FieldGameSettings.GameFiledSizeRows; j++)
            {
                var definition = new ColumnDefinition() { Width = GridLength.Auto };
                ColumnDefinitions.Add(definition);
            }

            //Creating new randomize map of mines
            bool[,] bombMap = Calculations.GenerateMineField(FieldGameSettings.GameFieldSizeColumns, FieldGameSettings.GameFiledSizeRows, FieldGameSettings.BombAmount);

            //Creating all field cells
            for (int i = 0; i < FieldGameSettings.GameFieldSizeColumns; i++)
            {
                for (int j = 0; j < FieldGameSettings.GameFiledSizeRows; j++)
                {
                    Cell cell = new Cell(i,j);
                    AttachEvents(cell);
                    //Set proper type to every cell
                    Calculations.SetCellType(bombMap, cell);
                    //Add cell to the grid
                    Children.Add(cell);
                    SetColumn(cell, j);
                    SetRow(cell, i);
                    Cells[i, j] = cell;
                }
            }
            //Default settings for face-image and Counter of bombs
            Face.Source = new BitmapImage(Utils.FaceUri);
            BombsLeft.Text = FieldGameSettings.BombAmount.ToString();
            SecondsPast = 0;
        }

        private void ClearData()
        {
            //Clear all previous data (if it is)
            RowDefinitions.Clear();
            ColumnDefinitions.Clear();
            if (Cells != null)
            {
                Utils.ForEach(Cells, RemoveLogicalChild);
                Utils.ForEach(Cells, cell =>
                {
                    RemoveLogicalChild(cell);
                    cell.InputBindings.Clear();
                });
            }
            Cells = null;
        }

        //Initialize mouse events - by using custom command
        public void AttachEvents(Cell _cell)
        {
            _cell.InputBindings.Add(new InputBinding(LeftButtonClickCommand, new MouseGesture(MouseAction.LeftClick))
            {
                CommandParameter = _cell
            });
            _cell.InputBindings.Add(new InputBinding(RightButtonClickCommand, new MouseGesture(MouseAction.RightClick))
            {
                CommandParameter = _cell
            }); 
        }

        //Right button mouse clicked - in common, to set flag
        private void RightButtonClick(object parameter)
        {
            Cell cell = (Cell)parameter;
            if (cell.Status == CellStatus.Button)
            {
                cell.Status = CellStatus.Flagged;
                int _bombsLeft = Int32.Parse(BombsLeft.Text);
                _bombsLeft--;
                BombsLeft.Text = _bombsLeft.ToString();
                return;
            }
            if (cell.Status == CellStatus.Flagged)
            {
                cell.Status = CellStatus.Question;
                return;
            }
            if (cell.Status == CellStatus.Question)
            {
                cell.Status = CellStatus.Button;
                int _bombsLeft = Int32.Parse(BombsLeft.Text);
                _bombsLeft++;
                BombsLeft.Text = _bombsLeft.ToString();
                return;
            }
        }

        //Left button mouse clicked - main using for opening the cell
        private void LeftButtonClick(object parameter)
        {

            Cell cell = (Cell)parameter;
            if (cell.Status == CellStatus.Opened) return;

            //Burst!
            if (cell.Type == CellType.Bomb)
            {
                Burst();
                return;
            }

            //Clicked empty cell. Open all nearest empty cells
            if (cell.Type == CellType.Empty)
                Calculations.MakeAllEmptyCellAroundOpened(Cells, cell);
            cell.Status = CellStatus.Opened;

            //how many cells are opened already
            int _cellsOpenedAmount = 0;
            Utils.ForEach(Cells, _cell =>
            {
                if (_cell.Status == CellStatus.Opened) _cellsOpenedAmount++;
            });

            //check - if game over
            if (_cellsOpenedAmount == FieldGameSettings.GameFieldSizeColumns * FieldGameSettings.GameFiledSizeRows - FieldGameSettings.BombAmount)
            {
                //Game successfully over!
                //Show all bombs
                Utils.ForEach(Cells, _cell =>
                {
                    if (_cell.Type == CellType.Bomb)
                    {
                        _cell.Status = CellStatus.Opened;
                    }
                });
                Face.Source = new BitmapImage(Utils.FaceSmileUri);
                BombsLeft.Text = "0";
                MessageBox.Show("You win! Game over.");
            }
        }

        private void Burst()
        {
            //Make all bombs exploded and open all cells
            Utils.ForEach(Cells, cell =>
             {
                 if (cell.Type == CellType.Bomb)
                 {
                     cell.Type = CellType.BombExplode;
                 }
                 else
                 {
                     if (cell.Status == CellStatus.Flagged)
                     {
                         if (cell.Type != CellType.Bomb)
                         {
                             cell.Type = CellType.BombError;
                         }
                     }
                 }
                 cell.Status = CellStatus.Opened;
                 Face.Source = new BitmapImage(Utils.FaceSadUri);
             });
            MessageBox.Show("You have lost... Try another time!");
        }      
        
        private void TimerTick(Object stateInfo)
        {
            //For the future - seconds counter.
            SecondsPast++;
        }
    }


}
