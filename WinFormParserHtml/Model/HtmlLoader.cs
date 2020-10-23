using System.Net.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormParserHtml.Model
{
    public class HtmlLoader
    {
        public string Url { get; set; }
        HttpClient client;
        public HtmlLoader(string url)
        {
            Url = url;
            client = new HttpClient();
        }
        public async Task<string> GetPageAsync()
        {

            var response = await client.GetAsync(Url);
            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var source = await response.Content.ReadAsStringAsync();
                SaveHtml(source);                

                return source;
            }
            throw new Exception("Результат Http запроса оказался null или другая ошибка связанная с этим запросом");
        }
        public async void SaveHtml(string html)
        {
            using(StreamWriter sw = new StreamWriter("html.txt"))
            {
                await sw.WriteLineAsync(html);
            }
        }
    }
}
