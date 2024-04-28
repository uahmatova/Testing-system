using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ТП_работает
{
    public partial class Случайный_вариант : Form
    {
        public Случайный_вариант()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);   //размеры формы
                                               //для стандратного десктопа: 1920:1080
            this.StartPosition = FormStartPosition.CenterScreen;    //располагаем форму по середине экрана
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new С_выбор().Show();
        }

        public static int number;   //для номера варианта
        public static string[] FIO;
        public static string fio;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Введите данные", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if else (textBox2.Text )       //ДОБАВИТЬ ПРОВЕРКУ НА БУКОВКИ
            //{ 

            //}
            else
            {
                fio = textBox1.Text;
                FIO = fio.Split(" ");
                if (FIO.Length < 2 || FIO.Length >= 3)
                    MessageBox.Show("Проверьте корректность данных ФИО", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    //MessageBox.Show(FIO[0], FIO[1]);
                    Тестирование.varik = 1;
                    var rand = new Random();
                    var dir = new DirectoryInfo("Тесты");
                    FileInfo[] files = dir.GetFiles("*.dat");
                    int k = files.Length;
                    number = rand.Next(1, k);
                    new Тестирование().Show();
                    this.Hide();
                }
            }
        }
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char simvol = e.KeyChar;
            if (!(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == 32 || e.KeyChar == 150)) //русские буквы, backspace
            {
                e.Handled = true;
                MessageBox.Show("Можно вводить только буквы", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }
    }
}
