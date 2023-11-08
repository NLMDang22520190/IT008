using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            Bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(Bitmap);
            graphics.Clear(Color.White);
            canvas.Image = Bitmap;
        }

        Bitmap Bitmap;
        Graphics graphics;
        bool canPaint = false;
        Point px, py;
        Pen pen = new Pen(Color.Black, 1);
        Pen eraser = new Pen(Color.White, 1);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog colorDialog = new ColorDialog();
        Color newColor;

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            canPaint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }


        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(canPaint)
            {
                if(index == 1)
                {
                    px = e.Location;
                    graphics.DrawLine(pen, px, py);
                    py = px;
                }

                if (index == 2)
                {
                    px = e.Location;
                    graphics.DrawLine(eraser, px, py);
                    py = px;
                }
            }
            canvas.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            canPaint = false;

            sX = x - cX;
            sY = y - cY;


            if(index == 3)
            {
                graphics.DrawEllipse(pen, cX, cY, sX, sY);
            }

            if(index == 4)
            {
                graphics.DrawRectangle(pen, cX, cY, sX, sY);
            }    

            if(index == 5)
            {
                graphics.DrawLine(pen, cX, cY, x, y);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
                graphics.Clear(Color.White);
            canvas.Image = Bitmap;
            index = 0;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            newColor = colorDialog.Color;
            pen.Color = newColor;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if(sfd.ShowDialog() == DialogResult.OK )
            {
                Bitmap btm = Bitmap.Clone(new Rectangle(0, 0, canvas.Width, canvas.Height), Bitmap.PixelFormat);
                btm.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if(canPaint)
            {
                if (index == 3)
                {
                    graphics.DrawEllipse(pen, cX, cY, sX, sY);
                }

                if (index == 4)
                {
                    graphics.DrawRectangle(pen, cX, cY, sX, sY);
                }

                if (index == 5)
                {
                    graphics.DrawLine(pen, cX, cY, x, y);
                }
            }
        }

        private void pencilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void eraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 2;
        }


        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = 5;
        }

    }
}
