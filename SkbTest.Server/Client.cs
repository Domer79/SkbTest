using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using IntelliSenseHelper;
using IntelliSenseHelper.Exceptions;
using SkbTest.Server.Exceptions;

namespace SkbTest.Server
{
    internal class Client
    {
        private readonly TcpClient _client;
        private string _data;
        private NetworkStream _stream;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        public Client(TcpClient client)
        {
            _client = client;
            ReadData();
        }

        private void ReadData()
        {
            var buffer = new byte[3];

            try
            {
                _stream = _client.GetStream();
                _data += Encoding.ASCII.GetString(_stream.ReadBytes(new byte[]{13,10}, buffer));
            }
            catch (Exception e)
            {
                SendError(e);
            }
        }

        private void SendError(Exception exc)
        {
            var excMessage = string.Format("{0}: {1}", exc.GetType().Name, exc.Message);
            Console.WriteLine(excMessage);
            SendToClient(excMessage);
        }

        private void SendToClient(string data)
        {
            try
            {
                if (!_stream.CanWrite)
                    throw new DataWriteImpossibleException("Поток не поддерживает запись");

                data += "<EOF>";
                var dataBytes = Encoding.ASCII.GetBytes(data);
                _stream.Write(dataBytes, 0, dataBytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
        }

        public void Reply()
        {
            try
            {
                SendToClient(Program.UserWordCollection[Prefix].ToString("words"));
            }
            catch (Exception e)
            {
                SendError(e);
            }
        }

        private string Prefix
        {
            get
            {
                var match = Regex.Match(_data, @"get (?<prefix>\w+)");

                if (!match.Success)
                    throw new PrefixIsMissingException();

                return match.Groups["prefix"].Value;
            }
        }

        public static void Reply(TcpClient state)
        {
            var client = new Client(state);
            client.Reply();
        }
    }
}