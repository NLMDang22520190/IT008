using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System;

namespace Shutdown
{
    public partial class Form1 : Form
    {
        private int timeLeft;
        private string action;

        public Form1()
        {
            timeLeft = 0;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                TimeSpan time = TimeSpan.FromSeconds(timeLeft);
                string timeText = time.ToString(@"mm\:ss");
                timerTextBox.Text = timeText;
            }
            else
            {

                timerTextBox.Text = "00:00";
                timer1.Stop();
                timerTextBox.ReadOnly = false;
                string cmdLine = $"-{GetCommand(action)}";
                MessageBox.Show(cmdLine);
                Process.Start(@"C:\Windows\system32\shutdown.exe", cmdLine);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string[] split = timerTextBox.Text.Split(':');
            try
            {
                if (int.TryParse(split[0], out int minute) && int.TryParse(split[1], out int second))
                {
                    if ((minute >= 0 && minute < 60) && (second >= 0 && second < 60))
                    {
                        timeLeft = minute * 60 + second;
                        timer1.Start();
                        timerTextBox.ReadOnly = true;
                    }
                    else
                        throw new ArgumentOutOfRangeException();
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Wrong input");
            }
            action = actionComboBox.Text;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerTextBox.ReadOnly = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerTextBox.Text = "00:00";
            actionComboBox.Items.Add("shutdown");
            actionComboBox.Items.Add("restart");
            actionComboBox.Items.Add("logout");
            actionComboBox.SelectedIndex = 0;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerTextBox.Text = "00:00";
            timerTextBox.ReadOnly = false;
        }

        static string GetCommand(string action)
        {
            if (action == "shutdown")
            {
                return "s -t 0";
            }
            else if (action == "restart")
            {
                return "r -t 0";
            }
            else if (action == "logout")
            {
                return "l";
            }
            else
            {
                throw new ArgumentException("Invalid action");
            }
        }
    }
}