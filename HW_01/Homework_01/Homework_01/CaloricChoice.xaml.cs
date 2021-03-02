using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Homework_01
{
    /// <summary>
    /// Логика взаимодействия для CaloricChoice.xaml
    /// </summary>
    public partial class CaloricChoice : Window
    {
        public string CaloricResult { get; set; }
        public string CaloricResultFrom { get; set; }

        public CaloricChoice()
        {
            InitializeComponent();
        }

        private void tb_caloric_TextChanged(object sender, TextChangedEventArgs e)
        {
            //e.Handled = !IsTextAllowed(e.ToString());
            CaloricResult = tb_caloric.Text;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }

        private void chk_from_Checked(object sender, RoutedEventArgs e)
        {
            tb_caloricFrom.IsEnabled = true;
        }

        private void tb_caloricFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            CaloricResultFrom = tb_caloricFrom.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(CaloricResultFrom) < Convert.ToInt32(CaloricResult))
            {
                return;
            }

            tb_caloricFrom.IsEnabled = true;
            this.Close();
        }

        private static readonly Regex onlyNumbers = new Regex("[^0-9.]+");

        private static bool IsTextAllowed(string text)
        {
            return !onlyNumbers.IsMatch(text);
        }

        private void tb_caloric_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
