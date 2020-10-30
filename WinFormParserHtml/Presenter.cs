using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormParserHtml.Model;

namespace WinFormParserHtml
{
    public class Presenter//класс связывающий модель и представление
    {
        public event Action<string, Dictionary<string,int>> Done;//Событие сообщающее представлению о завершении работы
        private readonly HtmlLoader loader;//Объявляем все переменные необходимые для работы
        private readonly Parser parser;
        private readonly WordDetector detector;

        public Presenter()//незабываем проинициализировать 
        {
            loader = new HtmlLoader();
            parser = new Parser();
            detector = new WordDetector();
            detector.Finished += Handler;
        }
        public void SetUrl(string url)//устанавливаем url 
        {
            loader.SetUrl(url);
        }
        public async void Start()//метод начинающий работу 
        {
            var source = await loader.GetPageAsync();
            var dom = new HtmlParser();
            if (source == null)//проверяем страницу на нулевое значение, если таково, завершаем метод досрочно
            {
                MessageBox.Show("Не удалось скачать страницу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            var result = await dom.ParseDocumentAsync(source);
            detector.GetWordCount(parser.Parse(result));
        }
        private void Handler(WordDetector detector,string message)//через обработчик события передаем всю информацию 
        {//о результате работы парсера представлению
            if(Done!=null)
                Done.Invoke(message, detector.Words);
        }

    }
}
