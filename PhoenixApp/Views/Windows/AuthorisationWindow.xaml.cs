using PhoenixApp.AppData;
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
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        public AuthorisationWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }

        private void AuthoriBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AuthorisationHelper.Authorise(CodeName.Text, EmployeePasswordBx.Password) == true)
                {
                    UserWindow userWindow = new UserWindow(AuthorisationHelper.selectedUser);
                    userWindow.Show();
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBoxHelper.Error("Пароль должен содержать только цифры");
            }
        }

        private void ForgPswrdBtn_Click(object sender, RoutedEventArgs e)
        {
            RecoverPasswordWindow recoverPasswordWindow = new RecoverPasswordWindow();
            recoverPasswordWindow.Show();
            Close();
        }
    }
}
