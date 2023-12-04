using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientSpace
{
    public class Client
    {
        TcpClient tcpClient;
        NetworkStream stream;

        public Client()
        {
            tcpClient = new TcpClient();                      
        }

        public async void ConnectAsync(IPEndPoint point)
        {
            try
            {
                await tcpClient.ConnectAsync(point.Address,point.Port);
                stream = tcpClient.GetStream();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public byte[] Read()
        {
            byte[] buffer = new byte[256];
            
            do
            {
                stream.Read(buffer, 0, buffer.Length);
                 
            } while (stream.DataAvailable);
            //await stream.ReadAsync(buffer, 0, buffer.Length);
            return buffer;
        }

        public  void Write(byte[] request)
        {                      
             stream.Write(request, 0, request.Length);
        }

        public void Close()
        {
            tcpClient.Close();
            stream.Close();
        }

    }
}
