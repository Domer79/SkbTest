using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliSenseHelper
{
    public class WordInfo2
    {
        private readonly string _word;
        private readonly int _count;

        public WordInfo2(string word, int count)
        {
            _word = word;
            _count = count;
        }

        public WordInfo2(string line)
        {
            var values = line.Split(' ');

            _word = values[0];
            _count = int.Parse(values[1]);
        }

        public string Word
        {
            get { return _word; }
        }

        public int Count
        {
            get { return _count; }
        }

    }

    public struct LetterInfo
    {
        private readonly char _letter;
        public List<LetterInfo> _letters;
        public static LetterInfo Instance = new LetterInfo('\0');

        private LetterInfo(char letter)
        {
            _letter = letter;
            _letters = new List<LetterInfo>();
        }

//        public char Letter
//        {
//            get { return _letter; }
//        }

        private LetterInfo Add(char letter)
        {
            var letterInfo = _letters.Find(l => l._letter == letter);
            if (letterInfo._letter != default(char))
                return letterInfo;

            var li = new LetterInfo(letter);
            _letters.Add(li);
            return li;
        }

        public static void Add(string word)
        {
            var letter = Instance.Add(word[0]);
            var list = word.ToList();
            list.Remove(word[0]);
            Add(list, letter);
        }

        private static void Add(List<char> chars, LetterInfo letter)
        {
            if (chars.Count == 0)
            {
                return;
            }

            var newLetter = letter.Add(chars[0]);
            chars.Remove(chars[0]);
            Add(chars, newLetter);
        }
    }
}
