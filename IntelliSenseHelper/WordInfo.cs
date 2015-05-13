using System;

namespace IntelliSenseHelper
{
    public struct WordInfo
    {
        public WordInfo(string line) : this()
        {
            var values = line.Split(' ');

            Word = values[0];
            Count = int.Parse(values[1]);
        }

        public WordInfo(string word, int count) : this()
        {
            Word = word;
            Count = count;
        }

        public string Word { get; private set; }
        public int Count { get; private set; }

        public override int GetHashCode()
        {
            return Word.GetHashCode();
        }

        /// <summary>
        /// ���������� ������ ��� ���� ����� ����������.
        /// </summary>
        /// <returns>
        /// ������ ���� <see cref="T:System.String"/>, ���������� ������ ��� ����.
        /// </returns>
        public override string ToString()
        {
            return Word;
        }
    }
}