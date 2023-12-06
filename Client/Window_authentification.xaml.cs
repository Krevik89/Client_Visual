using System;
using System.Net;
using System.Text;
using System.Windows;

namespace ClientSpace
{
   
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
            
            await client.ConnectAsync(new IPEndPoint(IPAddress.Parse("192.168.88.75"), 50000));
           
            string auth = "auth" + " " + Login_box.Text + " " + Password_box.Text;
            await client.WriteAsync(Encoding.Unicode.GetBytes(auth));

            string result = Encoding.Unicode.GetString(await client.ReadAsync()).Replace("\0","");

            if (result == "yes") 
            {
                MainWindow mainWindow = new MainWindow(ref client);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(result); 
            }

       }
    }
}
