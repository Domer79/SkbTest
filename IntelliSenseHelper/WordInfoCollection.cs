using System.Collections;
using System.Collections.Generic;

namespace IntelliSenseHelper
{
    public class WordInfoCollection : ICollection<WordInfo>
    {
        private readonly int _count;
        private readonly List<WordInfo> _list = new List<WordInfo>();

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="T:System.Object"/>.
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
        /// ��������� ������� � ��������� <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">������, ����������� � ��������� <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">������ <see cref="T:System.Collections.Generic.ICollection`1"/> �������� ������ ��� ������.</exception>
        public void Add(WordInfo item)
        {
//            _list.Add(item);
//            _hash.Add(item);
            _list.Add(item);
        }

        /// <summary>
        /// ������� ��� �������� �� ��������� <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">������ <see cref="T:System.Collections.Generic.ICollection`1"/> �������� ������ ��� ������.</exception>
        public void Clear()
        {
//            _list.Clear();
//            _hash.Clear();
            _list.Clear();
        }

        /// <summary>
        /// ����������, �������� �� ��������� <see cref="T:System.Collections.Generic.ICollection`1"/> ��������� ��������.
        /// </summary>
        /// <returns>
        /// �������� true, ���� �������� <paramref name="item"/> ������ � ��������� <see cref="T:System.Collections.Generic.ICollection`1"/>; � ��������� ������ � �������� false.
        /// </returns>
        /// <param name="item">������, ������� ��������� ����� � <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(WordInfo item)
        {
//            return _list.Contains(item);
//            return _hash.Contains(item);
            return _list.Contains(item);
        }

        /// <summary>
        /// �������� �������� <see cref="T:System.Collections.Generic.ICollection`1"/> � ������ <see cref="T:System.Array"/>, ������� � ���������� ������� <see cref="T:System.Array"/>.
        /// </summary>
        /// <param name="array">���������� ������ <see cref="T:System.Array"/>, � ������� ���������� �������� �� ���������� <see cref="T:System.Collections.Generic.ICollection`1"/>. ������ <see cref="T:System.Array"/> ������ ����� ����������, ������������ � ����.</param><param name="arrayIndex">������������� �� ���� ������ � ������� <paramref name="array"/>, ����������� ������ �����������.</param><exception cref="T:System.ArgumentNullException">�������� <paramref name="array"/> ����� �������� null.</exception><exception cref="T:System.ArgumentOutOfRangeException">�������� ��������� <paramref name="arrayIndex"/> ������ 0.</exception><exception cref="T:System.ArgumentException">���������� ��������� � �������� ��������� <see cref="T:System.Collections.Generic.ICollection`1"/> ��������� ��������� �����, ������� � ������� <paramref name="arrayIndex"/> �� ����� ������� ���������� <paramref name="array"/>.</exception>
        public void CopyTo(WordInfo[] array, int arrayIndex)
        {
//            _list.CopyTo(array, arrayIndex);
//            _hash.CopyTo(array, arrayIndex);
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// ������� ������ ��������� ���������� ������� �� ��������� <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// �������� true, ���� ������� <paramref name="item"/> ������� ������ �� <see cref="T:System.Collections.Generic.ICollection`1"/>, � ��������� ������ � �������� false. ���� ����� ����� ���������� �������� false, ���� �������� <paramref name="item"/> �� ������ � �������� ���������� <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">������, ������� ���������� ������� �� ��������� <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">������ <see cref="T:System.Collections.Generic.ICollection`1"/> �������� ������ ��� ������.</exception>
        public bool Remove(WordInfo item)
        {
//            return _list.Remove(item);
//            return _hash.Remove(item);
            return _list.Remove(item);
        }

        /// <summary>
        /// �������� ����� ���������, ������������ � ���������� <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// ����� ���������, ������������ � ���������� <see cref="T:System.Collections.Generic.ICollection`1"/>.
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
        /// �������� ��������, �����������, �������� �� <see cref="T:System.Collections.Generic.ICollection`1"/> ������ ��� ������.
        /// </summary>
        /// <returns>
        /// �������� true, ���� <see cref="T:System.Collections.Generic.ICollection`1"/> �������� ������ ��� ������; � ��������� ������ � �������� false.
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
        /// ���������� ��� ������� � ���������� ��������, ������������, ��� ���� ������ ������ ��� ������ ������� ��� ����� ���.
        /// </summary>
        /// <returns>
        /// �������� ����� �����, ������� ���������� ������������� �������� <paramref name="x"/> � <paramref name="y"/>, ��� �������� � ��������� �������. ��������  ��������  ������ ���� �������� ��������� <paramref name="x"/> ������ �������� ��������� <paramref name="y"/>. Zero �������� ��������� <paramref name="x"/> ����� �������� ��������� <paramref name="y"/>. ������ ����. �������� <paramref name="x"/> ������ �������� <paramref name="y"/>.
        /// </returns>
        /// <param name="x">������ ������������ ������.</param><param name="y">������ ������������ ������.</param>
        public int Compare(WordInfo x, WordInfo y)
        {
            return string.Compare(x.Word, y.Word, System.StringComparison.Ordinal);
        }
    }
}