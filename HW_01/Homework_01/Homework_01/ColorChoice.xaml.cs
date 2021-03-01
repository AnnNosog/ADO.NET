using System;

using System.Data.SqlClient;

using System.Windows;
using System.Windows.Controls;


namespace Homework_01
{
    /// <summary>
    /// Логика взаимодействия для ColorChoice.xaml
    /// </summary>
    public partial class ColorChoice : Window
    {
        public string ColorResult { get; set; }        

        public ColorChoice(SqlDataReader rdr)
        {
            InitializeComponent();          
           
            while (rdr.Read())
            {
                cmb_color.Items.Add(rdr[0]);
            }

            rdr.Close();
        }

        private void cmb_color_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ColorResult = (String)comboBox.SelectedItem;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
