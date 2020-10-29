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
        Presenter presenter;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            presenter = new Presenter();
            presenter.Done += Presenter_Started;
        }

        private void Presenter_Started(string message, Dictionary<string,int> words)
        {
            MessageBox.Show(message, "END", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = words.ToArray();
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text)&&)
            {
                presenter.GetUrl(textBox1.Text);
                presenter.Start();
            }
        }
    }
}
