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
        public string[] Parse(IHtmlDocument doc)
        {
            var str = doc.QuerySelectorAll("body")
                         .Select(x => x.TextContent.Trim(new char[] {'-',' ', ',', '.', '!', '?','"', ';', ':', '[', ']', '(', ')', '\n',
'\r', '\t'}));
            string newstr ="";
            foreach(string s in str)
            {
                if (s!="")
                {
                    newstr += s + ' ';
                }
            }
            str = newstr.Split(new char[] {'-',' ', ',', '.', '!', '?','"', ';', ':', '[', ']', '(', ')', '\n',
'\r', '\t'});
            str = GetList(str);
            return str.ToArray();
        }
        public string[] GetList(IEnumerable<string> words)
        {
            List<string> List = new List<string>(words);
            List.RemoveAll(x => string.IsNullOrEmpty(x));
            List.RemoveAll(x => x == "\n");
            return List.ToArray();
        }
        public Dictionary<string,int> GetWordCount(string[] words)
        {
            Dictionary<string, int> Words = new Dictionary<string, int>();
            foreach(string s in words)
            {
                if(Words.TryGetValue(s,out int count))
                {
                    Words[s] = ++count;
                }
                else
                {
                    Words.Add(s, 1);
                }
            }
            return Words;
        }
    }
}
