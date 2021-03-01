using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;


namespace Homework_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlConnection connection;
        Requests requests;

        public MainWindow()
        {
            InitializeComponent();
            requests = new Requests();

            foreach (var item in requests.GetRequestsList)
            {
                cmb_request.Items.Add(item);
            }
        }

        private void btn_connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);

                connection.Open();

                lbl_connect.Foreground = Brushes.Green;
                lbl_connect.Content = "Connected";
                cmb_request.IsEnabled = true;
                
            }
            catch (Exception ex)
            {
                lbl_connect.Foreground = Brushes.Red;
                lbl_connect.Content = "Error";
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_disconnection_Click(object sender, RoutedEventArgs e)
        {
            connection.Dispose();
            cmb_request.IsEnabled = false;
            
            lbl_connect.Foreground = Brushes.Gray;
            lbl_connect.Content = "Disconnect";
        }

        private void cmb_request_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)comboBox.SelectedItem;

            string request = selectedItem.Value;
            SqlCommand cmd;
            SqlDataReader rdr;

            if (selectedItem.Key == requests.GetRequestsList.ElementAt(8).Key)
            {
                cmd = new SqlCommand($"Select Color FROM Info_Vegetables_fruits Group by Color", connection);
                rdr = cmd.ExecuteReader();

                var colorChoice = new ColorChoice(rdr);
                colorChoice.ShowDialog();

                request = String.Format(selectedItem.Value, colorChoice.ColorResult);

                rdr.Close();
            }

            if (selectedItem.Key == requests.GetRequestsList.ElementAt(10).Key)
            {
                var caloricChoice = new CaloricChoice();
                caloricChoice.ShowDialog();

                request = String.Format(selectedItem.Value, caloricChoice.CaloricResult);
            }

            if (selectedItem.Key == requests.GetRequestsList.ElementAt(11).Key)
            {
                var caloricChoice = new CaloricChoice();
                caloricChoice.ShowDialog();

                request = String.Format(selectedItem.Value, caloricChoice.CaloricResult);
            }

            if (selectedItem.Key == requests.GetRequestsList.ElementAt(12).Key)
            {
                var caloricChoice = new CaloricChoice();
                caloricChoice.ShowDialog();

                request = String.Format(selectedItem.Value, caloricChoice.CaloricResult, caloricChoice.CaloricResultFrom);
            }


            lb_output.Items.Clear();

            cmd = new SqlCommand(request, connection);
            rdr = cmd.ExecuteReader();

            int countField = rdr.FieldCount;

            while (rdr.Read())
            {

                if (countField == 1)
                {
                    lb_output.Items.Add(rdr[0]);
                    continue;
                }

                if (countField == 2)
                {
                    lb_output.Items.Add($"{rdr[1]} - {rdr[0]}");
                    continue;
                }

                lb_output.Items.Add($"{rdr[1]} - {rdr[2]} - {rdr[3]} - {rdr[4]}");
            }

            rdr.Close();
        }
               
    }
}
