using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WPF_Miner.Data;
using WPF_Miner.Controls;

namespace WPF_Miner
{
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Click menu item for starting new game
        private void MenuNewGame_Click(object sender, RoutedEventArgs e)
        {
            MineField field = (MineField)Application.Current.MainWindow.FindName("MineField");
            field.StartNewGame();
        }

        //Click menu item for opening settings window
        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            WindowSettings windowSettings = new WindowSettings();
            bool? rezult = windowSettings.ShowDialog();
            if (rezult.HasValue && rezult.Value)
            {
                MessageBox.Show("New settings saved.");
                MineField field = (MineField)Application.Current.MainWindow.FindName("MineField");
                GameSettings settings = field.FieldGameSettings;
                settings.BombAmount = windowSettings.NewBombAmount;
                settings.GameFieldSizeColumns = windowSettings.NewColumns;
                settings.GameFiledSizeRows = windowSettings.NewRows;
                field.StartNewGame();
            }            
        }

    }
}
