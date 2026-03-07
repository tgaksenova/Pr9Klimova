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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtlog.Text)
                || string.IsNullOrEmpty(pswbPass.Password)
                || string.IsNullOrEmpty(pswbConfirmPass.Password)
                || string.IsNullOrEmpty(txtFullName.Text))
            {

                MessageBox.Show("Заполните все поля!");
                return;
            }

            using (var db = new Borisov_Pr9Entities())
            {
                if (db.User.Any(u => u.Login == txtlog.Text))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            

            string password = pswbPass.Password;

            // Проверка длины
            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка на английские символы
            if (!IsEnglishLetters(password))
            {
                MessageBox.Show("Пароль должен содержать только английские символы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка наличия цифры
            if (!ContainsDigit(password))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string confirmPassword = pswbConfirmPass.Password;

            // Проверка совпадения паролей
            if (password != confirmPassword)
            {
                MessageBox.Show("Введённые пароли не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Entities db = new Entities();
            User userObject = new User
            {
                FIO = txtFullName.Text,
                Login = txtlog.Text,
                Password = pswbPass.Password
            };
            db.User.Add(userObject);
            db.SaveChanges();

            MessageBox.Show($"Пользователь {txtlog.Text} зарегистрирован!");

            }

        }

        //  метод для проверки английских букв
        private bool IsEnglishLetters(string input)
        {
            return input.All(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || char.IsDigit(c));
        }

        //  метод для проверки наличия цифры
        private bool ContainsDigit(string input)
        {
            return input.Any(c => char.IsDigit(c));
        }
    }
}
