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
    public partial class П_выбор : Form
    {
        public П_выбор()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);   //размеры формы
                                               //для стандратного десктопа: 1920:1080
            this.StartPosition = FormStartPosition.CenterScreen;    //располагаем форму по середине экрана
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void П_выбор_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Банк_заданий().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Добавить_вопрос().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new просмотр_теста().Show();
            this.Hide();
        }
    }
}
