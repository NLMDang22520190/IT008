using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._4
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            // Đăng ký sự kiện Click của Form
            this.Click += MainForm_Click;

            // Đăng ký sự kiện Paint của Form
            this.Paint += MainForm_Paint;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            // Khi người dùng click vào Form, gọi phương thức Invalidate() để yêu cầu vẽ lại
            this.Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ lại chuỗi "Paint Event" tại vị trí ngẫu nhiên
            Graphics g = e.Graphics;
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            Font font = new Font(this.Font.FontFamily, 20);

            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            int x = random.Next(formWidth);
            int y = random.Next(formHeight);
            g.DrawString("Paint Event", font, Brushes.Black, x, y);
        }
    }
}
