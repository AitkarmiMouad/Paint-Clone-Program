using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_program
{
    public partial class Form1 : Form
    {
        Pen p;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            p = new Pen(Brushes.Black, 5);
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            numericUpDown1.Value = (decimal)p.Width;
        }
        MouseEventArgs eNew;
        bool b = true;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            if (b)
            {
                eNew = e;
                b = false;
            }
            toolStripStatusLabel1.Text = e.X + " , " + e.Y + "px";
            if (eNew.Button is MouseButtons.Left)
            {
                if (erase == true)
                {
                    p.Color =Color.White;
                }
                else
                {
                    p.Color = pictureBox7.BackColor;
                }
                g.DrawLine(p, eNew.X, eNew.Y, e.X, e.Y);
            }
            eNew = e;
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            p = new Pen(pictureBox7.BackColor, (float)numericUpDown1.Value);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.BackColor = colorDialog1.Color;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = pictureBox1.BackColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = pictureBox2.BackColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = pictureBox3.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = pictureBox4.BackColor;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = pictureBox5.BackColor;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = pictureBox6.BackColor;
        }
        bool erase = false;
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if(erase==true)
            erase = false;
            else { erase = true; }
        }
        bool fill = false;
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (fill == true)
                fill = false;
            else { fill = true; }
            if (fill == true) panel1.BackColor = pictureBox7.BackColor;
            else panel1.BackColor = Color.White;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
