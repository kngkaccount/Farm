using Farm.FarmDataSetTableAdapters;
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
    /// Interaction logic for AddField.xaml
    /// </summary>
    public partial class AddField : Window
    {
        public AddField()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Field field = new Field();
            field.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            string fieldName = nameBox.Text;
            string fieldInfo = informationBox.Text;

            if(fieldName != "")
            {
                db.addField(fieldName, fieldInfo);
                MessageBox.Show("Новое поле создано!");
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
