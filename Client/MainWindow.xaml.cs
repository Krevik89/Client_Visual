using System;
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

namespace Client
{
    
    public partial class MainWindow : Window
    {
        TcpClient client; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private async  void Accept_Click(object sender, RoutedEventArgs e)
        {
            
            Method("exit123");
                    
        }

        private  void Method(string str)
        {
            client = new TcpClient();
            try
            {
                 client.Connect(IPAddress.Parse("192.168.88.75"), 50000);

                NetworkStream stream = client.GetStream();

                byte[] data = Encoding.Unicode.GetBytes(str);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[256];
                stream.Read(buffer, 0, buffer.Length);

                textout.Text = string.Empty;
                textout.Text = Encoding.Unicode.GetString(buffer);
            }

            catch (SocketException se)
            {
                Console.WriteLine(se);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Method("exit");
            client?.Close();
        }
    }
}
