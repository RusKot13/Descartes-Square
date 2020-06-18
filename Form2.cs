using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Descartes_Square.Properties;
namespace Descartes_Square
{
    public partial class MainWindow : Form
    {
        int Sav;
        public string s = "";
        public int PlusIfIDo1, PlusIfIDontDoIt1, ConsIfIDo1, ConsIfIDontDoIt1;
        Greeting gr = new Greeting();
        public MainWindow()
        {
            InitializeComponent();
            Save1.Text = Settings.Default["Sav1"].ToString();
            Save2.Text = Settings.Default["Sav2"].ToString();
            Save3.Text = Settings.Default["Sav3"].ToString();
            Save4.Text = Settings.Default["Sav4"].ToString();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        Point lastPoint;
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void Strath_Click(object sender, EventArgs e)
        {         
            PlusIfIDo1 = PlusIfIDo.Lines.Length;
            PlusIfIDontDoIt1 = PlusIfIDontDoIt.Lines.Length;
            ConsIfIDo1 = ConsIfIDo.Lines.Length;
            ConsIfIDontDoIt1 = ConsIfIDontDoIt.Lines.Length;
            int a = PlusIfIDo1 - ConsIfIDo1;
            int b = PlusIfIDontDoIt1 - ConsIfIDontDoIt1;
            if (a - b == 0)
            {
                label1.Text = "Мы не можем дать рекомендации, выбора за вами.";
            }
            else if (a - b >= 1)
            {
                label1.Text = "Мы советуем вам это сделать.";
            }
            else
            {
                label1.Text = "Мы не советуем вам это делать.";
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {

            User user = new User();           
            user.PlusIfIDoList = PlusIfIDo.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            user.PlusIfIDontDoItList = PlusIfIDontDoIt.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            user.ConsIfIDoList = ConsIfIDo.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            user.ConsIfIDontDoItDoList = ConsIfIDontDoIt.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            XmlSerializer xml = new XmlSerializer(typeof(User));
            if (Sav == 0)
            {
                label1.Text = "Пожалуйста выбирите место сохранение (нажмите на  одну из 4 голубых кнопок)";

            }
            if (Sav== 1)
            {
            {
                    Save1.Text = s;
                    Settings.Default["Sav1"] = s;
                    Settings.Default.Save();
                using (FileStream fs1= new FileStream("Save1.xml", FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs1, user);
                }
            }
            
            }
            if (Sav == 2)
            {
                {
                    Save2.Text = s;
                    Settings.Default["Sav2"] = s;
                    Settings.Default.Save();
                    using (FileStream fs = new FileStream("Save2.xml", FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, user);
                    }
                }

            }
            if (Sav == 3)
            {
                {
                    Save3.Text = s;
                    Settings.Default["Sav3"] = s;
                    Settings.Default.Save();
                    using (FileStream fs = new FileStream("Save3.xml", FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, user);
                    }
                }

            }
            if (Sav == 4)
            {
                {
                    Save4.Text = s;
                    Settings.Default["Sav4"] = s;
                    Settings.Default.Save();
                    using (FileStream fs = new FileStream("Save4.xml", FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, user);
                    }
                }
            }

        }

        private void Loading_Click(object sender, EventArgs e)
        {
            if (Sav == 0)
            {               
                label1.Text = " Пожалуйста выберите место загрузки(нажмите на  одну из 4 голубых кнопок)";

            }
            XmlSerializer xml = new XmlSerializer(typeof(User));
            if (Sav == 1 && Save1.Text != "Пуст")
            {
                using (FileStream fs = new FileStream("Save1.xml", FileMode.OpenOrCreate))
                {
                    User user = (User)xml.Deserialize(fs);
                    for (int i = 0; i < user.PlusIfIDoList.Length; i++)
                    {
                        PlusIfIDo.Text = user.PlusIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.PlusIfIDontDoItList.Length; i++)
                    {
                        PlusIfIDontDoIt.Text = user.PlusIfIDontDoItList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDoList.Length; i++)
                    {
                        ConsIfIDo.Text = user.ConsIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDontDoItDoList.Length; i++)
                    {
                        ConsIfIDontDoIt.Text = user.ConsIfIDontDoItDoList[i] + "\r\n";
                    }
                }
            }
            if (Sav == 2 && Save2.Text != "Пуст")
            {
                using (FileStream fs = new FileStream("Save2.xml", FileMode.OpenOrCreate))
                {
                    User user = (User)xml.Deserialize(fs);
                    for (int i = 0; i < user.PlusIfIDoList.Length; i++)
                    {
                        PlusIfIDo.Text = user.PlusIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.PlusIfIDontDoItList.Length; i++)
                    {
                        PlusIfIDontDoIt.Text = user.PlusIfIDontDoItList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDoList.Length; i++)
                    {
                        ConsIfIDo.Text = user.ConsIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDontDoItDoList.Length; i++)
                    {
                        ConsIfIDontDoIt.Text = user.ConsIfIDontDoItDoList[i] + "\r\n";
                    }
                }
            }
            if (Sav == 3 && Save3.Text != "Пуст")
            {
                using (FileStream fs = new FileStream("Save3.xml", FileMode.OpenOrCreate))
                {
                    User user = (User)xml.Deserialize(fs);
                    for (int i = 0; i < user.PlusIfIDoList.Length; i++)
                    {
                        PlusIfIDo.Text = user.PlusIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.PlusIfIDontDoItList.Length; i++)
                    {
                        PlusIfIDontDoIt.Text = user.PlusIfIDontDoItList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDoList.Length; i++)
                    {
                        ConsIfIDo.Text = user.ConsIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDontDoItDoList.Length; i++)
                    {
                        ConsIfIDontDoIt.Text = user.ConsIfIDontDoItDoList[i] + "\r\n";
                    }
                }
            }
            if (Sav == 4 && Save4.Text != "Пуст")
            {
                using (FileStream fs = new FileStream("Save4.xml", FileMode.OpenOrCreate))
                {
                    User user = (User)xml.Deserialize(fs);
                    for (int i = 0; i < user.PlusIfIDoList.Length; i++)
                    {
                        PlusIfIDo.Text = user.PlusIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.PlusIfIDontDoItList.Length; i++)
                    {
                        PlusIfIDontDoIt.Text = user.PlusIfIDontDoItList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDoList.Length; i++)
                    {
                        ConsIfIDo.Text = user.ConsIfIDoList[i] + "\r\n";
                    }
                    for (int i = 0; i < user.ConsIfIDontDoItDoList.Length; i++)
                    {
                        ConsIfIDontDoIt.Text = user.ConsIfIDontDoItDoList[i] + "\r\n";
                    }
                }
            }
        }

        private void SaveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            Sav = 1;
            Save1.Text = "Выбран";
            Save2.Text = Settings.Default["Sav2"].ToString();
            Save3.Text = Settings.Default["Sav3"].ToString();
            Save4.Text = Settings.Default["Sav4"].ToString();

        }

        private void Save2_Click(object sender, EventArgs e)
        {
            Sav = 2;
            Save1.Text = Settings.Default["Sav1"].ToString();
            Save2.Text = "Выбран";
            Save3.Text = Settings.Default["Sav3"].ToString();
            Save4.Text = Settings.Default["Sav4"].ToString();
        }

        private void Save3_Click(object sender, EventArgs e)
        {
            Sav = 3;
            Save1.Text = Settings.Default["Sav1"].ToString();
            Save2.Text = Settings.Default["Sav2"].ToString();
            Save3.Text = "Выбран";
            Save4.Text = Settings.Default["Sav4"].ToString();
        }

        private void Save4_Click(object sender, EventArgs e)
        {
            Sav = 4;
            Save1.Text = Settings.Default["Sav1"].ToString();
            Save2.Text = Settings.Default["Sav2"].ToString();
            Save3.Text = Settings.Default["Sav3"].ToString();
            Save4.Text = "Выбран";
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            s = "";
            Sav = 0;
            PlusIfIDo1 = 0; PlusIfIDontDoIt1 = 0; ConsIfIDo1 = 0; ConsIfIDontDoIt1 = 0;
            PlusIfIDo.Text = ""; PlusIfIDontDoIt.Text = ""; ConsIfIDo.Text = ""; ConsIfIDontDoIt.Text = "";
            label1.Text = "Ответьте на каждой из 4 вопросов. Очень важно дать на эти вопросы максимальное количество ответов." +
                " Сверху записывайте все плюсы данного решения а  снизу все минусы.После того как вы закончели отвечать нажмите “Старт” После того как вы записали ответ нажмите" +
                " Enter для написания еще одного ответа в случае необходимости";
            Greeting gr = new Greeting();
            this.Hide();
            gr.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlusIfIDo1 = 0; PlusIfIDontDoIt1 = 0; ConsIfIDo1 = 0; ConsIfIDontDoIt1 = 0;
            PlusIfIDo.Text = ""; PlusIfIDontDoIt.Text = ""; ConsIfIDo.Text = ""; ConsIfIDontDoIt.Text = "";
            label1.Text = "Ответьте на каждой из 4 вопросов. Очень важно дать на эти вопросы максимальное количество ответов." +
                " Сверху записывайте все плюсы данного решения а  снизу все минусы.После того как вы закончели отвечать нажмите “Старт” После того как вы записали ответ нажмите" +
                " Enter для написания еще одного ответа в случае необходимости";
;
        }
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

    }
}
