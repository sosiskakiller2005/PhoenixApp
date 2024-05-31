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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        public OrderWindow()
        {
            InitializeComponent();
            ordersLV.ItemsSource = _context.Order.ToList();
        }

        private void ordersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedOrderId = (ordersLV.SelectedItem as Order).Id;
            OrderUser selectedOrderUser;
            if (_context.OrderUser.FirstOrDefault(ou => ou.IdOrder == selectedOrderId) == null)
            {
                MessageBoxHelper.Error("На данный заказ уже выбран сотрудник");
            }
            else
            {
                selectedOrderUser = _context.OrderUser.FirstOrDefault(ou => ou.IdOrder == selectedOrderId);
                AppointOrderWindow appointOrderWindow = new AppointOrderWindow(ordersLV.SelectedItem as Order, selectedOrderUser);
                appointOrderWindow.ShowDialog();
            }

        }

        private void ReturnInCabinetBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
