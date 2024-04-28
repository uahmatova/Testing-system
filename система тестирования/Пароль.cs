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
    public partial class Пароль : Form
    {
        public Пароль()
        {
            InitializeComponent();
            this.Size = new Size(702, 439);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            //textBox2.Font.Size = 20;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "пароль")
            {
                if (Form1.parol == 1)
                {
                    new П_выбор().Show();
                    this.Hide();
                    //Form1.Hide();
                }
                else
                {
                    new База_учеников().Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Неверный пароль.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
