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
    /// Interaction logic for AddSeeds.xaml
    /// </summary>
    public partial class AddSeeds : Window
    {
        public AddSeeds()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();   
        }

        private void goBack()
        {
            Seeds seeds = new Seeds();
            seeds.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            string seedsName = nameBox.Text;
            int seedsWeight = Convert.ToInt32(weightBox.Text);

            if (seedsName != "") 
            {
                db.addSeeds(seedsName, seedsWeight);
                MessageBox.Show("Семена добавлены!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }
    }
}
