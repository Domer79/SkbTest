using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IntelliSenseHelper;

namespace SkbTest
{
    //21523359.0 - возможных значений
    class Program
    {
        private static UserWordCollection _userWordCollection;
        private const string FileName = "test.in";

        static void Main(string[] args)
        {
            Console.ReadKey();
            var stopwatch = Stopwatch.StartNew();

            _userWordCollection = Helper.UserWordCollection;

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            var words = LetterInfo.Enumeration(LetterInfo.Instance).ToList();
//            var words = LetterInfo.Enumeration(LetterInfo.Instance, string.Empty, 1).ToList();
//            foreach (var word in words)
//            {
//                Console.WriteLine(word);
//            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
