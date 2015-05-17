using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using IntelliSenseHelper;

namespace SkbTest.Server
{
    class Program
    {
        private static string _fileName;
        private static List<string> _lines;
        private static int _dictionaryCount;
        public static UserWordCollection UserWordCollection;

        static void Main(string[] args)
        {
            _fileName = args[0];
            _lines = new List<string>(File.ReadLines(_fileName));
            _dictionaryCount = int.Parse(_lines[0]);
            UserWordCollection = new UserWordCollection();

            PrepareLetters();

            var thread = new Thread(ServerStart);
            thread.Start(int.Parse(args[1]));

            while (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Server.Stop();
            }
        }

        private static void ServerStart(object port)
        {
            Server.Start((int)port);
        }

        private static void PrepareLetters()
        {
            for (var i = 1; i <= _dictionaryCount; i++)
            {
                var word = _lines[i].Split(' ')[0];
                var countWords = int.Parse(_lines[i].Split(' ')[1]);
                LetterInfo.Add(word, countWords);
            }
        }
    }

    internal class Server
    {
        private readonly TcpListener _listener;
        private static bool _isStop;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        private Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        private void Start()
        {
            _listener.Start();
            _isStop = false;
            while (!_isStop)
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

        public static void Stop()
        {
            _isStop = true;
        }
    }

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
            int count;
            var totalCount = 0;

            try
            {
                _stream = _client.GetStream();

                if (!_stream.CanRead)
                    throw new DataReadImpossibleException();

                while ((count = _stream.Read(buffer, totalCount, buffer.Length)) > 0)
                {
                    totalCount += count;

                    _data += Encoding.ASCII.GetString(buffer);
                }
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

        private void SendToClient(object data)
        {
            try
            {
                if (!_stream.CanWrite)
                    throw new DataWriteImpossibleException("Поток не поддерживает запись");

                var dataBytes = data.ToByteArray();
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

    internal class PrefixIsMissingException : Exception
    {
        /// <summary>
        /// Выполняет инициализацию нового экземпляра класса <see cref="T:System.Exception"/>, используя указанное сообщение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public PrefixIsMissingException() 
            : base("Отсутствует префикс")
        {
        }
    }

    public static class Extensions
    {
        public static byte[] ToByteArray(this object @object)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, @object);
                return ms.ToArray();
            }
        }
    }

    internal class DataWriteImpossibleException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Exception"/>.
        /// </summary>
        public DataWriteImpossibleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Выполняет инициализацию нового экземпляра класса <see cref="T:System.Exception"/>, используя указанное сообщение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public DataWriteImpossibleException() 
            : base("Не возможно отправить данные")
        {
        }
    }

    internal class DataReadImpossibleException : Exception
    {
        public DataReadImpossibleException()
            : base("Невозможно прочитать данные")
        {
            
        }
    }
}
