using System;
using WPF_Miner.Data;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// Represents mine
    /// </summary>
    public class Mine :MineBase
    {
        public Mine()
        {
            this.MineType = Data.MineType.Ordinary;
            this.MineImage = new Image() { Source = new BitmapImage(Utils.BombUri) };
            this.MineImageExploded = new Image() { Source = new BitmapImage(Utils.BombExplodeUri) };
        }
    }
}
