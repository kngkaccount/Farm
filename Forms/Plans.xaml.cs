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
    /// Interaction logic for Plans.xaml
    /// </summary>
    public partial class Plans : Window
    {
        private DB db = new DB();
        public Plans()
        {
            InitializeComponent();

            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dataGrid.ItemsSource = null;
            List<Models.Plan> plans = db.getAllPlans();
            foreach (var plan in plans)
            {
                plan.FieldName = db.getFieldById(plan.FieldId).Name;
                plan.SeedsName = db.getSeedsById(plan.SeedsId).Name;
            }
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = plans;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private void goBack()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddPlan add = new AddPlan();
            add.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Models.Plan).Id;
                EditPlan edit = new EditPlan(id);
                edit.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите данные для редактирования!");
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Models.Plan).Id;
                DB db = new DB();
                db.deletePlan(id);
                MessageBox.Show("План посева удален!");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }
    }
}
