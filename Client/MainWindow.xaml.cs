﻿using System;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Threading;

namespace ClientSpace
{
   
    public partial class MainWindow : Window
    {
        Client Client;
        public MainWindow(ref Client client)
        {
            InitializeComponent();
            Client = client;           
        }

        private  async void Accept_Click(object sender, RoutedEventArgs e)
        {
            await Client.WriteAsync(Encoding.Unicode.GetBytes("get"));
            textout.Text = Encoding.Unicode.GetString(await Client.ReadAsync());                           
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            await Client.WriteAsync(Encoding.Unicode.GetBytes("exit"));
            Client.Close();
        }
    }
}
