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
    /// Interaction logic for Harvests.xaml
    /// </summary>
    public partial class Harvests : Window
    {
        private DB db = new DB();
        public Harvests()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        private void goBack() {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void LoadDataGrid()
        {
            dataGrid.ItemsSource = null;
            List<Models.Harvest> harvests = db.getAllHarvests();

            dataGrid.Items.Clear();
            dataGrid.ItemsSource = harvests;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddHarvest add = new AddHarvest();
            add.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Models.Harvest).Id;
                EditHarvest edit = new EditHarvest(id);
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
                int id = (selectedItem as Models.Harvest).Id;
                DB db = new DB();
                db.deleteHarvest(id);
                MessageBox.Show("Запись об урожае удалена!");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }
    }
}
