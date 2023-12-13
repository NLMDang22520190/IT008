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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listBoxPlaylist = new ListBox();
            progressBarSong = new ProgressBar();
            controlPanel = new Panel();
            deleteBtn = new Button();
            addButton = new Button();
            nextButton = new Button();
            previousButton = new Button();
            playButton = new Button();
            labelNowPlaying = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxPlaylist
            // 
            listBoxPlaylist.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBoxPlaylist.BorderStyle = BorderStyle.FixedSingle;
            listBoxPlaylist.FormattingEnabled = true;
            listBoxPlaylist.ItemHeight = 25;
            listBoxPlaylist.Location = new Point(12, 12);
            listBoxPlaylist.Name = "listBoxPlaylist";
            listBoxPlaylist.Size = new Size(347, 227);
            listBoxPlaylist.TabIndex = 0;
            listBoxPlaylist.SelectedIndexChanged += listBoxMusic_SelectedIndexChanged;
            // 
            // progressBarSong
            // 
            progressBarSong.Location = new Point(12, 282);
            progressBarSong.Name = "progressBarSong";
            progressBarSong.Size = new Size(347, 14);
            progressBarSong.TabIndex = 1;
            // 
            // controlPanel
            // 
            controlPanel.Controls.Add(deleteBtn);
            controlPanel.Controls.Add(addButton);
            controlPanel.Controls.Add(nextButton);
            controlPanel.Controls.Add(previousButton);
            controlPanel.Controls.Add(playButton);
            controlPanel.Location = new Point(12, 302);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(347, 90);
            controlPanel.TabIndex = 2;
            // 
            // deleteBtn
            // 
            deleteBtn.BackgroundImage = (Image)resources.GetObject("deleteBtn.BackgroundImage");
            deleteBtn.BackgroundImageLayout = ImageLayout.Stretch;
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.Location = new Point(3, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(30, 30);
            deleteBtn.TabIndex = 4;
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += btnDelete_Click;
            // 
            // addButton
            // 
            addButton.BackgroundImage = (Image)resources.GetObject("addButton.BackgroundImage");
            addButton.BackgroundImageLayout = ImageLayout.Stretch;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Location = new Point(314, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(30, 30);
            addButton.TabIndex = 3;
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += btnOpen_Click;
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
            nextButton.Click += btnNext_Click;
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
            previousButton.Click += btnPrevious_Click;
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
            playButton.Click += btnPlayPause_Click;
            // 
            // labelNowPlaying
            // 
            labelNowPlaying.Location = new Point(12, 248);
            labelNowPlaying.Name = "labelNowPlaying";
            labelNowPlaying.Size = new Size(347, 25);
            labelNowPlaying.TabIndex = 3;
            labelNowPlaying.Text = "Select song to play:";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 450);
            Controls.Add(labelNowPlaying);
            Controls.Add(controlPanel);
            Controls.Add(progressBarSong);
            Controls.Add(listBoxPlaylist);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(393, 506);
            MinimumSize = new Size(393, 506);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            Load += MainForm_Load;
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxPlaylist;
        private ProgressBar progressBarSong;
        private Panel controlPanel;
        private Button button3;
        private Button playButton;
        private Button nextButton;
        private Button previousButton;
        private Button addButton;
        private Label labelNowPlaying;
        private System.Windows.Forms.Timer timer1;
        private Button deleteBtn;
    }
}