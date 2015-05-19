using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using IntelliSenseHelper;

namespace SkbTest
{
    //21523359.0 - возможных значений
    class Program
    {
        static void Main(string[] args)
        {
//            var stopwatch = Stopwatch.StartNew();

//            TestHelper.UserWordsWrite();

            while (true)
            {
                var word = Console.ReadLine();

                if (string.IsNullOrEmpty(word))
                    continue;

                var lowerWord = word.ToLower();

                if (lowerWord == "exit" || lowerWord == "quit")
                    break;

                Console.WriteLine(TestHelper.UserWordCollection[word].ToString("words"));
            }

//            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }
    }

    /// <summary>
    /// Класс для сортировки коллекции чисел, сама сортировка происходит быстро, но работа класса замедляется добавлением элементов в бинарное дерево
    /// </summary>
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
