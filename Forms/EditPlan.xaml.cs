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
    /// Interaction logic for EditPlan.xaml
    /// </summary>
    public partial class EditPlan : Window
    {
        private int id;
        private DB db = new DB();
        public EditPlan(int id)
        {
            this.id = id;
            InitializeComponent();
            Models.Plan oldPlan = db.getPlanById(id);
            FillCombos(oldPlan);
        }

        private void FillCombos(Models.Plan oldPlan)
        {
            List<Models.Field> fields = db.getAllFields();
            for(int i = 0; i < fields.Count; i++) 
            {
                fieldBox.Items.Add(fields[i].Name);
                if (fields[i].Id == oldPlan.FieldId)
                {
                    fieldBox.SelectedIndex = i;
                }
            }

            List<Models.Seeds> seeds = db.getAllSeeds();
            for(int i = 0; i < seeds.Count; i++)
            {
                seedsBox.Items.Add(seeds[i].Name);
                if (seeds[i].Id == oldPlan.SeedsId)
                {
                    seedsBox.SelectedIndex = i;
                }
            }

            weightBox.Text = oldPlan.Weight.ToString();
            dateBox.SelectedDate = oldPlan.Date;
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
            int fieldId = db.getFieldByName(fieldBox.SelectedValue.ToString()).Id;
            int seedsId = db.getSeedByName(seedsBox.SelectedValue.ToString()).Id;
            int weight = Convert.ToInt32(weightBox.Text);
            DateTime date = dateBox.SelectedDate.Value;
            if (weight != 0)
            {
                db.updatePlan(id, fieldId, seedsId, weight, date);
                MessageBox.Show("План изменен!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }

        private void dateBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
