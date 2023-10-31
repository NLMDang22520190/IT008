namespace Shutdown
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            actionComboBox = new ComboBox();
            startBtn = new Button();
            stopBtn = new Button();
            Clear = new Button();
            timerTextBox = new TextBox();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // actionComboBox
            // 
            actionComboBox.FormattingEnabled = true;
            actionComboBox.Location = new Point(123, 84);
            actionComboBox.Name = "actionComboBox";
            actionComboBox.Size = new Size(222, 33);
            actionComboBox.TabIndex = 0;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(123, 123);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(222, 78);
            startBtn.TabIndex = 1;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.Location = new Point(123, 207);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(222, 75);
            stopBtn.TabIndex = 2;
            stopBtn.Text = "Stop";
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click;
            // 
            // Clear
            // 
            Clear.Location = new Point(123, 288);
            Clear.Name = "Clear";
            Clear.Size = new Size(222, 86);
            Clear.TabIndex = 3;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // timerTextBox
            // 
            timerTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            timerTextBox.Location = new Point(123, 31);
            timerTextBox.Name = "timerTextBox";
            timerTextBox.Size = new Size(221, 47);
            timerTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 437);
            Controls.Add(timerTextBox);
            Controls.Add(Clear);
            Controls.Add(stopBtn);
            Controls.Add(startBtn);
            Controls.Add(actionComboBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private ComboBox actionComboBox;
        private Button startBtn;
        private Button stopBtn;
        private Button Clear;
        private TextBox timerTextBox;
    }
}