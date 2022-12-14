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

namespace ЛАБ10_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("c:\\temp"))
            {
                Directory.CreateDirectory("c:\\temp");
            }
            Directory.CreateDirectory("c:\\temp\\K1");
            Directory.CreateDirectory("c:\\temp\\K2");
            StreamWriter sw = new StreamWriter("c:\\temp\\K1\\t1.txt");
            sw.Write("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            sw.Close();
            sw = new StreamWriter("c:\\temp\\K1\\t2.txt");
            sw.Write("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            sw.Close();
            sw = new StreamWriter("c:\\temp\\K2\\t3.txt");
            StreamReader sr = new StreamReader("c:\\temp\\K1\\t1.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sr = new StreamReader("c:\\temp\\K1\\t2.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sw.Close();
            richTextBox1.Text = "Созданные файлы:\n";
            DirectoryInfo d1inf = new DirectoryInfo("c:\\temp\\K1");
            FileInfo[] f1inf = d1inf.GetFiles();
            DirectoryInfo d2inf = new DirectoryInfo("c:\\temp\\K2");
            FileInfo[] f2inf = d2inf.GetFiles();
            richTextBox1.Text += "Файлы папки К1:\n";
            foreach (FileInfo f1i in f1inf)
            {
                richTextBox1.Text += "Полный путь файла: " + f1i.FullName + "\nВремя создания: " + f1i.CreationTime + "\nВремя последнего изменения: " +
                    f1i.LastWriteTime + "\nОбъём файла в байтах: " + f1i.Length + "\n";
            }
            richTextBox1.Text += "Файлы папки К2:\n";
            foreach (FileInfo f2i in f2inf)
            {
                richTextBox1.Text += "Полный путь файла: " + f2i.FullName + "\nВремя создания: " + f2i.CreationTime + "\nВремя последнего изменения: " +
                    f2i.LastWriteTime + "\nОбъём файла в байтах: " + f2i.Length + "\n";
            }
            File.Move("c:\\temp\\K1\\t2.txt", "c:\\temp\\K2\\t2.txt");
            File.Copy("c:\\temp\\K1\\t1.txt", "c:\\temp\\K2\\t1.txt");
            Directory.Move("c:\\temp\\K2", "c:\\temp\\ALL");
            Directory.Delete("c:\\temp\\K1", true);
            DirectoryInfo dinf = new DirectoryInfo("c:\\temp\\ALL");
            FileInfo[] finf = dinf.GetFiles();
            richTextBox1.Text += "Содержимое папки ALL:\n";
            foreach (FileInfo fi in finf)
            {
                richTextBox1.Text += "Полный путь файла: " + fi.FullName + "\nВремя создания: " + fi.CreationTime + "\nВремя последнего изменения: " +
                    fi.LastWriteTime + "\nОбъём файла в байтах: " + fi.Length + "\n";
            }
        }
    }
}
