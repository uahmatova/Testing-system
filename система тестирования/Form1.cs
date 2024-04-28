
namespace ТП_работает
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);   //размеры формы
                                                //для стандратного десктопа: 1920:1080
            this.StartPosition = FormStartPosition.CenterScreen;    //располагаем форму по середине экрана
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parol = 1;
            Пароль newForm = new Пароль();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new С_выбор().Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static int parol;
        private void button2_Click(object sender, EventArgs e)
        {
            parol = 2;
            Пароль newForm = new Пароль();
            newForm.Show();
            this.Hide();
        }
    }
}