using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliSenseHelper
{
    public static class Helper
    {
        private const string FileName = "test.in";

        private static readonly List<string> Lines = new List<string>(File.ReadLines(FileName));

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        static Helper()
        {
            PrepareData();
        }

        private static void PrepareData()
        {
            var count = int.Parse(Lines[0]);
            int i;
            for (i = 1; i <= count; i++)
            {
                var word = Lines[i].Split(' ')[0];
                var countWords = int.Parse(Lines[i].Split(' ')[1]);
                LetterInfo.Add(word, countWords);
            }

            UserWordCollection = GetUserWordCollection();
        }

        private static UserWordCollection GetUserWordCollection()
        {
            return new UserWordCollection(Lines);
        }

        private static WordInfoCollection GetWordInfoCollection()
        {
            return new WordInfoCollection(Lines);
        }

        public static UserWordCollection UserWordCollection { get; set; }

        public static WordInfoCollection WordInfoCollection { get; set; }
    }
}
