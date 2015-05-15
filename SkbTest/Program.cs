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
            var list = new List<int>();
            var rnd = new Random();
            var sortNumber = new SortNumber(rnd.Next(1, 1000000), null);

            var stopwatch = Stopwatch.StartNew();

            for (int i = 1; i < 1000000; i++)
            {
//                list.Add(rnd.Next(1, 1000000));
                sortNumber.Add(rnd.Next(1, 1000000));
            }

//**************************************************************************************************
//            _userWordCollection = Helper.UserWordCollection;
//
//
//            foreach (var word in _userWordCollection)
//            {
//                Console.WriteLine(word.ToString("words"));
//            }

//            File.WriteAllLines("result.txt", _userWordCollection.Select(word => word.ToString("l")));
//**************************************************************************************************            
//            var sortedList = list.OrderBy(i => i).ToList();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }

    public class SortNumber : IEnumerable<int>
    {
        private readonly int _number;
        private SortNumber _parent;
        private SortNumber _lessNumber;
        private SortNumber _moreNumber;

        public SortNumber(int number, SortNumber parent)
        {
            _number = number;
            _parent = parent;
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
                sortNumber = new SortNumber(number, this);
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
            yield return GetNumber();
        }

        private int GetNumber()
        {
            if (_lessNumber != null)
                return _lessNumber.GetNumber();

            if (_moreNumber != null)
                return _moreNumber.GetNumber();

            return _number;
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

    public class IntEnum : IEnumerator<int>
    {
        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Перемещает перечислитель к следующему элементу коллекции.
        /// </summary>
        /// <returns>
        /// Значение true, если перечислитель был успешно перемещен к следующему элементу; значение false, если перечислитель достиг конца коллекции.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Коллекция была изменена после создания перечислителя.</exception>
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Устанавливает перечислитель в его начальное положение, т. е. перед первым элементом коллекции.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">Коллекция была изменена после создания перечислителя.</exception>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получает элемент коллекции, соответствующий текущей позиции перечислителя.
        /// </summary>
        /// <returns>
        /// Элемент коллекции, соответствующий текущей позиции перечислителя.
        /// </returns>
        public int Current { get; private set; }

        /// <summary>
        /// Получает текущий элемент в коллекции.
        /// </summary>
        /// <returns>
        /// Текущий элемент в коллекции.
        /// </returns>
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
