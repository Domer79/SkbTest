using System.Collections;
using System.Collections.Generic;

namespace IntelliSenseHelper
{
    public class WordInfoCollection : ICollection<WordInfo>
    {
        private readonly int _count;
        private readonly List<WordInfo> _list = new List<WordInfo>();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        public WordInfoCollection()
        {
        }

        public WordInfoCollection(List<string> lines)
        {
            _count = int.Parse(lines[0]);

            for (var i = 1; i <= _count; i++)
            {
                Add(new WordInfo(lines[i]));
            }
        }

        public IEnumerator<WordInfo> GetEnumerator()
        {
//            return _list.GetEnumerator();
//            return _hash.GetEnumerator();
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Добавляет элемент в коллекцию <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">Объект, добавляемый в коллекцию <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">Объект <see cref="T:System.Collections.Generic.ICollection`1"/> доступен только для чтения.</exception>
        public void Add(WordInfo item)
        {
//            _list.Add(item);
//            _hash.Add(item);
            _list.Add(item);
        }

        /// <summary>
        /// Удаляет все элементы из коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">Объект <see cref="T:System.Collections.Generic.ICollection`1"/> доступен только для чтения.</exception>
        public void Clear()
        {
//            _list.Clear();
//            _hash.Clear();
            _list.Clear();
        }

        /// <summary>
        /// Определяет, содержит ли коллекция <see cref="T:System.Collections.Generic.ICollection`1"/> указанное значение.
        /// </summary>
        /// <returns>
        /// Значение true, если параметр <paramref name="item"/> найден в коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>; в противном случае — значение false.
        /// </returns>
        /// <param name="item">Объект, который требуется найти в <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(WordInfo item)
        {
//            return _list.Contains(item);
//            return _hash.Contains(item);
            return _list.Contains(item);
        }

        /// <summary>
        /// Копирует элементы <see cref="T:System.Collections.Generic.ICollection`1"/> в массив <see cref="T:System.Array"/>, начиная с указанного индекса <see cref="T:System.Array"/>.
        /// </summary>
        /// <param name="array">Одномерный массив <see cref="T:System.Array"/>, в который копируются элементы из интерфейса <see cref="T:System.Collections.Generic.ICollection`1"/>. Массив <see cref="T:System.Array"/> должен иметь индексацию, начинающуюся с нуля.</param><param name="arrayIndex">Отсчитываемый от нуля индекс в массиве <paramref name="array"/>, указывающий начало копирования.</param><exception cref="T:System.ArgumentNullException">Параметр <paramref name="array"/> имеет значение null.</exception><exception cref="T:System.ArgumentOutOfRangeException">Значение параметра <paramref name="arrayIndex"/> меньше 0.</exception><exception cref="T:System.ArgumentException">Количество элементов в исходной коллекции <see cref="T:System.Collections.Generic.ICollection`1"/> превышает доступное место, начиная с индекса <paramref name="arrayIndex"/> до конца массива назначения <paramref name="array"/>.</exception>
        public void CopyTo(WordInfo[] array, int arrayIndex)
        {
//            _list.CopyTo(array, arrayIndex);
//            _hash.CopyTo(array, arrayIndex);
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Удаляет первый экземпляр указанного объекта из коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// Значение true, если элемент <paramref name="item"/> успешно удален из <see cref="T:System.Collections.Generic.ICollection`1"/>, в противном случае — значение false. Этот метод также возвращает значение false, если параметр <paramref name="item"/> не найден в исходном интерфейсе <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">Объект, который необходимо удалить из коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">Объект <see cref="T:System.Collections.Generic.ICollection`1"/> доступен только для чтения.</exception>
        public bool Remove(WordInfo item)
        {
//            return _list.Remove(item);
//            return _hash.Remove(item);
            return _list.Remove(item);
        }

        /// <summary>
        /// Получает число элементов, содержащихся в интерфейсе <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// Число элементов, содержащихся в интерфейсе <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get
            {
//                return _count;
//                return _list.Count;
//                return _hash.Count;
                return _list.Count;
            }
        }

        /// <summary>
        /// Получает значение, указывающее, доступна ли <see cref="T:System.Collections.Generic.ICollection`1"/> только для чтения.
        /// </summary>
        /// <returns>
        /// Значение true, если <see cref="T:System.Collections.Generic.ICollection`1"/> доступна только для чтения; в противном случае — значение false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        public WordInfo this[int index]
        {
            get { return _list[index]; }
        }
    }

    internal class WordInfoComparer : IComparer<WordInfo>
    {
        /// <summary>
        /// Сравнивает два объекта и возвращает значение, показывающее, что один объект меньше или больше другого или равен ему.
        /// </summary>
        /// <returns>
        /// Знаковое целое число, которое определяет относительные значения <paramref name="x"/> и <paramref name="y"/>, как показано в следующей таблице. Значение  Значение  Меньше нуля Значение параметра <paramref name="x"/> меньше значения параметра <paramref name="y"/>. Zero Значение параметра <paramref name="x"/> равно значению параметра <paramref name="y"/>. Больше нуля. Значение <paramref name="x"/> больше значения <paramref name="y"/>.
        /// </returns>
        /// <param name="x">Первый сравниваемый объект.</param><param name="y">Второй сравниваемый объект.</param>
        public int Compare(WordInfo x, WordInfo y)
        {
            return string.Compare(x.Word, y.Word, System.StringComparison.Ordinal);
        }
    }
}