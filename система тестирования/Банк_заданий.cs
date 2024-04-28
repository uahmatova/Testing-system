using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ТП_работает
{
    public partial class Банк_заданий : Form
    {
        public static Question[] mass;

		public List<Question> spisok;
		//тип вопроса, вопрос, правильный ответ
		public Банк_заданий()
        {
            InitializeComponent();
            this.Size = new Size(1200, 980);
            this.StartPosition = FormStartPosition.CenterScreen;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
		}

        private void Банк_заданий_Load(object sender, EventArgs e)
		{
            //Baza();
            //Count_vopr_test();
            Deserial();
            Vopros(mass);
		}


		[Serializable]
		public struct Question
		{
			string question;
			string answer;

			public Question(string question, string answer)
			{
				this.question = question;
				this.answer = answer;
			}

			public string QUESTION { get { return question; } }
			public string ANSWER { get { return answer; } }
		}
        [Serializable]
        public struct count_vopr_test
        {
            int number_test, count_vopr;

            public count_vopr_test(int number_test, int count_vopr)
            {
                this.number_test = number_test;
                this.count_vopr = count_vopr;
            }

            public int N_TEST { get { return number_test; } }
            public int C_VOPR { get { return count_vopr; } }
        }

        private void Count_vopr_test()
        {
            count_vopr_test[] mass = new count_vopr_test[]		//массив для базы вопросов
				{
                    new count_vopr_test(1,5),
                    new count_vopr_test(2,5),
                    new count_vopr_test(3,4),
                    new count_vopr_test(4,4),
                    new count_vopr_test(5,4),
                    new count_vopr_test(6,4),
                    new count_vopr_test(7,4),
                    new count_vopr_test(8,5),
                    new count_vopr_test(9,11),
                    new count_vopr_test(10,11),
                    new count_vopr_test(11,6),
                    new count_vopr_test(12,7),
                    new count_vopr_test(13, 10)
                };
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream f = new FileStream("C:\\Users\\uahma\\source\\repos\\ТП работает\\количество_вопросов.dat",
                    FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, mass);
                f.Close();
            }
        }
        public void Baza()
        {
            Question[] mass = new Question[]		//массив для базы вопросов
				{
                    new Question ("Какое хвойное дерево сбрасывает на зиму листву?", "Лиственница"),
                    new Question("Какая птица считается символом мира?", "Голубь"),
                    new Question("Что делает ёж зимой?","Спит"),
                    new Question("Какую птицу люди назвали белобокой?","Сорока"),
                    new Question("Как называют плоды дуба?","Желуди"),
                    new Question("У какой птицы самый длинный язык?","Дятел"),
                    new Question("Летает ли пингвин?","Нет"),
                    new Question("Из чего состоит горб у верблюда?","Из жира"),
                    new Question("И зимой, и летом одним цветом. Что это?","Елка"),
                    new Question("На каком цветке гаают девушки?","Ромашка"),
                    new Question("Вокруг чего вращается Земля?","Солнце"),
                    new Question("Линия, которая делит Землю пополам, называется..","Экватор"),
                    new Question("Кто такой гиппопотам?","Бегемот"),
                    new Question("Кто спит вниз головой?","Летучая мышь"),
                    new Question("Какие животные спят с открытыми глазами?","Рыбы"),
                    new Question("После какого времени года наступает весна?","Зима"),
                    new Question("Какой цветок является символом самовлюбленности?","Нарцисс"),
                    new Question("Какое растение помогает заживляет раны?","Подорожник"),
                    new Question("Из какого дерева делают спички?","Осина"),
                    new Question("Из какого дерева делают лыжи?","Береза"),
                    new Question("Самое глубокое озеро в мире","Байкал"),
                    new Question("Кто слышит ногами?","Кузнечик"),
                    new Question("Какое животное постоянно работает в земле?","Крот"),
                    new Question("Насекомое, которое питается кровью и пищит по ночам","Комар"),
                    new Question("Какое растение может обжечь кожу?","Крапива"),
                    new Question("Это животное считается самым крупным на планете","Кит"),
                    new Question("Какая птичка способна летать, повернув голову назад?","Колибри")
                };
            //foreach (Question q in mass)
            //	Serial(q);
            Serial(mass);
            //spisok.Add(new Question ("это вопрос?", "нет, ответ"));
        }
        public static void Serial(Question[] mass)                           //Сериализируем вопросы в базу
		{
			BinaryFormatter formatter = new BinaryFormatter();
            //var dir = new DirectoryInfo("C:\\Users\\uahma\\source\\repos\\ТП работает\\Вопросы");
            //FileInfo[] files = dir.GetFiles("*.dat");
            //int k = files.Length + 1;
            //         string path = $"C:\\Users\\uahma\\source\\repos\\ТП работает\\Вопросы\\{k}.dat";
            //         FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            //         formatter.Serialize(f, que);
            //         f.Close();
            using (Stream f = new FileStream("C:\\Users\\uahma\\source\\repos\\ТП работает\\вопросы.dat",
                FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, mass);
                f.Close();
            }
        }
        public static void Serial_test(List<Question> test)                           //Сериализируем тест
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var dir = new DirectoryInfo("C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты");
            FileInfo[] files = dir.GetFiles("*.dat");
            int k = files.Length + 1;
            using (Stream f = new FileStream($"C:\\Users\\uahma\\source\\repos\\ТП работает\\Тесты\\{k}.dat", 
                FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, test);
                f.Close();
            }
        }

        public static void Deserial()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream f = new FileStream("C:\\Users\\uahma\\source\\repos\\ТП работает\\вопросы.dat",
                FileMode.OpenOrCreate))
            {
                mass = (Question[])formatter.Deserialize(f);
                f.Close();
            }
            //foreach (Question question in mass)
            //{
            //    MessageBox.Show(question.QUESTION + ' ' + question.ANSWER);
            //}
            
            //Vopros(mass);

            //Question que;
            //var dir = new DirectoryInfo("C:\\Users\\uahma\\source\\repos\\ТП работает\\Вопросы");
            //FileInfo[] files = dir.GetFiles("*.dat");
            //int k = files.Length;
            //for (int i = 1; i <= k; i++)
            //{
            //	string path = $"C:\\Users\\uahma\\source\\repos\\ТП работает\\Вопросы\\{k}.dat";
            //	using (FileStream f = new FileStream(path, FileMode.Open))
            //	{
            //		que = (Question)formatter.Deserialize(f);
            //		f.Close();
            //	}
            //	spisok.Add(que);
            //}
            //Vopros(spisok);
        }

		public void Vopros(Question[] mass) //(List<Question> spisok)
		{
            //Вопрос.Add("это что, вопрос?", "да");
            //Вопрос.Add("что такое вопрос?", "вопрос");
            //Вопрос.Add("это вопрос?", "нет");
            //List<string> keyList = new List<string>(this.Вопрос.Keys);  //получение всех ключей из словаря
            //foreach (var key in keyList)
            //{
            //	checkedListBox1.Items.Add(key);
            //}

            foreach (Question question in mass)
            {
                checkedListBox1.Items.Add(question.QUESTION);
                //checkedListBox1.Items.Add(string.Format(question.QUESTION), false);
            }

            //foreach (Question que in spisok)
            //	checkedListBox1.Items.Add(que.QUESTION);

        }
        private static void checkedListBox1_Click(object sender, EventArgs e)
        {
			//checkedListBox1_ItemCheck(sender, e);
		}

		private void checkedListBox1_ItemCheck(object sender, EventArgs e)
		{
			
		}

        private void button2_Click(object sender, EventArgs e)
        {
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = FlatStyle.Flat;
			this.Hide();
			new П_выбор().Show();
		}

		public int count_vopros = 0;	//количество выбранных вопросов для теста
        count_vopr_test new_count_v;


        private void button1_Click(object sender, EventArgs e)
        {
            Question que;
            //Question[] test = new Question[count_vopros];
            List <Question> test = new List <Question>();
            BinaryFormatter formatter = new BinaryFormatter();
            button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
			{
                if (checkedListBox1.GetItemChecked(i))
                {
                    count_vopros++;
                    if (checkedListBox1.GetItemChecked(i))
                      {
                        using (FileStream f = new FileStream($"C:\\Users\\uahma\\source\\repos\\ТП работает\\Вопросы\\{i + 1}.dat",
                            FileMode.OpenOrCreate))
                        {
                            que = (Question)formatter.Deserialize(f);
                            f.Close();
                        }
                        new_count_v = new count_vopr_test(i+1, count_vopros);
                        //test[i] = que;
                        test.Add(que);
                    }
                }

            }
            if (count_vopros != 0)
            {
                Serial_test(test);

                Банк_заданий.count_vopr_test[]  count_vopr = new Банк_заданий.count_vopr_test[] { };
                BinaryFormatter format = new BinaryFormatter();
                using (FileStream f = new FileStream("C:\\Users\\uahma\\source\\repos\\ТП работает\\количество_вопросов.dat",
                    FileMode.OpenOrCreate))
                {
                    count_vopr = (Банк_заданий.count_vopr_test[])format.Deserialize(f);
                    f.Close();
                }
                Array.Resize(ref count_vopr, count_vopr.Length + 1);  //увеличиваем длину массива, чтоб добавить еще вопросец
                count_vopr[count_vopr.Length - 1] = new_count_v;     //добавили вопрос в общий массив  = > файл со всеми вопросами и ответами
                using (Stream f = new FileStream("C:\\Users\\uahma\\source\\repos\\ТП работает\\количество_вопросов.dat",
                        FileMode.OpenOrCreate))
                {
                    format.Serialize(f, count_vopr);
                    f.Close();
                }

                MessageBox.Show("Тест успешно добавлен в базу.");
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                    checkedListBox1.SetItemChecked(i, false);
                //            this.Hide();
                //new П_выбор().Show();
            }
			else MessageBox.Show("Выберите хоть один вопрос.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

    }
}
