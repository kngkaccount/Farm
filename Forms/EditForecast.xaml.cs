using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Farm.Forms
{
    /// <summary>
    /// Interaction logic for EditForecast.xaml
    /// </summary>
    public partial class EditForecast : Window
    {
        private int id;
        private DB db = new DB();
        public EditForecast(int id)
        {
            this.id = id;

            InitializeComponent();
            Models.Forecast oldForecast = db.getForecastById(id);
            descriptionBox.Text = oldForecast.Description;
            dateBox.SelectedDate = oldForecast.Date;
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
            string forecastDescription = descriptionBox.Text;
            DateTime forecastDate = dateBox.SelectedDate.Value;

            if (forecastDescription != "" && forecastDate != null)
            {
                db.updateForecast(id, forecastDescription, forecastDate);
                MessageBox.Show("Данные успешно изменены!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
