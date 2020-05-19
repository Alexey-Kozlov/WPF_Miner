using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Miner.Data
{
    /// <summary>
    /// Current status of the cell
    /// </summary>
    public enum CellStatus
    {
        /// <summary>
        /// Not opened.
        /// </summary>
        Button,
        /// <summary>
        /// Opened.
        /// </summary>
        Opened,
        /// <summary>
        /// Marked with flag 
        /// </summary>
        Flagged,
        /// <summary>
        /// Under suspicion
        /// </summary>
        Question
    }
}
