﻿using System.Net.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormParserHtml.Model
{
    public class HtmlLoader//класс описывающий скачивание и сохранение страницы путем http запроса
    {
        private string Url { get; set; } //строка с url, сюда будем сохранять полученный адрес
        private readonly HttpClient client;
        public HtmlLoader(string url)//инициализируем поля
        {
            SetUrl(url);
            client = new HttpClient();
        }
        public HtmlLoader()
        {
            client = new HttpClient();
        }
        public void SetUrl(string url)
        {
            Url = url;
        }
        public async Task<string> GetPageAsync()//скачиваем страницу посредством http запроса
        {
            try
            {

                var response = await client.GetAsync(Url);
                if(response != null && response.StatusCode == HttpStatusCode.OK)//убеждаемся что ответ не 
                {//нулевой и статус код ответа равен OK
                    var source = await response.Content.ReadAsStringAsync();
                    SaveHtml(source);//не забываем сохранить страницу на диск             

                    return source;
                }
                return null;//если нет возвращаем null
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public async void SaveHtml(string html)//страница сохраняется в корневой папке проекта
        {
            using(StreamWriter sw = new StreamWriter("html.txt",true))
            {
                await sw.WriteLineAsync(html);
            }
        }
    }
}
