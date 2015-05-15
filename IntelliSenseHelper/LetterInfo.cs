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
        private readonly LetterInfo _parent;
        public int Count;
        private readonly SortedList<char, LetterInfo> _letters;
        public static LetterInfo Instance = new LetterInfo('\0', null);

        private LetterInfo(char letter, LetterInfo parent)
        {
            _letter = letter;
            _letters = new SortedList<char, LetterInfo>();
            _parent = parent;
            Count = -1;
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
                letter.Count = count;
                return;
            }

            var newLetter = letter.Add(chars[0], letter);
            chars.Remove(chars[0]);
            Add(chars, newLetter, count);
        }

        public string GetWord()
        {
            var stack = new Stack<char>();
            return GetWord(stack, this);
        }

        private static string GetWord(Stack<char> stack, LetterInfo letterInfo)
        {
            while (true)
            {
                if (letterInfo._letter == default(char))
                    return new string(stack.ToArray());

                stack.Push(letterInfo._letter);
                letterInfo = letterInfo._parent;
            }
        }

        public static IEnumerable<LetterInfo> StartsWith(string word)
        {
            var letterInfo = GetLetterInfoByWord(word);
            return letterInfo == null ? new LetterInfo[] {} : Enumeration(letterInfo);
        }

        private static LetterInfo GetLetterInfoByWord(string word)
        {
            return GetLetterInfo(word.ToList(), Instance);
        }

        private static LetterInfo GetLetterInfo(List<char> chars, LetterInfo letterInfo)
        {
            if (chars.Count == 0)
                return letterInfo;

            LetterInfo nextLetterInfo;
            if (!letterInfo._letters.TryGetValue(chars[0], out nextLetterInfo))
                return null;
            
            chars.Remove(chars[0]);
            return GetLetterInfo(chars, nextLetterInfo);
        }

        /// <summary>
        /// Возвращает строку, которая представляет текущий объект.
        /// </summary>
        /// <returns>
        /// Строка, представляющая текущий объект.
        /// </returns>
        public override string ToString()
        {
            return GetWord();
        }

        private static readonly List<LetterInfo> EnumerationList = new List<LetterInfo>();

        public static IEnumerable<LetterInfo> Enumeration(LetterInfo letterInfo)
        {
            EnumerationList.Clear();
            Enumerate(letterInfo, string.Empty
#if DEBUG
                , 0
#endif
                );
            return EnumerationList.OrderByDescending(li => li.Count);
        }

        private static void Enumerate(LetterInfo letterInfo, string buffer
#if DEBUG
            , int depth
#endif
            )
        {
            buffer += letterInfo._letter;
            if (letterInfo.Count != -1)
            {
                EnumerationList.Add(letterInfo);
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
