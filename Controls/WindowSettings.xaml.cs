using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Miner.Controls
{
    /// <summary>
    /// Логика взаимодействия для WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        private MineField field;
        public int NewColumns { get; set; }
        public int NewRows { get; set; }
        public int NewBombAmount { get; set; }
        public WindowSettings()
        {
            field = (MineField)Application.Current.MainWindow.FindName("MineField");
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEnterValues())
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FieldSizeColumns.Text = field.FieldGameSettings.GameFieldSizeColumns.ToString();
            FieldSizeRows.Text = field.FieldGameSettings.GameFiledSizeRows.ToString();
            BombsAmount.Text = field.FieldGameSettings.BombAmount.ToString();
        }

        private bool CheckEnterValues()
        {
            int newColumns = 0;
            int newRows = 0;
            int newBombAmount = 0;
            //check enter columns
            if (Int32.TryParse(FieldSizeColumns.Text, out newColumns))
            {
                if (newColumns < 0 || newColumns > 100)
                {
                    MessageBox.Show("Input error. Amount of columns must be between 1 and 100");
                    return false;
                }
            }
            //check enter rows
            if (Int32.TryParse(FieldSizeRows.Text, out newRows))
            {
                if (newRows < 0 || newRows > 100)
                {
                    MessageBox.Show("Input error. Amount of rows must be between 1 and 100");
                    return false;
                }
            }
            //check enter bomb amount
            if (Int32.TryParse(FieldSizeColumns.Text, out newBombAmount))
            {
                if (newBombAmount < 0 || newBombAmount > (newColumns * newRows * 0.25))
                {
                    MessageBox.Show("Input error. Amount of mines must be between 1 and 25% of field cells");
                    return false;
                }
            }
            this.NewColumns = newColumns;
            this.NewRows = newRows;
            this.NewBombAmount = newBombAmount;
            return true;
        }
    }
}
