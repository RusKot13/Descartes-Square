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
        int PlusIfIDo1, PlusIfIDontDoIt1, ConsIfIDo1, ConsIfIDontDoIt1;
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

        private void button2_Click(object sender, EventArgs e)
        {
            PlusIfIDontDoIt1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            PlusIfIDontDoIt.Text += "+ ";
        }

        private void Strath_Click(object sender, EventArgs e)
        {
            int a = PlusIfIDo1 - ConsIfIDo1;
            int b = PlusIfIDontDoIt1 - ConsIfIDontDoIt1;
            if (a - b == 0)
            {
                label1.Text = "Положительные и отрицательные последствия данного решения равны. Мы не можем дать конкретные рекомендации выбор за вами.";
            }
            else if (a - b >= 1)
            {
                label1.Text = "Положительных ответов больше отрицательных мы рекомендуем вам сделать то, что вы предприняли. Но главный выбор остается за вами.";
            }
            else
            {
                label1.Text = "Отрицательные ответы количество превышают положительные мы не рекомендуем вам делать это действие. выбор за вами.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsIfIDontDoIt1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            ConsIfIDontDoIt.Text += "- ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsIfIDo1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            ConsIfIDo.Text += "- ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlusIfIDo1++;
            EnterAResponse Greeting = new EnterAResponse();
            Greeting.ShowDialog();
            PlusIfIDo.Text +="+ ";
        }       
    }
}
