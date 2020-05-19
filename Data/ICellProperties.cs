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
        /// Cell X coordinate
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Cell Y coordinate
        /// </summary>
        int Y { get; set; }

    }
}
