using System;
using System.Collections.Generic;
using System.IO;
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
            CheckArguments(args);
            _fileName = args[0];
            _lines = new List<string>(File.ReadLines(_fileName));
            _dictionaryCount = int.Parse(_lines[0]);
            UserWordCollection = new UserWordCollection();

            PrepareLetters();

            ServerStart(int.Parse(args[1]));
//            var thread = new Thread(ServerStart);
//            thread.Start(int.Parse(args[1]));
        }

        private static void CheckArguments(string[] args)
        {
            if (args.Length != 2)
                throw new Exception("Параметров недостаточно");

            if (string.IsNullOrEmpty(args[0]))
                throw new Exception("Не верный формат первого параметра");

            int count;
            if (!int.TryParse(args[1], out count))
                throw new Exception("Не возможно прочитать второй параметр");
        }

        private static void ServerStart(object port)
        {
            Server.Start((int)port);
            Console.WriteLine("Server stoped");
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
}
