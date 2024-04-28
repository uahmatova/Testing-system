using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ТП_работает
{
    public partial class Добавить_вопрос : Form
    {
        public Добавить_вопрос()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);   //размеры формы
                                               //для стандратного десктопа: 1920:1080
            this.StartPosition = FormStartPosition.CenterScreen;    //располагаем форму по середине экрана
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Добавить_вопрос_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            this.Hide();
            new П_выбор().Show();
        }

        private void button1_Click(object sender, EventArgs e)       //ДОБАВИТЬ ПРОВЕРКУ НА СОДЕРЖАНИЕ ТАКОГО ВОПРОСА В БАЗЕ(?)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Все поля должны быть заполнены", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Банк_заданий.Question new_que = new Банк_заданий.Question(textBox1.Text, textBox2.Text);
                MessageBox.Show("Ваш вопрос успешно добавлен в базу.");
                BinaryFormatter formatter = new BinaryFormatter();
                var dir = new DirectoryInfo("Вопросы");
                FileInfo[] files = dir.GetFiles("*.dat");
                int k = files.Length + 1;
                string path = $"Вопросы\\{k}.dat";
                using (FileStream f = new FileStream(path, FileMode.Create))
                {
                    formatter.Serialize(f, new_que);
                    f.Close();
                }
                Банк_заданий.Deserial();
                Array.Resize(ref Банк_заданий.mass, Банк_заданий.mass.Length + 1);  //увеличиваем длину массива, чтоб добавить еще вопросец
                Банк_заданий.mass[k - 1] = new_que;     //добавили вопрос в общий массив  = > файл со всеми вопросами и ответами
                Банк_заданий.Serial(Банк_заданий.mass);
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
