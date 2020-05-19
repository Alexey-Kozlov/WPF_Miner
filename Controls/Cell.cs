﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPF_Miner.Data;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// Represents every cell on the game field.
    /// </summary>
    public class Cell : CellBase
    {        
        private CellStatus cellStatus;
        public Cell(int _columnNumber, int _rowNumber)
        {
            Width = DefaultCellSize;
            Height = DefaultCellSize;
            this.ColumnNumber = _columnNumber;
            this.RowNumber = _rowNumber;
            //By default all cells are buttons
            this.Status = CellStatus.Button;
            //Assign a mine to yhe cell
            this.Mine = new Mine();
        }

        //image size in pixels
        public override int DefaultCellSize => 16;

        public override CellStatus Status { get => cellStatus; set { cellStatus = value; ImageUpdate(); } }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        //Set proper images to different types of cells. The trigger is changing status of the cell. It happens after clicking on cell.
        private void ImageUpdate()
        {
            if (this.Status == CellStatus.Button) { this.Content = new Image() { Source = new BitmapImage(Utils.ButtonUri) }; return; }
            if (this.Status == CellStatus.Flagged) { this.Content = new Image() { Source = new BitmapImage(Utils.FlagUri) }; return; }
            if (this.Status == CellStatus.Question) { this.Content = new Image() { Source = new BitmapImage(Utils.QuestionUri) }; return; }
            if (this.Status == CellStatus.Opened)
            {
                if (this.Type == CellType.Empty) { this.Content = new Image() { Source = new BitmapImage(Utils.EmptyUri) }; return; }
                if (this.Type == CellType.Bomb) { this.Content = this.Mine.MineImage; return; }
                if (this.Type == CellType.BombExplode) { this.Content = this.Mine.MineImageExploded; return; }
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
