using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Miner.Data
{
    /// <summary>
    /// Field cell type.
    /// </summary>
    public enum CellType
    {
        /// <summary>
        /// 8 bombs around.
        /// </summary>
        Near8,

        /// <summary>
        /// 7 bombs around.
        /// </summary>
        Near7,

        /// <summary>
        /// 6 bombs around.
        /// </summary>
        Near6,

        /// <summary>
        /// 5 bombs around.
        /// </summary>
        Near5,

        /// <summary>
        /// 4 bombs around.
        /// </summary>
        Near4,

        /// <summary>
        /// 3 bombs around.
        /// </summary>
        Near3,

        /// <summary>
        /// 2 bombs around.
        /// </summary>
        Near2,

        /// <summary>
        /// 1 bombs around.
        /// </summary>
        Near1,

        /// <summary>
        /// Empty opened cell.
        /// </summary>
        Empty,

        /// <summary>
        /// Pressed cell exploded.
        /// </summary>
        BombExplode,

        /// <summary>
        /// Wrong flagged cell.
        /// </summary>
        BombError,

        /// <summary>
        /// Bomb cell.
        /// </summary>
        Bomb
    }
}
