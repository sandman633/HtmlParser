using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormParserHtml.Model
{
    public class Parser
    {
        public string[] Parse(IHtmlDocument doc)// Метод для обработки html документа,
        {//вычлиняющий текстовый контент из тега body
            var text = doc.QuerySelectorAll("body")
                         .Select(x => x.TextContent
                         .Trim(new char[] 
                         {'-',' ', ',', '.', '!', '?','"', ';', ':', 
                         '[', ']', '(', ')', '\n', '\r', '\t'}));// удаляем ненужные нам символы из текста

            return GetList(text);
        }
        private string[] GetList(IEnumerable<string> text)//метод занимающийся обработкой текста 
        {//и разделением его на отдельные слова
            string newstr = "";
            foreach (string s in text)
            {
                if (s != "")
                {
                    newstr += s + ' ';
                }
            }
            text = newstr.Split(new char[] {'-',' ', ',', '.', '!', '?','"', ';',
                                          ':', '[', ']', '(', ')', '\n', '\r', '\t'});
            List<string> List = new List<string>(text);
            List.RemoveAll(x => string.IsNullOrEmpty(x));
            List.RemoveAll(x => x == "\n");
            return List.ToArray();
        }
        public Dictionary<string,int> GetWordCount(string[] words)
        {
            Dictionary<string, int> Words = new Dictionary<string, int>();
            foreach(string s in words)
            {
                upperword = s.ToUpper();
                if(Words.TryGetValue(s.ToUpper(),out int count))
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
