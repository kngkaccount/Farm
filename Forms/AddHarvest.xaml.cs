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
using Farm.Models;

namespace Farm.Forms
{
    /// <summary>
    /// Interaction logic for AddHarvest.xaml
    /// </summary>
    public partial class AddHarvest : Window
    {
        private DB db = new DB();
        public AddHarvest()
        {
            InitializeComponent();
            List<Plan> plans = db.getAllPlans();
            foreach(Plan plan in plans)
            {
                planIdBox.Items.Add(plan.Id);
            }
            planIdBox.SelectedIndex = 0;
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
            DateTime date = dateBox.SelectedDate.Value;

            if (planId != 0 && planWeight != 0)
            {
                db.addHarvest(planId, planWeight, date);
                MessageBox.Show("Запись о сборе урожая добавлена!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
