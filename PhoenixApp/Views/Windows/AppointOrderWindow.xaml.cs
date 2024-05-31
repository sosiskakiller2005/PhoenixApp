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
    /// Логика взаимодействия для AppointOrderWindow.xaml
    /// </summary>
    public partial class AppointOrderWindow : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        private static Order _selectedOrder;
        private static OrderUser _selectedOrderUser;
        private static User _selectedUser;
        public AppointOrderWindow(Order selectedOrder, OrderUser selectedOrderUser)
        {
            InitializeComponent();
            _selectedOrder = selectedOrder;
            _selectedOrderUser = selectedOrderUser;
            UsersLV.ItemsSource = _context.User.ToList();
        }

        private void BackToUserSCab2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UsersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUser = UsersLV.SelectedItem as User;
            OrderUser selectedOrderUser = _context.OrderUser.First(ou => ou.IdOrder == _selectedOrder.Id);
            _selectedOrderUser = selectedOrderUser;
            SubmitOrderWindow submitOrderWindow = new SubmitOrderWindow(_selectedOrder, _selectedOrderUser, _selectedUser);
            submitOrderWindow.ShowDialog();
        }
    }
}
