using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ClientSpace
{
    /// <summary>
    /// Логика взаимодействия для Window_authentification.xaml
    /// </summary>
    public partial class Window_authentification : Window
    {      
        

        public Window_authentification()
        {
            InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client;
            client = new Client();
            
            client.ConnectAsync(new IPEndPoint(IPAddress.Parse("192.168.88.75"), 50000));
            client.WriteAsync(Encoding.Unicode.GetBytes(Login_box.Text + " " + Password_box.Text));
            
            if (Encoding.Unicode.GetString(await client.ReadAsync()) == "yes") 
            {
                MainWindow mainWindow = new MainWindow(client);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }

        }
    }
}
