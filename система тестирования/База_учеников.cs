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
    public partial class База_учеников : Form
    {
        public База_учеников()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);   //размеры формы
                                               //для стандратного десктопа: 1920:1080
            this.StartPosition = FormStartPosition.CenterScreen;    //располагаем форму по середине экрана
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (Тестирование.База_прошедших.Count == 0)
            {
                //MessageBox.Show(":)");
                this.Controls.Remove(listBox1);
                this.Controls.Remove(listBox2);
                Label result = new Label();
                result.Location = new Point(340, 400);
                result.MaximumSize = new Size(700, 0);
                result.AutoSize = true;
                result.ForeColor = Color.DarkMagenta;
                result.Font = new Font("Verdana", 20);
                //result.Font = new Font(result.Font, result.Font.Style | FontStyle.Bold);
                result.Size = new Size(350, 30);
                result.Text = "Пока никто не прошел тест";
                this.Controls.Add(result);
                this.Controls.Remove(button1);
            }

            else
            {
                count_vopr = new Банк_заданий.count_vopr_test[] { };
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream f = new FileStream("C:\\Users\\uahma\\source\\repos\\ТП работает\\количество_вопросов.dat",
                    FileMode.OpenOrCreate))
                {
                    count_vopr = (Банк_заданий.count_vopr_test[])formatter.Deserialize(f);
                    f.Close();
                }
               

                for (int i = 0; i < Тестирование.База_прошедших.Count; i++)
                {
                    listBox1.Items.Add(Тестирование.База_прошедших.ElementAt(i).Key);
                    mass.Add(Тестирование.База_прошедших.ElementAt(i).Key);
                }
            }
        }
        public List<int> mass = new List<int>();
        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            this.Hide();
            new Form1().Show();
        }
        Банк_заданий.count_vopr_test[] count_vopr;
        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Dictionary<string, int> Baze = new Dictionary<string, int>() { };
            //listBox2.Items.Add($"Всего {} вопросов в данном варианте\n");
            int number;
            var u = int.TryParse(listBox1.SelectedItem.ToString(), out number);
            for (int i = 0; i < mass.Count(); i++)
            {
                if (number == mass[i])
                {
                    Label label = new Label();
                    label.Location = new Point(195, 178);
                    label.MaximumSize = new Size(700, 0);
                    label.AutoSize = true;
                    label.ForeColor = Color.Blue;
                    label.Font = new Font("Verdana", 16);
                    //result.Font = new Font(result.Font, result.Font.Style | FontStyle.Bold);
                    label.Size = new Size(100, 100);
                    label.Text = $"В данном варианте {count_vopr[i].C_VOPR} вопросов.";
                    this.Controls.Add(label);

                    Baze = Тестирование.База_прошедших.ElementAt(i).Value;
                    listBox2.Items.Add($"ФИО: {Baze.ElementAt(0).Key}");
                    listBox2.Items.Add($"Количество баллов: {Baze.ElementAt(0).Value}");
                    listBox2.Items.Add("\n");
                }
            }
        }
    }
}
