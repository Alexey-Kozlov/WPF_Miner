using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Miner.Data
{
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
        public int GameFieldSizeColumns { get; set; }
        public int GameFiledSizeRows { get; set; }
        public int BombAmount { get; set; }
    }
}
