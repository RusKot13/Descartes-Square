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
    public partial class Greeting : Form
    {
        public Greeting()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        Point lastPoint;
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void Strath_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox1.Text != "Введите проблему") 
            {
                this.Hide();
                MainWindow Greeting = new MainWindow();
                Greeting.s = textBox1.Text;
                Greeting.ShowDialog();
                this.Close();
            }
            else           
                textBox1.Text = "Введите проблему";           
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Введите проблему")
            textBox1.Text = "";
        }

        public void button1_Click(object sender, EventArgs e)
        {         
        }
    }
}
