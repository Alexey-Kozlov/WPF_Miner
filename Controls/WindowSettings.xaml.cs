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

        //Check for errors
        private bool CheckEnterValues()
        {
            int _newColumns = 0;
            int _newRows = 0;
            int _newBombAmount = 0;
            //check enter columns
            if (Int32.TryParse(FieldSizeColumns.Text, out _newColumns))
            {
                if (_newColumns < 0 || _newColumns > 100)
                {
                    MessageBox.Show("Input error. Amount of columns must be between 1 and 100");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Input error. It must be a number");
                return false;
            }
            //check enter rows
            if (Int32.TryParse(FieldSizeRows.Text, out _newRows))
            {
                if (_newRows < 0 || _newRows > 100)
                {
                    MessageBox.Show("Input error. Amount of rows must be between 1 and 100");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Input error. It must be a number");
                return false;
            }
            //check enter bomb amount
            if (Int32.TryParse(BombsAmount.Text, out _newBombAmount))
            {
                if (_newBombAmount < 0 || _newBombAmount > (_newColumns * _newRows * 0.25))
                {
                    MessageBox.Show("Input error. Amount of mines must be between 1 and 25% of field cells");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Input error. It must be a number");
                return false;
            }
            this.NewColumns = _newColumns;
            this.NewRows = _newRows;
            this.NewBombAmount = _newBombAmount;
            return true;
        }
    }
}
