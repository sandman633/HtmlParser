using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormParserHtml.Model;

namespace WinFormParserHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HtmlLoader loader = new HtmlLoader("https://www.simbirsoft.com/");
        Parser parser = new Parser();
        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }
        private async void Start()
        {
            var source = await loader.GetPageAsync();
            var dom = new HtmlParser();
            var result = await dom.ParseDocumentAsync(source);
            listBox1.Items.AddRange(parser.Parse(result));
            dataGridView1.DataSource = parser.GetWordCount(parser.Parse(result)).ToArray();
        }
    }
}
