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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(IPAddress.Parse("192.168.88.75"), 50000);

                NetworkStream stream = client.GetStream();

                byte[] data = Encoding.Unicode.GetBytes("exit1");
                byte[] recive =BitConverter.GetBytes(data.Length);
                stream.Write(recive, 0, recive.Length);

                stream.Write(data, 0, data.Length);
                Console.WriteLine("Запрос отправлен");


                //Thread.Sleep(1000);
                
                int count;
                string message="";
                byte[] buffer = new byte[256];
                stream.Read(buffer, 0, buffer.Length);
                count= BitConverter.ToInt32(buffer, 0);
                byte[] bytes= new byte[count];
                stream.Read(bytes, 0, count);
                textout.Text=Encoding.Unicode.GetString(bytes);

                /*
                while ((count = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                     message+= Encoding.Unicode.GetString(buffer, 0, count);
                    Console.WriteLine("GGG");
                }*/
               
                //client.Close();
                
                //textout.Text = message;

                //count = stream.Read(buffer, 0, buffer.Length);
                //message += Encoding.Unicode.GetString(buffer, 0, count);
                //MessageBox.Show(message);
            }
            
            catch (SocketException se)
            {
                Console.WriteLine(se);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                client.Close();
            }


            
        }
    }
}
