using AngleSharp.Dom;
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
            doc.QuerySelectorAll("script")
                .Text(" ");
            doc.QuerySelectorAll("noscript").Text(" ");//удаляем все скрипты если они есть
            var text = doc.QuerySelectorAll("body")
                         .Select(x => x.TextContent
                         .Trim(new char[] 
                         {'-',' ', ',', '.', '!', '?','"', ';', ':', 
                         '[', ']', '(', ')', '\n', '\r', '\t'}));// удаляем ненужные нам символы из текста

            return GetList(text);
        }
        private string[] GetList(IEnumerable<string> text)//метод занимающийся обработкой текста 
        {//и разделением его на отдельные слова
            string newlist = "";//создаем переменную для записи слов
            foreach (string s in text)
            {
                if (s != "")
                {
                    newlist += s + ' ';/*проходимся по коллекции и записываем 
                                        * туда весь текст с разделитем в случае если "текс" равен одному слову*/
                }
            }
            text = newlist.Split(new char[] {'-',' ', ',', '.', '!', '?','"', ';',
                                          ':', '[', ']', '(', ')', '\n', '\r', '\t'});//делим текст на слова
            List<string> List = new List<string>(text);//создаем лист,т.к. с ним легче работать
            List.RemoveAll(x => string.IsNullOrEmpty(x));
            List.RemoveAll(x => x == "\n");//избавляемся от оставшихся пустот и пробелов
            return List.ToArray();//возвращаем  массив
        }
    }
}
