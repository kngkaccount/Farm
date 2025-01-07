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
    /// Interaction logic for Seeds.xaml
    /// </summary>
    public partial class Seeds : Window
    {
        private DB db = new DB();
        public Seeds()
        {
            InitializeComponent();

            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dataGrid.ItemsSource = null;
            List<Models.Seeds> seeds = db.getAllSeeds();
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = seeds;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddSeeds add = new AddSeeds();
            add.Show(); 
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Models.Seeds).Id;
                EditSeeds edit = new EditSeeds(id);
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
                int id = (selectedItem as Models.Seeds).Id;
                DB db = new DB();
                db.deleteSeeds(id);
                MessageBox.Show("Запись удалена!");

                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }

        private void goBack()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }
    }
}
