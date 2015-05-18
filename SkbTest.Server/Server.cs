using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SkbTest.Server
{
    internal class Server
    {
        private readonly TcpListener _listener;

        /// <summary>
        /// »нициализирует новый экземпл€р класса <see cref="T:System.Object"/>.
        /// </summary>
        private Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        private void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started");
            while (true)
            {
                var client = _listener.AcceptTcpClient();
                var thread = new Thread(new ParameterizedThreadStart(ClientThread));
                thread.Start(client);
            }
        }

        private void ClientThread(object state)
        {
            Client.Reply((TcpClient)state);
        }

        ~Server()
        {
            if (_listener != null)
                _listener.Stop();
        }

        public static void Start(int port)
        {
            var server = new Server(port);
            server.Start();
        }
    }
}