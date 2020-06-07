using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Descartes_Square
{
    public partial class MainWindow : Form
    {
        public int PlusIfIDo1, PlusIfIDontDoIt1, ConsIfIDo1, ConsIfIDontDoIt1;
        public List<string> PlusIfIDoList1 = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
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
                label1.Text = "Мы не советуем вам это делаетсь.";
            }
        }
        private void button2_Click_1(object sender, EventArgs e)//
        {
            PlusIfIDontDoIt1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            for (int i = 0; i < Greeting.PlusIfIDoList.Count; i++)
                PlusIfIDontDoIt.Text += Greeting.PlusIfIDoList[i] + "\n";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PlusIfIDo1 = 0; PlusIfIDontDoIt1 = 0; ConsIfIDo1 = 0; ConsIfIDontDoIt1 = 0;
            PlusIfIDo.Text = ""; PlusIfIDontDoIt.Text = ""; ConsIfIDo.Text = ""; ConsIfIDontDoIt.Text = "";
            label1.Text = "Ответьте на каждой из 4 вопросов. Очень важно дать на эти вопросы максимальное количество ответов." +
                " Сверху записывайте все плюсы данного решения а  снизу все минусы."+
                "Нажмите на кнопку справа сверху(Он есть в каждом из 4 квадратовю) В появившемся окне введите свой ответ," +
                " потом нажмите \"Ответить ещё\", для сохранения ответа, или нажмите\"X\" если вы хотите закончить отвечать.";
        }
        private void label2_Click(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)//
        {
            PlusIfIDo1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            for (int i = 0; i < Greeting.PlusIfIDoList.Count; i++)
                PlusIfIDo.Text += Greeting.PlusIfIDoList[i] + "\n";
        }
        private void button4_Click(object sender, EventArgs e)//
        {
            ConsIfIDontDoIt1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            for (int i = 0; i < Greeting.PlusIfIDoList.Count; i++)
                ConsIfIDontDoIt.Text += Greeting.PlusIfIDoList[i] + "\n";
        }
        private void button3_Click(object sender, EventArgs e)//
        {
            ConsIfIDo1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            for (int i = 0; i < Greeting.PlusIfIDoList.Count; i++)
                ConsIfIDo.Text += Greeting.PlusIfIDoList[i] + "\n";
        }       
    }
}
