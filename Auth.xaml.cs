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
using Farm.Models;

namespace Farm
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string phone = phoneBox.Text;
            string password = passwordBox.Password;

            DB db = new DB();
            User user = db.getUserByPhone(phone);

            if(user.Id == 0)
            {
                MessageBox.Show("Такой номер телефона не зарегестрирован!");
            }
            else
            {
                if(user.Password == password)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }

        }
    }
}
