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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        private static User _selectedUser;
        public UserWindow(User selectedUser)
        {
            _selectedUser = selectedUser;
            InitializeComponent();
            UserGrid.DataContext = _selectedUser;
            if (AuthorisationHelper.selectedUser.PhotoUrl == null)
            {
                Photo.Source = new BitmapImage(new Uri("/Resources/219983.png"));
            }

        }

        private void ChangePersData_Click(object sender, RoutedEventArgs e)
        {
            EditProfileWindow editProfileWindow = new EditProfileWindow();
            editProfileWindow.ShowDialog();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AnaliticsBtn_Click(object sender, RoutedEventArgs e)
        {
            AnalyticsWindow analyticsWindow = new AnalyticsWindow();
            analyticsWindow.ShowDialog();
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }

        private void EmployerBtn_Click(object sender, RoutedEventArgs e)
        {
            SendMessageWindow sendMessageWindow = new SendMessageWindow();
            sendMessageWindow.ShowDialog();
        }

        private void ChangePersData_Click_1(object sender, RoutedEventArgs e)
        {
            EditProfileWindow editProfileWindow = new EditProfileWindow();
            editProfileWindow.ShowDialog();
        }

        private void PhotoUploadBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto addPhoto = new AddPhoto();
            addPhoto.ShowDialog();
            if (addPhoto.DialogResult == true)
            {
                _context = App.GetContext();
                UserGrid.DataContext = _selectedUser;
            }
        }
    }
}
