using Farm.Models;
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
    /// Interaction logic for EditHarvest.xaml
    /// </summary>
    public partial class EditHarvest : Window
    {
        private DB db = new DB();
        private int id;
        public EditHarvest(int id)
        {
            this.id = id;
            InitializeComponent();
            List<Plan> plans = db.getAllPlans();
            Harvest harvest = db.getHarvestById(id);
            for(int i = 0; i < plans.Count; i++)
            {
                planIdBox.Items.Add(plans[i].Id);
                if (plans[i].Id == harvest.PlanId)
                {
                    planIdBox.SelectedIndex = i;
                }
            }

            weightBox.Text = harvest.Weight.ToString();
            dateBox.Text = harvest.Date.ToString();
        }

        private void goBack()
        {
            Harvests harvests = new Harvests();
            harvests.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int planId = Convert.ToInt32(planIdBox.SelectedValue);
            int planWeight = Convert.ToInt32(weightBox.Text);
            DateTime planDate = dateBox.SelectedDate.Value;
            if(planId != 0 && dateBox.SelectedDate.HasValue && planWeight != 0)
            {
                db.updateHarvest(id, planId, planWeight, planDate);
                MessageBox.Show("Данные урожая изменены!");
                goBack();
                
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
