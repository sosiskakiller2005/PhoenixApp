﻿using PhoenixApp.AppData;
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
    /// Логика взаимодействия для SendMessageWindow.xaml
    /// </summary>
    public partial class SendMessageWindow : Window
    {
        public SendMessageWindow()
        {
            InitializeComponent();
        }

        private void SendMessageBTn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxHelper.Information("Сообщение отправлено!");
            Close();
        }
    }
}
