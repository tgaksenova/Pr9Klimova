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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pr9Klimova.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            Auth(txtlog.Text, Pass.Password);
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {

                MessageBox.Show("Введите логин и пароль!");
                return false;
            }

            using (var db = new Borisov_Pr9Entities())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == txtlog.Text && u.Password == Pass.Password);


                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    txtlog.Text = string.Empty;
                    Pass.Password = string.Empty;

                    return false;
                }
                else
                {
                    MessageBox.Show($"Здравствуйте, {user.FIO}!");
                    txtlog.Text = string.Empty;
                    Pass.Password = string.Empty;
                    return true;
                }
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            txtlog.Text = string.Empty;
            Pass.Password = string.Empty;
            NavigationService.Navigate(new RegPage());
        }
    }
}
