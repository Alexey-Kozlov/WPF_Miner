using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Miner.Data
{
    /// <summary>
    /// Singleton - the only place for settings
    /// </summary>
    public class GameSettings
    {
        private static GameSettings uniqueInstance;
        protected GameSettings() { }

        public static GameSettings Instance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new GameSettings();
            return uniqueInstance;
        }
        /// <summary>
        /// Amount of columns in game field
        /// </summary>
        public int GameFieldSizeColumns { get; set; }
        /// <summary>
        /// Amount of rows in game field
        /// </summary>
        public int GameFiledSizeRows { get; set; }
        /// <summary>
        /// Amount of mines on the game field
        /// </summary>
        public int BombAmount { get; set; }
        /// <summary>
        /// Amount of advanced mines on the game field
        /// </summary>
        public int AdvancedBombAmount { get; set; }
    }
}
