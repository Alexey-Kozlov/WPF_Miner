using System;
using WPF_Miner.Data;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_Miner.Controls
{
    public class AdvancedMine:MineBase
    {
        public AdvancedMine()
        {
            this.MineType = Data.MineType.Advanced;
            this.MineImage = new Image() { Source = new BitmapImage(Utils.AdvancedBombUri) };
            this.MineImageExploded = new Image() { Source = new BitmapImage(Utils.FaceSadUri) };
            this.SoundToPlay = @"C:\Users\Admin\source\repos\WPF_Miner\Images\Alesis-Fusion-Pizzicato-Strings-C4.wav";
        }
    }
}
