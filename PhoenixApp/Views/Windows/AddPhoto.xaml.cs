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
    /// Логика взаимодействия для AddPhoto.xaml
    /// </summary>
    public partial class AddPhoto : Window
    {
        private static PhoenixDbEntities _context = App.GetContext();
        public AddPhoto()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationHelper.selectedUser.PhotoUrl = URLTb.Text;
            _context.SaveChanges();
            MessageBoxHelper.Information("Фотография добавлена");
            DialogResult = true;
            Close();
        }
    }
}
