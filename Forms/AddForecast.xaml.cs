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
using System.Windows.Shapes;

namespace Farm.Forms
{
    /// <summary>
    /// Interaction logic for AddForecast.xaml
    /// </summary>
    public partial class AddForecast : Window
    {
        public AddForecast()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            Forecasts forecasts = new Forecasts();
            forecasts.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            string description = descriptionBox.Text;
            DateTime date = dateBox.SelectedDate.Value;

            if (description != "" && date != null)
            {
                db.addForecast(description, date);
                MessageBox.Show("Прогноз добавлен!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
