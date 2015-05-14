using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliSenseHelper
{
    public class LetterInfo
    {
        private readonly char _letter;
        private object _parent;
        private int _count;
        public SortedList<char, LetterInfo> _letters;
        public static LetterInfo Instance = new LetterInfo('\0', null);

        private LetterInfo(char letter, LetterInfo parent)
        {
            _letter = letter;
            _letters = new SortedList<char, LetterInfo>();
            _parent = parent;
            _count = -1;
        }

//        public char Letter
//        {
//            get { return _letter; }
//        }

        private LetterInfo Add(char letter, LetterInfo parent)
        {
            LetterInfo letterInfo;
            if (_letters.TryGetValue(letter, out letterInfo))
                return letterInfo;

//            var letterInfo = _letters.Find(l => l._letter == letter);
//            if (letterInfo._letter != default(char))
//                return letterInfo;

            var li = new LetterInfo(letter, parent);
            _letters.Add(letter, li);
            return li;
        }

        public static void Add(string word, int count)
        {
            var letter = Instance.Add(word[0], Instance);
            var list = word.ToList();
            list.Remove(word[0]);
            Add(list, letter, count);
        }

        private static void Add(List<char> chars, LetterInfo letter, int count)
        {
            if (chars.Count == 0)
            {
                letter._count = count;
                return;
            }

            var newLetter = letter.Add(chars[0], letter);
            chars.Remove(chars[0]);
            Add(chars, newLetter, count);
        }

        private static readonly StringWriter Writer = new StringWriter(new StringBuilder());

        public static IEnumerable<string> Enumeration(LetterInfo letterInfo)
        {
            Writer.GetStringBuilder().Clear();
            Enumerate(letterInfo, string.Empty
#if DEBUG
                , 0
#endif
                );
            var stringReader = new StringReader(Writer.GetStringBuilder().ToString());
            string str;
            while ((str = stringReader.ReadLine()) != null)
            {
                yield return str;
            }
        }

        private static void Enumerate(LetterInfo letterInfo, string buffer
#if DEBUG
            , int depth
#endif
            )
        {
            buffer += letterInfo._letter;
            if (letterInfo._count != -1)
            {
                Writer.WriteLine(buffer.Substring(1));
            }

            for (int i = 0; i < letterInfo._letters.Count; i++)
            {
                Enumerate(letterInfo._letters.Values[i], buffer
#if DEBUG
                    , depth + 1
#endif
                    );
            }
        }

        
    }
}
