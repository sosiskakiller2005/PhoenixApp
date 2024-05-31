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
    /// Логика взаимодействия для EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        private static User _selectedUser;
        public EditProfileWindow()
        {
            InitializeComponent();
            UserGrid.DataContext = AuthorisationHelper.selectedUser;

        }

        private void UserDataChangeBttncONFIRM_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxHelper.Question("Сохранить изменения") == true)
            {
                try
                {
                    _selectedUser.Phone = PhoneTb.Text;
                    _selectedUser.Email = Email.Text;
                    _selectedUser.Login = Email.Text;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBoxHelper.Error("Пароль и номер телефона должны содержать только цифры");
                }
            }
            Close();
        }

        private void UploadPhoto2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
