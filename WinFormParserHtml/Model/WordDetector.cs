using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormParserHtml.Model
{
    public class WordDetector//класс описывающий работу вычисления количества каждого слова на странице
    {
        private Dictionary<string, int> Words;//словарь в котором будут хранится слова и их количество
        public WordDetector()
        {
            Words = new Dictionary<string, int>();
        }
        public Dictionary<string, int> GetWordCount(string[] words)//метод сортирующий слова по словарю
        {
            foreach (string s in words)
            {
                if (Words.TryGetValue(s.ToUpper(), out int count))//если слово существует в словаре то мы добавляем 1+ к его количеству
                {
                    Words[s.ToUpper()] = ++count;
                }
                else//если такого слова нет то мы создаем новое слово в словаре с количеством 1
                {
                    Words.Add(s.ToUpper(), 1);
                }
            }
            return Words;
        }
    }
}
