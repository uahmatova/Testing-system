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
    public partial class ФИО : Form
    {
        public ФИО()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public static string[] FIO;
        private void button2_Click(object sender, EventArgs e)
        {
            new С_выбор().Show();
            this.Hide();
        }
        public static int number;   //для номера варианта
        public static string fio;
        private void button1_Click(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo("C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты");
            FileInfo[] files = dir.GetFiles("*.dat");
            int k = files.Length;
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Введите данные", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (int.Parse(textBox2.Text) > k) 
            {
                MessageBox.Show("Такого варианта не существует.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                fio = textBox1.Text;
                FIO = fio.Split(" ");
                if (FIO.Length < 2 || FIO.Length >= 3)
                    MessageBox.Show("Проверьте корректность данных ФИО", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    
                        //MessageBox.Show(FIO[0], FIO[1]);
                        Тестирование.varik = 0;
                        number = int.Parse(textBox2.Text);
                        new Тестирование().Show();
                        this.Hide();
                   
                }
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 150) //цифры, backspace
            {
                e.Handled = true;
                MessageBox.Show("Можно вводить только цифры", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
