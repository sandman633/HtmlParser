using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormParserHtml.Model;

namespace WinFormParserHtml
{
    public class Presenter
    {
        public event Action<string, Dictionary<string,int>> Started;
        private HtmlLoader loader;
        private Parser parser;
        private WordDetector detector;

        public Presenter()
        {
            loader = new HtmlLoader();
            parser = new Parser();
            detector = new WordDetector();
            detector.Ended += Handler;
        }
        public void GetUrl(string url)
        {
            loader.SetUrl(url);
        }
        public async void Start()
        {
            var source = await loader.GetPageAsync();
            var dom = new HtmlParser();
            var result = await dom.ParseDocumentAsync(source);
            detector.GetWordCount(parser.Parse(result));
        }
        private void Handler(WordDetector detector,string message)
        {
            if(Started!=null)
                Started.Invoke(message, detector.Words);
        }

    }
}
