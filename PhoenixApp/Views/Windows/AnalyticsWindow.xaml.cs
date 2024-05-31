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
    /// Логика взаимодействия для AnalyticsWindow.xaml
    /// </summary>
    public partial class AnalyticsWindow : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        public AnalyticsWindow()
        {
            InitializeComponent();
            List<Order> orders = _context.Order.Where(o => o.IdStatus == 1).ToList();
            List<Order> notFinishedOrders = _context.Order.Where(o => o.IdStatus == 2).ToList();
            NotFinishedOrdersTB.Text = notFinishedOrders.Count.ToString();
            FinishedOrdersTB.Text = orders.Count.ToString();
            OrdersTB.Text = (orders.Count + notFinishedOrders.Count).ToString();

            User selectedUser = _context.User.First();
            List<User> users = _context.User.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                if (users.ElementAt(i).OrdersFinished > selectedUser.OrdersFinished)
                {
                    selectedUser = users.ElementAt(i);
                }
            }
            MostOrdersTb.Text = selectedUser.Email;

            selectedUser = _context.User.First();
            for (int i = 0; i < users.Count; i++)
            {
                if (users.ElementAt(i).OrdersFinished < selectedUser.OrdersFinished)
                {
                    selectedUser = users.ElementAt(i);
                }
            }
            LeastOrdersTb.Text = selectedUser.Email;
        }

        private void FromAnaliticsToCabinetBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
