using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkbTest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(args[0], int.Parse(args[1]));
            var consoleKey = Console.ReadKey();
            var prefix = string.Empty;
            while (consoleKey.Key != ConsoleKey.Escape)
            {

                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    client.GetDictionaryData(prefix);
                    prefix = string.Empty;
                    Thread.Sleep(120000);
                }

                prefix += consoleKey.KeyChar;
                consoleKey = Console.ReadKey();
            }
        }

    }

    public class Client
    {
        private readonly IPEndPoint _ipEndPoint;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        public Client(string ipOrHostName, int port)
        {
            try
            {
                var ipAddress = Dns.GetHostEntry(ipOrHostName).AddressList[0];
                _ipEndPoint = new IPEndPoint(ipAddress, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void GetDictionaryData(string command)
        {
            var thread = new Thread(GetData);
            thread.Start(command);
        }

        private void GetData(object command)
        {
            var tcpClient = new TcpClient(_ipEndPoint);
            try
            {
                var data = Encoding.ASCII.GetBytes((string) command);
                tcpClient.Connect(_ipEndPoint);
                tcpClient.GetStream().Write(data, 0, data.Length);
            
                //read data

                var buffer = new byte[1024];
                int count;
                var totalCount = 0;
                var responseData = string.Empty;
                while ((count = tcpClient.GetStream().Read(buffer, totalCount, buffer.Length)) > 0)
                {
                    totalCount += count;
                    responseData += Encoding.ASCII.GetString(buffer);
                }
            
                Console.WriteLine(responseData);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}
