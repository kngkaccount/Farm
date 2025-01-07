using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for EditMachine.xaml
    /// </summary>
    public partial class EditMachine : Window
    {
        private int id;
        private DB db = new DB();
        public EditMachine(int id)
        {
            this.id = id;
            InitializeComponent();
            Models.Machinery oldMachinery = db.getMachineryById(id);
            FillFields(oldMachinery);
        }

        private void FillFields(Models.Machinery oldMachinery)
        {
            nameBox.Text = oldMachinery.Name;
            descriptionBox.Text = oldMachinery.Information;
            List<Models.Field> fields = db.getAllFields();
            for (int i = 0; i < fields.Count; i++)
            {
                fieldIdBox.Items.Add(fields[i].Name);
                if (fields[i].Id == oldMachinery.FieldId)
                {
                    fieldIdBox.SelectedIndex = i;
                }
            }
        }

        private void goBack()
        {
            Machinery machinery = new Machinery();
            machinery.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string machineName = nameBox.Text.Trim();
            string machineInfo = descriptionBox.Text.Trim();
            int machineField = db.getFieldByName(fieldIdBox.SelectedValue.ToString()).Id;

            if(machineName.Length != 0)
            {
                db.updateMachinery(id, machineName, machineInfo, machineField);
                MessageBox.Show("Данные техники успешно обновлены!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
