using PhoenixApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PhoenixApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static PhoenixDbEntities _context;
        public static PhoenixDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new PhoenixDbEntities();
            }
            return _context;
        }
    }
}
