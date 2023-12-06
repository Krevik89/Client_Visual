using System;
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

        public async Task ConnectAsync(IPEndPoint point)
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

        public async Task<byte[]> ReadAsync()
        {
            byte[] buffer = new byte[256];
            
            do
            {
                await stream.ReadAsync(buffer, 0, buffer.Length);
                 
            } while (stream.DataAvailable);
            //await stream.ReadAsync(buffer, 0, buffer.Length);
            return buffer;
        }

        public async Task WriteAsync(byte[] request)
        {                      
             await stream.WriteAsync(request, 0, request.Length);
        }

        public void Close()
        {
            tcpClient.Close();
            stream.Close();
        }

    }
}
