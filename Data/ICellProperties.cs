using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Miner.Data
{
    public interface ICellProperties
    {

        /// <summary>
        /// Cell X coordinate - column number
        /// </summary>
        int ColumnNumber { get; set; }

        /// <summary>
        /// Cell Y coordinate - row number
        /// </summary>
        int RowNumber { get; set; }

    }
}
