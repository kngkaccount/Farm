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
    /// Interaction logic for EditField.xaml
    /// </summary>
    public partial class EditField : Window
    {
        private int id;
        private DB db = new DB();
        public EditField(int id)
        {
            InitializeComponent();
            this.id = id;

            FillFields();
        }

        private void FillFields()
        {
            Models.Field field = db.getFieldById(id);
            nameBox.Text = field.Name;
            informationBox.Text = field.Information;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string fieldName = nameBox.Text;
            string fieldInfo = informationBox.Text;

            if (fieldName != "")
            {
                db.updateField(id, fieldName, fieldInfo);
                MessageBox.Show("Данные успешно изменены!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }

        private void goBack()
        {
            Field field = new Field();
            field.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }
    }
}
