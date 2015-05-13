using System.Collections;
using System.Collections.Generic;

namespace IntelliSenseHelper
{
    public class UserWordCollection : ICollection<UserWord>
    {
        private readonly int _count;
//        private readonly List<UserWord> _list = new List<UserWord>();
        private readonly HashSet<UserWord> _hash = new HashSet<UserWord>();

        public UserWordCollection(List<string> lines)
        {
            var wordInfoCount = int.Parse(lines[0]);
            _count = int.Parse(lines[wordInfoCount + 1]);

            for (int i = wordInfoCount + 2; i < lines.Count; i++)
            {
                Add(new UserWord(lines[i]/*, i*/));
            }
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий итерацию в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        public IEnumerator<UserWord> GetEnumerator()
        {
//            return _list.GetEnumerator();
            return _hash.GetEnumerator();
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

        /// <summary>
        /// Добавляет элемент в коллекцию <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">Объект, добавляемый в коллекцию <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">Объект <see cref="T:System.Collections.Generic.ICollection`1"/> доступен только для чтения.</exception>
        public void Add(UserWord item)
        {
//            _list.Add(item);
            _hash.Add(item);
        }

        /// <summary>
        /// Удаляет все элементы из коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">Объект <see cref="T:System.Collections.Generic.ICollection`1"/> доступен только для чтения.</exception>
        public void Clear()
        {
//            _list.Clear();
            _hash.Clear();
        }

        /// <summary>
        /// Определяет, содержит ли коллекция <see cref="T:System.Collections.Generic.ICollection`1"/> указанное значение.
        /// </summary>
        /// <returns>
        /// Значение true, если параметр <paramref name="item"/> найден в коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>; в противном случае — значение false.
        /// </returns>
        /// <param name="item">Объект, который требуется найти в <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(UserWord item)
        {
//            return _list.Contains(item);
            return _hash.Contains(item);
        }

        /// <summary>
        /// Копирует элементы <see cref="T:System.Collections.Generic.ICollection`1"/> в массив <see cref="T:System.Array"/>, начиная с указанного индекса <see cref="T:System.Array"/>.
        /// </summary>
        /// <param name="array">Одномерный массив <see cref="T:System.Array"/>, в который копируются элементы из интерфейса <see cref="T:System.Collections.Generic.ICollection`1"/>. Массив <see cref="T:System.Array"/> должен иметь индексацию, начинающуюся с нуля.</param><param name="arrayIndex">Отсчитываемый от нуля индекс в массиве <paramref name="array"/>, указывающий начало копирования.</param><exception cref="T:System.ArgumentNullException">Параметр <paramref name="array"/> имеет значение null.</exception><exception cref="T:System.ArgumentOutOfRangeException">Значение параметра <paramref name="arrayIndex"/> меньше 0.</exception><exception cref="T:System.ArgumentException">Количество элементов в исходной коллекции <see cref="T:System.Collections.Generic.ICollection`1"/> превышает доступное место, начиная с индекса <paramref name="arrayIndex"/> до конца массива назначения <paramref name="array"/>.</exception>
        public void CopyTo(UserWord[] array, int arrayIndex)
        {
//            _list.CopyTo(array, arrayIndex);
            _hash.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Удаляет первый экземпляр указанного объекта из коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// Значение true, если элемент <paramref name="item"/> успешно удален из <see cref="T:System.Collections.Generic.ICollection`1"/>, в противном случае — значение false. Этот метод также возвращает значение false, если параметр <paramref name="item"/> не найден в исходном интерфейсе <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">Объект, который необходимо удалить из коллекции <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">Объект <see cref="T:System.Collections.Generic.ICollection`1"/> доступен только для чтения.</exception>
        public bool Remove(UserWord item)
        {
//            return _list.Remove(item);
            return _hash.Remove(item);
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
//                return _list.Count;
                return _hash.Count;
//                return _count;
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
    }
}