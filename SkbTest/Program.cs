using System;
using System.Diagnostics;
using IntelliSenseHelper;

namespace SkbTest
{
    //21523359.0 - возможных значений
    class Program
    {
        private static WordInfoCollection _wordInfoCollection;
        private static UserWordCollection _userWordCollection;
        private const string FileName = "test.in";

        static void Main(string[] args)
        {
            Console.ReadKey();
            var stopwatch = Stopwatch.StartNew();

            _wordInfoCollection = Helper.WordInfoCollection;
            _userWordCollection = Helper.UserWordCollection;

//            Console.WriteLine(_wordInfoCollection.Count);
//            Console.WriteLine(_userWordCollection.Count);
            int i;
            for (i = 0; i < Helper.WordInfoCollection.Count; i++)
            {
                LetterInfo.Add(Helper.WordInfoCollection[i].Word);
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
