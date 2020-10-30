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
            presenter.Done += Presenter_Started;//подготавливаем к работе при загрузке формы

        }

        private void Presenter_Started(string message, Dictionary<string,int> words)//метод-обработчик получающий результат работы парсера
        {
            MessageBox.Show(message, "END", MessageBoxButtons.OK, MessageBoxIcon.Information);//настраиваем датагрид и выдаем сообщение о окончании работы
            dataGridView1.DataSource = words.OrderByDescending(key => key.Value).ToArray();
            dataGridView1.Columns[0].HeaderText = "Слова";
            dataGridView1.Columns[1].HeaderText = "Количество";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* При нажатии на кнопку проверяем значение текстового поля на пустоту 
             * и на правильность введеного url 
             * Если все правильно - запускаем работу парсера
             * В случае неудачи показываем окошко с сообщением*/
            if(!string.IsNullOrEmpty(textBox1.Text)&&Helper.CheckUrl(textBox1.Text))
            {
                presenter.SetUrl(textBox1.Text);
                presenter.Start();
            }
            else
            {
                MessageBox.Show("url Введен некорректно","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
