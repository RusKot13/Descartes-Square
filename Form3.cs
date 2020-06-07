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
    public partial class EnterAResponse : Form
    {
        public List<string> PlusIfIDoList = new List<string>();
        public EnterAResponse()
        {
            InitializeComponent();
        }
        Point lastPoint;
        public void EnterAResponse_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        public void EnterAResponse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }        
        public void button2_Click(object sender, EventArgs e)
        {
            MainWindow form2 = new MainWindow();           
            this.Close();

        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox1.Text) != "")
            {
                PlusIfIDoList.Add(Convert.ToString(textBox1.Text));
                textBox1.Text = "";
            }
            Close();
        }
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
    }
}
