using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Farm.Models;

using DataGridCell = System.Windows.Controls.DataGridCell;

namespace Farm.Forms
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    public partial class Field : Window
    {
        private DB db = new DB();
        public Field()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dataGrid.ItemsSource = null;
            List<Models.Field> fields = db.getAllFields();

            dataGrid.Items.Clear();
            dataGrid.ItemsSource = fields;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddField add = new AddField();
            add.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if(selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Models.Field).Id;
                EditField edit = new EditField(id);
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
                int id = (selectedItem as Models.Field).Id;
                DB db = new DB();
                db.deleteField(id);
                MessageBox.Show("Поле удалено!");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }
    }
}
