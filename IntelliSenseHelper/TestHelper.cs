using System;
using System.Collections.Generic;
using System.IO;

namespace IntelliSenseHelper
{
    public static class TestHelper
    {
//        public static string FileName;
        private const string FileName = "test.in";

        private static readonly List<string> Lines = new List<string>(File.ReadLines(FileName));

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        static TestHelper()
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

            UserWordCollection = new UserWordCollection();
            for (int j = count + 2; j < Lines.Count; j++)
            {
                UserWordCollection.Add(Lines[j]);
            }
        }

        public static void UserWordsWrite()
        {
            var count = int.Parse(Lines[0]);
            for (int i = count + 2; i < Lines.Count; i++)
            {
                Console.WriteLine(UserWordCollection[Lines[i]].ToString("words"));
            }
        }

        public static UserWordCollection UserWordCollection { get; set; }
    }
}
