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

namespace Угрюмова_практика_16
{
    public partial class Form1 : Form
    {
        SubjectIndex sj;
        List<SubjectIndex> subInd = new List<SubjectIndex>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("cat.png");
            StreamReader sr = new StreamReader("text.txt");
            try
            {
                listBox1.Sorted = true;
                while (!sr.EndOfStream)
                {
                    string[] text = sr.ReadLine().Split(' ');
                    string text1 = text[0];
                    int[] page = new int[text.Length - 1];

                    for (int i = 1; i < text.Length; i++)
                    {
                        page[i - 1] = int.Parse(text[i]);
                    }

                    sj = new SubjectIndex(text1, page);
                    subInd.Add(sj);
                    listBox1.Items.Add(sj.Info());
                }

                sr.Close();
            }
            catch
            {
                MessageBox.Show("не получилось выполнить выгрузку из файла, но не переживайте, приложение будет работать и при следующем входе покажет добавленные указатели!", "Сообщение");
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = true;
            string text = textBox1.Text;
            string[] text2 = textBox2.Text.Split(' ');
            int[] page = new int[text2.Length];
            bool find = false;
            bool find2 = false;


            if (text.IndexOf(" ") > 0) MessageBox.Show("для добавление слова не должно быть больше 1 слова или пробела", "Сообщение");
            else
            {
                try
                {
                    for (int i = 0; i < page.Length; i++)
                    {
                        page[i] = int.Parse(text2[i]);
                    }


                    Array.Sort(page);
                    sj = new SubjectIndex(text, page);

                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (sj.word == subInd[i].word) find = true;
                    }
                    for (int i = 0; i < sj.word.Length; i++)
                    {
                        if (sj.word[i] == '0' || sj.word[i] == '1' || sj.word[i] == '2' || sj.word[i] == '3' || sj.word[i] == '4' || sj.word[i] == '5' || sj.word[i] == '6' || sj.word[i] == '7' || sj.word[i] == '8' || sj.word[i] == '9') find2 = true;
                    }

                    if (find == true) MessageBox.Show("данное слово уже есть", "Сообщение");
                    else
                    {
                        if (find2 == true) MessageBox.Show("в слове есть цифры", "Сообщение");
                        else
                        {
                            listBox1.Items.Add(sj.Info());
                            subInd.Add(sj);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("неправильно введены страницы", "Сообщение");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int i = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(i);
                subInd.RemoveAt(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = File.CreateText("text.txt");

            for (int i = 0; i < subInd.Count; i++)
            {
                sw.WriteLine(subInd[i].Info());
            }
            sw.Close();

            Application.Exit();
        }
    }
}
