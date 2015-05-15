using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelliSenseHelper
{
    public class UserWord
    {
        public readonly string Word;

        public UserWord(string word)
        {
            Word = word;
        }

        public List<LetterInfo> SimilarWords = new List<LetterInfo>();

        /// <summary>
        /// Возвращает строку, которая представляет текущий объект.
        /// </summary>
        /// <returns>
        /// Строка, представляющая текущий объект.
        /// </returns>
        public override string ToString()
        {
            return ToString("");
        }

        /// <summary>
        /// "" - возврщает слово, 
        /// "words" - Возвращает слова, которые начинаются с этого слова, 
        /// "detail" - Возвращает слова, которые начинаются с этого слова, с детальной информацией
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            switch (format)
            {
                case "":
                {
                    return Word;
                }
                case "words":
                {
                    return SimilarWords.Aggregate("", (c, n) => c + "\r\n" + n) + "\r\n";
                }
                case "detail":
                {
                    return SimilarWords.Aggregate("\r\n" + Word + "\r\n------------------------", (c, n) => c + "\r\n" + n.ToString() + " " + n.Count) + "\r\n";
                }
                default:
                    return Word;
            }
        }

        /// <summary>
        /// Играет роль хэш-функции для определенного типа.
        /// </summary>
        /// <returns>
        /// Хэш-код для текущего объекта <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Word.GetHashCode();
        }
    }
}