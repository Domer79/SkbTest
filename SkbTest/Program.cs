using System;
using System.Collections;
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

        static void Main(string[] args)
        {
            Console.ReadKey();
            var stopwatch = Stopwatch.StartNew();

/*********************************************************************************************/
            _userWordCollection = TestHelper.UserWordCollection;


//            foreach (var word in _userWordCollection)
//            {
//                Console.WriteLine(word.ToString("words"));
//            }

            TestHelper.UserWordsWrite();

//            File.WriteAllLines("result.txt", _userWordCollection.Select(word => word.ToString("detail")));
/*********************************************************************************************/

//            #region Sort Number Testing
//
//            const int count = 10000000;
//            var rnd = new Random();
//            var sortNumber = new SortNumber(rnd.Next(1, count));
////            var list = new SortedSet<int>();
//            for (int i = 0; i < count; i++)
//            {
//                sortNumber.Add(rnd.Next(1, count));
////                list.Add(rnd.Next(1, count));
//            }
//
//            Console.WriteLine(stopwatch.ElapsedMilliseconds);
//            stopwatch.Restart();
//
//            foreach (var i in sortNumber)
//            {
//
//            }
//
////            list.OrderBy(i => i).ToList();
//
//            #endregion


            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }

    public class SortNumber : IEnumerable<int>
    {
        private readonly int _number;
        private SortNumber _lessNumber;
        private SortNumber _moreNumber;
        private List<int> _enumerationList;

        public SortNumber(int number)
        {
            _number = number;
        }

        public void Add(int number)
        {
            if (number >= _number)
            {
                AddTo(ref _moreNumber, number);
                return;
            }

            AddTo(ref _lessNumber, number);
        }

        private void AddTo(ref SortNumber sortNumber, int number)
        {
            if (sortNumber == null)
            {
                sortNumber = new SortNumber(number);
                return;
            }

            sortNumber.Add(number);
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий итерацию в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        public IEnumerator<int> GetEnumerator()
        {
            return Enumeration().GetEnumerator();
        }

        private IEnumerable<int> Enumeration()
        {
            _enumerationList = new List<int>();
            Enumerate(_enumerationList);
            return _enumerationList;
        }

        private void Enumerate(List<int> enumerationList)
        {
            if (_lessNumber != null)
                _lessNumber.Enumerate(enumerationList);

            enumerationList.Add(_number);

            if (_moreNumber != null)
                _moreNumber.Enumerate(enumerationList);
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий итерацию в коллекции.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.Collections.IEnumerator"/>, который может использоваться для перебора коллекции.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
