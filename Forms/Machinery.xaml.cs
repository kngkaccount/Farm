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
    /// Interaction logic for Machinery.xaml
    /// </summary>
    public partial class Machinery : Window
    {
        private DB db = new DB();
        public Machinery()
        {
            InitializeComponent();

            LoadDataGrid();

           
        }

        private void LoadDataGrid()
        {
            dataGrid.ItemsSource = null;
            List<Models.Machinery> machineries = db.getAllMachinery();
            foreach (var machine in machineries)
            { 
                machine.FieldName = db.getFieldById(machine.FieldId).Name;
            }
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = machineries;
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
            AddMachine add = new AddMachine();
            add.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Models.Machinery).Id;
                EditMachine edit = new EditMachine(id);
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
                int id = (selectedItem as Models.Machinery).Id;
                DB db = new DB();
                db.deleteMachinery(id);
                MessageBox.Show("Техника удалена!");

                LoadDataGrid();
            
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }
    }
}
