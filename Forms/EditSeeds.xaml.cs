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
    /// Interaction logic for EditSeeds.xaml
    /// </summary>
    public partial class EditSeeds : Window
    {
        private int id;
        private DB db = new DB();
        public EditSeeds(int id)
        {
            InitializeComponent();
            this.id = id;
            FillFields();

        }

        private void FillFields()
        {
            Models.Seeds seeds = db.getSeedsById(id);
            nameBox.Text = seeds.Name;
            weightBox.Text = seeds.Weight.ToString();
        }

        private void goBack()
        {
            Seeds seeds = new Seeds();
            seeds.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string seedsName = nameBox.Text;
            int seedsWeight = Convert.ToInt32(weightBox.Text);

            if (seedsName != "")
            {
                db.updateSeeds(id, seedsName, seedsWeight);
                MessageBox.Show("Данные успешно изменены!");
                goBack();
                return;
            }

            MessageBox.Show("Некорректные данные!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack();
        }
    }
}
