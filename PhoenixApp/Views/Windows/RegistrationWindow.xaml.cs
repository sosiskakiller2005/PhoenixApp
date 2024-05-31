using PhoenixApp.AppData;
using PhoenixApp.Model;
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

namespace PhoenixApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrBtn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = new User() 
                {
                    Name = Name.Text,
                    Phone = Phone.Text,
                    Password = Convert.ToInt32(EmployeePasswordBx.Password),
                    Email = Email.Text,
                    Login = Email.Text,
                    IdRole = 1
                };
                _context.User.Add(newUser);
                _context.SaveChanges();
                AuthorisationWindow authorisationWindow = new AuthorisationWindow();
                authorisationWindow.Show();
                Close();
            }
            catch (Exception)
            {
                MessageBoxHelper.Error("Пароль и номер телефона должны содержать только цифры");
            }
        }

        private void EnterBtn2_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }
    }
}
