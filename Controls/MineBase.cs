using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using WPF_Miner.Data;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// Base class for all mines
    /// </summary>
    public abstract class MineBase
    {
        public MineBase()
        {
            this.MineType = MineType.Ordinary;
            this.MineImage = new Image() { Source = new BitmapImage(Utils.BombUri) };
            this.MineImageExploded = new Image() { Source = new BitmapImage(Utils.BombExplodeUri) };
        }

        //Mine type - may be it will be useful
        public MineType MineType { get; set; }
        public Image MineImage { get; set; }
        public Image MineImageExploded { get; set; }
        //for the future - may play sound during the mine burst
        public string SoundToPlay { get; set; }
    }
}
