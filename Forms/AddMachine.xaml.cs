using System;
using System.Collections.Generic;
using System.Windows;
using Farm.Models;

namespace Farm.Forms
{
    /// <summary>
    /// Interaction logic for AddMachine.xaml
    /// </summary>
    public partial class AddMachine : Window
    {
        private DB db = new DB();
        public AddMachine()
        {
            InitializeComponent();
            FillCombo();
        }

        private void FillCombo()
        {
            List<Models.Field> fields = this.db.getAllFields();
            foreach(Models.Field field in fields)
            {
                fieldIdBox.Items.Add(field.Name);
            }
            fieldIdBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }
        private void goBack()
        {
;            Machinery machinery = new Machinery();
            machinery.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string machineName = nameBox.Text;
            string machineInfo = descriptionBox.Text;
            int machineField = db.getFieldByName(fieldIdBox.SelectedValue.ToString()).Id;
            if (machineName != "")
            {
                db.addMachinery(machineName, machineInfo, machineField);
                MessageBox.Show("Новая техника добавлена!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
