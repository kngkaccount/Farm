using Farm.FarmDataSetTableAdapters;
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
    /// Interaction logic for AddPlan.xaml
    /// </summary>
    public partial class AddPlan : Window
    {
        private DB db = new DB();
        public AddPlan()
        {
            InitializeComponent();
            FillCombos();
        }

        private void FillCombos()
        {
            List<Models.Field> fields = db.getAllFields();
            foreach(Models.Field field in fields)
            {
                fieldBox.Items.Add(field.Name);
            }
            fieldBox.SelectedIndex = 0;

            List<Models.Seeds> seeds = db.getAllSeeds();
            foreach(Models.Seeds seed in seeds)
            {
                seedsBox.Items.Add(seed.Name);
            }
            seedsBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            Plans plans = new Plans();
            plans.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int fieldId = db.getFieldByName(fieldBox.SelectedValue.ToString()).Id;
                int seedsId = db.getSeedByName(seedsBox.SelectedValue.ToString()).Id;
                int weight = Convert.ToInt32(weightBox.Text);
                DateTime date = dateBox.SelectedDate.Value;
                if (weight != 0)
                {
                    db.addPlan(fieldId, seedsId, weight, date);
                    MessageBox.Show("План успешно добавлен!");
                    goBack();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Некорректные данные!");
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dateBox.SelectedDate.HasValue)
            {
                string forecastInfo = db.getForecastByDate(dateBox.SelectedDate.Value).Description;
                if (forecastInfo == null)
                {
                    forecastBox.Text = "Нет прогноза";
                }
                else
                {
                    forecastBox.Text = forecastInfo;
                }
            }
        }
    }
}
