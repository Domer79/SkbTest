using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using IntelliSenseHelper;

namespace SkbTest.Client
{
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
                IPAddress ipAddress;
                ipAddress = IPAddress.TryParse(ipOrHostName, out ipAddress)
                    ? IPAddress.Parse(ipOrHostName)
                    : Dns.GetHostEntry(ipOrHostName).AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork);

                _ipEndPoint = new IPEndPoint(ipAddress, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void GetDictionaryData(string command)
        {
            var thread = new Thread(GetData);
            thread.Start(command);
        }

        private void GetData(object command)
        {
            var tcpClient = new TcpClient();
            try
            {
                var data = Encoding.ASCII.GetBytes((string) command);
                tcpClient.Connect(_ipEndPoint);
                tcpClient.GetStream().Write(data, 0, data.Length);

                //read data

                var buffer = new byte[1024];
                var endMark = Encoding.ASCII.GetBytes("<EOF>");
                var responseData = Encoding.ASCII.GetString(tcpClient.GetStream().ReadBytes(endMark, buffer));
                Console.WriteLine(responseData);
            }
            catch (SocketException exc)
            {
                Console.WriteLine(exc.Message);
                throw new Exception("Произошла ошибка при установлении связи с сервером", exc);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}