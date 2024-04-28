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
    public partial class Тестирование : Form
    {
        public Тестирование()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public static List<Банк_заданий.Question> test;
        int i = 0;
        public int count_right_answer;
        public static Dictionary<int, Dictionary<string, int>> База_прошедших = new Dictionary<int, Dictionary<string, int>> { };
        public static string fio;
        private void Тестирование_Load(object sender, EventArgs e)
        {
            Deserial();
            count_right_answer = 0;
            groupBox1.Text = $"Вопрос №{i + 1}:";
            Создание_вопроса(i);
            Создание_ответа_открытый();
        }

        public static int varik;    //0 - тест с вариантом, 1 - случайный тест
        public static int number_test;
        public static void Deserial()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (varik == 0)
            {
                fio = ФИО.fio;
                number_test = ФИО.number;
            }
            else
            {
                fio = Случайный_вариант.fio;
                number_test = Случайный_вариант.number;
            }
            using (FileStream f = new FileStream($"C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты\\{number_test}.dat",
                FileMode.OpenOrCreate))
            {
                test = (List<Банк_заданий.Question>)formatter.Deserialize(f);
                f.Close();
            }
        }

        TextBox textBox_Answer_Открытый;
        Label label_вопрос;
        private void Создание_вопроса(int number)
        {
            label_вопрос = new Label();
            //label_вопрос.Text = "это вопрос?";
            label_вопрос.Text = $"{test[number].QUESTION}";
            label_вопрос.Location = new Point(50, 130);
            label_вопрос.MaximumSize = new Size(850, 0);
            label_вопрос.AutoSize = true;
            label_вопрос.Font = new Font("Verdana", 18);
            label_вопрос.Size = new Size(350, 40);
            groupBox1.Controls.Add(label_вопрос);
        }
        private void Создание_ответа_открытый()
        {
            textBox_Answer_Открытый = new TextBox();
            textBox_Answer_Открытый.Location = new Point(50, 260);
            textBox_Answer_Открытый.Font = new Font("Verdana", 18);
            textBox_Answer_Открытый.Size = new Size(400, 40);
            //textBox_Answer_Открытый.MaxLength = 40;
            groupBox1.Controls.Add(textBox_Answer_Открытый);
            //Текст_Ответа.Add(textBox_Answer_Открытый);//добавляем текст 
        }
        //private void Создание_кнопки_следующий()
        //{
        //    Button button1 = new Button();
        //    button2.Location = new Point(750, 730);
        //    button2.Size = new Size(318, 88);
        //    button2.Font = new Font("Candara", 17);
        //    button2.ForeColor = Color.BlueViolet;
        //    //button2.Font.Bold = true;
        //    button2.Text = "Следующий вопрос";
        //    this.Controls.Add(button1);
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();

            i++;    //переходим к следующему вопросу
            if (i < test.Count)
            {
                if ((textBox_Answer_Открытый.Text).ToLower() == test[i - 1].ANSWER.ToLower())     //если введенный ответ совпадет с ответом из базы
                {
                    count_right_answer++;
                }
                groupBox1.Text = $"Вопрос №{i + 1}:";
                groupBox1.Font = new Font("Verdana", 18);
                Создание_вопроса(i);
                Создание_ответа_открытый();
            }
            else
            {
                this.Controls.Remove(button1);
                if ((textBox_Answer_Открытый.Text).ToLower() == test[i - 1].ANSWER.ToLower())     //если введенный ответ совпадет с ответом из базы
                {
                    count_right_answer++;
                }
                //MessageBox.Show($"Правильных ответов: {count_right_answer}");
                groupBox1.Controls.Clear();
                groupBox1.Text = "Молодец!\nТы закончил тест!";
                Label result = new Label();
                result.Location = new Point(10, 195);
                result.MaximumSize = new Size(750, 0);
                result.AutoSize = true;
                result.ForeColor = Color.Blue;
                result.Font = new Font("Verdana", 18);
                result.Size = new Size(350, 30);
                result.Text = $"Твой результат: {count_right_answer} из {i}";
                groupBox1.Controls.Add(result);

                PictureBox pictureBox1 = new PictureBox();
                //pictureBox1.Image = Properties.Resources.хомяк;
                Random rand = new Random();

                //string path = @"d:\pictures\";
                //string filename = rand.Next(1, 2).ToString();
                //pictureBox1.Image = new Bitmap(filename + ".jpg");

                Image[] img = new Image[8];

                img[0] = Properties.Resources.хомяк;//Image.FromFile("pic0.png");
                img[1] = Properties.Resources.лягушка;
                img[2] = Properties.Resources.кот;
                img[3] = Properties.Resources.бяк;
                img[4] = Properties.Resources.воробышек;
                img[5] = Properties.Resources.змеяраф;
                img[6] = Properties.Resources.энергия;
                img[7] = Properties.Resources.прелесть;

                int r = rand.Next(0, 7);
                pictureBox1.Image = img[r];
                pictureBox1.Location = new Point(450, 35);
                pictureBox1.AutoSize = true;
                groupBox1.Controls.Add(pictureBox1);
                try
                {
                    База_прошедших.Add(number_test, new Dictionary<string, int> { { fio, count_right_answer } });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Вы уже проходили этот тест, результат не будет засчитан");
                }
                //MessageBox.Show($"База ключ {База_прошедших.ElementAt(0).Key}");
            }    
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
