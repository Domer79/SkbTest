using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelliSenseHelper
{
    public struct UserWord
    {
        private readonly string _word;
//        private readonly int _number;
//        private readonly List<WordInfo> _similarList;

        public UserWord(string word/*, int number*/)
        {
            _word = word;
//            _number = number;
//            _similarList = new List<WordInfo>();
//            InitSimilarList();
        }

//        private async void InitSimilarList()
//        {
//            List<WordInfo> similarList1 = _similarList;
//            var number = _number;
//            await GetSimilarList().ContinueWith((wi) =>
//            {
//                similarList1.AddRange(wi.Result);
//                string s = number + "\r\n";
//                Console.WriteLine(similarList1.Aggregate(s, (c,n) => c + "\r\n" + n));
//                Console.WriteLine();
//            });
//        }
//
//        private async Task<IEnumerable<WordInfo>> GetSimilarList()
//        {
//            var word = _word;
//            var enumerable = await Task.Run(() => Helper.WordInfoCollection.Where(wi => wi.Word.StartsWith(word))
////                .OrderBy(wi => wi.Count)
//                .Take(10));
//            return enumerable;
//        }

        public string Word
        {
            get { return _word; }
        }

//        public List<WordInfo> SimilarList
//        {
//            get { return _similarList; }
//        }
    }
}