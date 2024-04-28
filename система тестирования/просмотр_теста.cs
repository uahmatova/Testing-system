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
    public partial class просмотр_теста : Form
    {
        public просмотр_теста()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);   //размеры формы
                                               //для стандратного десктопа: 1920:1080
            this.StartPosition = FormStartPosition.CenterScreen;    //располагаем форму по середине экрана
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Remove(label2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            this.Hide();
            new П_выбор().Show();
        }

        private void просмотр_теста_Load(object sender, EventArgs e)
        {
            //List<RadioButton> rdbtn = new List<RadioButton>();
            //Dictionary<int, RadioButton> radioButton = new Dictionary<int, RadioButton>();
            //int x2 = 500;
            //int y2 = 500;

            //for (int j = 0; j < k; j++)
            //{
            //    //MessageBox.Show($"Создали {j}-ю кнопку");
            //    radioButton[j] = new RadioButton();
            //    radioButton[j].AutoSize = true;
            //    radioButton[j].Text = $"Вариант круглой кнопки { j + 1}";
            //    radioButton[j].Location = new Point(x2, y2);

            //    this.Controls.Add(radioButton[j]);
            //    y2 += 20;
            //}
            var dir = new DirectoryInfo("C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты");
            FileInfo[] files = dir.GetFiles("*.dat");
            int k = files.Length;
            for (int i = 1; i <=k; i++)
            {
                listBox1.Items.Add(i);
            }
        }
        //Label label1 = new Label();
        private void button1_Click(object sender, EventArgs e)
        {
            //listBox3.Items.Clear();
            textBox1.Clear();
            List<Банк_заданий.Question> questions;
            BinaryFormatter formatter = new BinaryFormatter();
            var dir = new DirectoryInfo("C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты");
            FileInfo[] files = dir.GetFiles("*.dat");
            int k = files.Length;
            int number;
            var u = int.TryParse(listBox1.SelectedItem.ToString(), out number);
            string text = "";
            for (int i = 1; i <= k; i++)
            {
                if (i == number)
                {
                    using (FileStream f = new FileStream($"C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты\\{i}.dat", FileMode.Open))
                    {
                        questions = (List<Банк_заданий.Question>)formatter.Deserialize(f);
                        f.Close();
                    }
                    for (int j =0; j <questions.Count(); j++)
                    {
                        //listBox3.Items.Add($"Вопрос №{j + 1}: {questions[j].QUESTION}");
                        //listBox3.Items.Add($"Ответ: {questions[j].ANSWER}");
                        //listBox3.Items.Add("\n");
                        text += $"Вопрос №{j + 1}: {questions[j].QUESTION}" + Environment.NewLine + $"Ответ: { questions[j].ANSWER}" + Environment.NewLine + Environment.NewLine;
                    }
                }
            }
            //this.listBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            //this.listBox3.MeasureItem += lst_MeasureItem;
            //this.listBox3.DrawItem += lst_DrawItem;

            textBox1.Text += text;
            //MessageBox.Show($"{text}");
            //label2.Location = new Point(250, 200);
            //label2.MaximumSize = new Size(950, 500);
            //label2.AutoSize = true;
            //textBox1.Font = new Font("XO Courser", 16);
            //label1.ForeColor = Color.DarkMagenta;
            //label2.Size = new Size(350, 400);
            this.Controls.Add(textBox1);
        }

        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, listBox1.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }
    }
}
