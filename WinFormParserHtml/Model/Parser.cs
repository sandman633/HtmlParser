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
            string newstr = null;
            var str = doc.QuerySelectorAll("a")
                         .Select(x => x.TextContent)
                         .Select(x => x.Trim(new char[] { '!', '}', '{','(',')','.',','}));
            foreach(string sr in str)
            {
                newstr += ' ' + sr;
            }
            string[] s = newstr.Split(' ');
            foreach(string sr in s)
            {
                sr.Trim(' ');
            }
            return s;
        }
    }
}
