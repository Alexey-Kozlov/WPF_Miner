using System;
using System.Windows.Controls;
using WPF_Miner.Data;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// Class factory for cells
    /// </summary>
    public abstract class BaseCell : ContentControl
    {
        //Cell status, needs to override because of custom logic
        public abstract CellStatus Status { get; set; }
        public CellType Type { get; set; }
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }
        //Cell size, need to override for size can change
        public abstract int DefaultCellSize { get; }
    }
}
