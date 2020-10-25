using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormParserHtml.Model
{
    class WordDetector
    {
        private Dictionary<string, int> Words;
        public WordDetector()
        {
            Words = new Dictionary<string, int>();
        }
        public Dictionary<string, int> GetWordCount(string[] words)
        {
            foreach (string s in words)
            {
                if (Words.TryGetValue(s.ToUpper(), out int count))
                {
                    Words[s.ToUpper()] = ++count;
                }
                else
                {
                    Words.Add(s.ToUpper(), 1);
                }
            }
            return Words;

        }
    }
}
