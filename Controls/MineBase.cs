using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Miner.Data;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// Base class for all mines
    /// </summary>
    public abstract class MineBase
    {
        //Mine type - may be it will be useful
        public MineType MineType { get; set; }
        //Image of default mine
        public Image MineImage { get; set; }
        //Image of burst mine
        public Image MineImageExploded { get; set; }
        //for the future - may play sound during the mine burst
        public string SoundToPlay { get; set; }
    }
}
