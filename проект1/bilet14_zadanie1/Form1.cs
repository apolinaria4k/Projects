using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bilet14_zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != null)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            List<string> result = new List<string>();
            string el = richTextBox1.Text; //записываем в переменную el текст из richTextBox
            string[] words = el.Split(new char[] { ' ', '\n', '\r', ',', '.' }, StringSplitOptions.RemoveEmptyEntries); //создаем массив, разделляя текст на слова

            for (int j = 0; j < words.Length; j++)
            { 
                //пробегаемся по массиву со словами, записываем в переменную word отдельно каждое слово
                string word = words[j];
                for(int i= 0; i<word.Length-1; i++)
                {
                    //пробегаемся по каждой букве в слове word , сравнивая её с последующей
                    string str = "";
                    if (word[i] == word[i + 1])
                    {
                        str += word[i];
                        str += word[i + 1];
                        if (result.IndexOf(str) == -1) { //в списке result ищем сочетание букв (если такое сочетание уже есть, метод IndexOf вернет индекс этого сочетания
                            // если такого сочетания нет, то метод вернет -1 ) соответственно, если данного сочетания нет, то записываем сочетание в result
                            result.Add(str);
                        }
                    }
                }               
            }

            for(int i = 0; i < result.Count; i++)  //пробегаемся по значениям result
            {
                string stroka = el; //в переменную stroka записываем весь текст el
                dataGridView1.Rows.Add(); //создаем строку в dataGridView

                //находим количество повторений одного сочетания в тексте
                //stroka.Length - длина всего текста
                //replace - заменяем сочетание (result[i]) на пустоту ("")
                //stroka.Replace(result[i], "").Length - длина текста после замен сочетаний
                //из всей длины текста вычитаем длину после replace и делим на длину сочетания (например длина сочетания "нн" будет равна 2)
                int count = (stroka.Length - stroka.Replace(result[i], "").Length) / result[i].Length;   //получаем количество повторений одного сочетания
                dataGridView1[0, i].Value = result[i]; //в первый столбец таблицы записываем сочетание result[i]
                dataGridView1[1, i].Value = count; //во второй столбец записываем количество данного сочетания
            }            
        }
    }
}
