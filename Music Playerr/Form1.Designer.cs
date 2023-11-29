namespace Music_Playerr
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
<<<<<<< HEAD
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            musicListBox = new ListBox();
            progressBar1 = new ProgressBar();
            controlPanel = new Panel();
            addButton = new Button();
            nextButton = new Button();
            previousButton = new Button();
            playButton = new Button();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // musicListBox
            // 
            musicListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            musicListBox.BorderStyle = BorderStyle.FixedSingle;
            musicListBox.FormattingEnabled = true;
            musicListBox.ItemHeight = 20;
            musicListBox.Location = new Point(12, 12);
            musicListBox.Name = "musicListBox";
            musicListBox.Size = new Size(338, 242);
            musicListBox.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 262);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(337, 14);
            progressBar1.TabIndex = 1;
            // 
            // controlPanel
            // 
            controlPanel.Controls.Add(addButton);
            controlPanel.Controls.Add(nextButton);
            controlPanel.Controls.Add(previousButton);
            controlPanel.Controls.Add(playButton);
            controlPanel.Location = new Point(12, 282);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(337, 90);
            controlPanel.TabIndex = 2;
            // 
            // addButton
            // 
            addButton.BackgroundImage = (Image)resources.GetObject("addButton.BackgroundImage");
            addButton.BackgroundImageLayout = ImageLayout.Stretch;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Location = new Point(304, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(30, 30);
            addButton.TabIndex = 3;
            addButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            nextButton.BackgroundImage = (Image)resources.GetObject("nextButton.BackgroundImage");
            nextButton.BackgroundImageLayout = ImageLayout.Stretch;
            nextButton.FlatAppearance.BorderSize = 0;
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.Location = new Point(206, 17);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(60, 60);
            nextButton.TabIndex = 3;
            nextButton.UseVisualStyleBackColor = false;
            nextButton.Click += nextButton_Click;
            // 
            // previousButton
            // 
            previousButton.BackgroundImage = (Image)resources.GetObject("previousButton.BackgroundImage");
            previousButton.BackgroundImageLayout = ImageLayout.Stretch;
            previousButton.FlatAppearance.BorderSize = 0;
            previousButton.FlatStyle = FlatStyle.Flat;
            previousButton.Location = new Point(74, 17);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(60, 60);
            previousButton.TabIndex = 1;
            previousButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            playButton.BackgroundImage = (Image)resources.GetObject("playButton.BackgroundImage");
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
            playButton.FlatAppearance.BorderSize = 0;
            playButton.FlatStyle = FlatStyle.Flat;
            playButton.Location = new Point(140, 17);
            playButton.Name = "playButton";
            playButton.Size = new Size(60, 60);
            playButton.TabIndex = 0;
            playButton.UseVisualStyleBackColor = true;
            // 
=======
            SuspendLayout();
            // 
>>>>>>> f58d34be9df8dcd83a787d816845823060a80588
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
            ClientSize = new Size(362, 471);
            Controls.Add(controlPanel);
            Controls.Add(progressBar1);
            Controls.Add(musicListBox);
            Name = "Form1";
            Text = "Form1";
            controlPanel.ResumeLayout(false);
=======
            ClientSize = new Size(800, 450);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
>>>>>>> f58d34be9df8dcd83a787d816845823060a80588
            ResumeLayout(false);
        }

        #endregion

        private ListBox musicListBox;
        private ProgressBar progressBar1;
        private Panel controlPanel;
        private Button button3;
        private Button playButton;
        private Button nextButton;
        private Button previousButton;
        private Button addButton;
    }
}