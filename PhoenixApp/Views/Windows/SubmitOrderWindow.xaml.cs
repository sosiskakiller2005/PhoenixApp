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
    /// Логика взаимодействия для SubmitOrderWindow.xaml
    /// </summary>
    public partial class SubmitOrderWindow : Window
    {
        private static Order _selectedOrder;
        private static OrderUser _selectedOrderUser;
        private static User _selectedUser;
        private static PhoenixDbEntities _context = App.GetContext();
        public SubmitOrderWindow(Order selectedOrder, OrderUser selectedOrderUser, User selectedUser)
        {
            InitializeComponent();
            _selectedOrder = selectedOrder;
            _selectedOrderUser = _context.OrderUser.First(ou => ou.IdOrder == selectedOrder.Id);
            _selectedUser = selectedUser;
            UserGrid.DataContext = _selectedOrder.Client;
            DateOfPlacementTbl.Text = String.Format("{0:dd.MM.yyy}", DateTime.Now);

            int sum = 0;
            List<OrderProduction> productions = _context.OrderProduction.Where(op => op.IdOrder == _selectedOrder.Id).ToList();
            int count = productions.Count();
            for (int i = 0; i < count; i++)
            {
                sum += productions.ElementAt(i).Production.Price;
            }
            SumTbl.Text = sum.ToString();
        }

        private void CheckOurOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedOrderUser.IdUser = _selectedUser.Id;
            _context.SaveChanges();
            MessageBoxHelper.Information("Заказ оформлен!");
            Close();
        }

        private void DeclineOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
