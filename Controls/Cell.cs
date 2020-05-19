using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPF_Miner.Data;

namespace WPF_Miner.Controls
{
    public class Cell : ContentControl, ICellProperties
    {
        private const int DefaultCellSize = 16;
        private CellStatus cellStatus;
        public int X { get; set;}
        public int Y { get; set; }
        public CellStatus Status { get => cellStatus; set { cellStatus = value; ImageUpdate(); } }
        public CellType Type { get; set; }

        public Cell(int _x, int _y)
        {
            Width = DefaultCellSize;
            Height = DefaultCellSize;
            this.X = _x;
            this.Y = _y;
            this.Status = CellStatus.Button;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        private void ImageUpdate()
        {
            if (this.Status == CellStatus.Button) { this.Content = new Image() { Source = new BitmapImage(Utils.ButtonUri) }; return; }
            if (this.Status == CellStatus.Flagged) { this.Content = new Image() { Source = new BitmapImage(Utils.FlagUri) }; return; }
            if (this.Status == CellStatus.Question) { this.Content = new Image() { Source = new BitmapImage(Utils.QuestionUri) }; return; }
            if (this.Status == CellStatus.Opened)
            {
                if (this.Type == CellType.Empty) { this.Content = new Image() { Source = new BitmapImage(Utils.EmptyUri) }; return; }
                if (this.Type == CellType.Bomb) { this.Content = new Image() { Source = new BitmapImage(Utils.BombUri) }; return; }
                if (this.Type == CellType.BombExplode) { this.Content = new Image() { Source = new BitmapImage(Utils.BombExplodeUri) }; return; }
                if (this.Type == CellType.BombError) { this.Content = new Image() { Source = new BitmapImage(Utils.BombErrorUri) }; return; }
                if (this.Type == CellType.Near1) { this.Content = new Image() { Source = new BitmapImage(Utils.B1Uri) }; return; }
                if (this.Type == CellType.Near2) { this.Content = new Image() { Source = new BitmapImage(Utils.B2Uri) }; return; }
                if (this.Type == CellType.Near3) { this.Content = new Image() { Source = new BitmapImage(Utils.B3Uri) }; return; }
                if (this.Type == CellType.Near4) { this.Content = new Image() { Source = new BitmapImage(Utils.B4Uri) }; return; }
                if (this.Type == CellType.Near5) { this.Content = new Image() { Source = new BitmapImage(Utils.B5Uri) }; return; }
                if (this.Type == CellType.Near6) { this.Content = new Image() { Source = new BitmapImage(Utils.B6Uri) }; return; }
                if (this.Type == CellType.Near7) { this.Content = new Image() { Source = new BitmapImage(Utils.B7Uri) }; return; }
                if (this.Type == CellType.Near8) { this.Content = new Image() { Source = new BitmapImage(Utils.B8Uri) }; return; }
            }
        }

    }
}
