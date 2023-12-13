using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace Music_Playerr
{
    public partial class Form1 : Form
    {

        private List<Song> playlist = new List<Song>();
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private int currentSongIndex = -1;

        // Hàm khởi tạo của Form
        public Form1()
        {
            InitializeComponent();
            //set_background_for_play_button();
            timer1.Interval = 1000; // Cập nhật mỗi 10ms
            timer1.Start();
        }



        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
                return;

            if (currentSongIndex == -1)
            {
                currentSongIndex = 0;
                listBoxPlaylist.SelectedIndex = 0;
            }


            if (waveOutDevice == null)
            {
                Play(playlist[currentSongIndex].FilePath);
            }
            else if (waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                Pause();
            }
            else if (waveOutDevice.PlaybackState == PlaybackState.Paused)
            {
                Continue();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
                return;

            Stop();

            currentSongIndex = (currentSongIndex + 1) % playlist.Count;
            Play(playlist[currentSongIndex].FilePath);

        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
                return;

            Stop();

            currentSongIndex = (currentSongIndex - 1 + playlist.Count) % playlist.Count;
            Play(playlist[currentSongIndex].FilePath);

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.flac;*.ogg;*.aac";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string destinationPath = Path.Combine(Application.StartupPath, "Music", Path.GetFileName(filePath));

                // Thực hiện copy file
                File.Copy(filePath, destinationPath, true);

                // Tạo đối tượng Song từ đường dẫn mới
                Song newSong = new Song(destinationPath, Path.GetFileNameWithoutExtension(filePath));

                // Thêm vào danh sách và ListBox
                playlist.Add(newSong);
                listBoxPlaylist.Items.Add(newSong.Title);
            }
        }


        private void Play(string filePath)
        {
            set_background_for_pause_button();
            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader(filePath);
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();

            timer1.Start();

            // Cập nhật chiều dài của ProgressBar
            progressBarSong.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;

            // Cập nhật Label
            labelNowPlaying.Text = "Current song playing: " + Path.GetFileNameWithoutExtension(filePath);


        }

        private void Pause()
        {
            set_background_for_playpause_button();
            waveOutDevice.Pause();
        }

        private void Continue()
        {
            set_background_for_pause_button();
            waveOutDevice.Play();
            timer1.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                progressBarSong.Value = (int)audioFileReader.CurrentTime.TotalSeconds;

                if (audioFileReader.CurrentTime == audioFileReader.TotalTime)
                {
                    timer1.Stop();
                    progressBarSong.Value = 0;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Đọc tất cả các file nhạc trong thư mục Music và thêm vào danh sách
            string musicFolderPath = Path.Combine(Application.StartupPath, "Music");

            if (Directory.Exists(musicFolderPath))
            {
                string[] musicFiles = Directory.GetFiles(musicFolderPath, "*.mp3");

                foreach (string file in musicFiles)
                {
                    Song song = new Song(file, Path.GetFileNameWithoutExtension(file));
                    playlist.Add(song);
                    listBoxPlaylist.Items.Add(song.Title);
                }
            }

            if (playlist.Count > 0)
            {
                listBoxPlaylist.SelectedIndex = 0;
                currentSongIndex = 0;
            }
        }

        private void listBoxMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedIndex != -1)
            {
                Stop();
                currentSongIndex = listBoxPlaylist.SelectedIndex;
                Play(playlist[currentSongIndex].FilePath);
            }
        }

        private void Stop()
        {
            set_background_for_play_button();
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
        }

        // Hàm thiết lập hình nền cho nút play
        private void set_background_for_play_button()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Image", "play-button-svgrepo-com.png");
            playButton.BackgroundImage = Image.FromFile(imagePath);
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Hàm thiết lập hình nền cho nút pause
        private void set_background_for_pause_button()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Image", "pause.png");
            playButton.BackgroundImage = Image.FromFile(imagePath);
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Hàm thiết lập hình nền cho nút play/pause
        private void set_background_for_playpause_button()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Image", "Play_pause.png");
            playButton.BackgroundImage = Image.FromFile(imagePath);
            playButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedIndex != -1 && listBoxPlaylist.Items.Count > 0)
            {
                Stop();

                int selectedIndex = listBoxPlaylist.SelectedIndex;

                // Kiểm tra xem selected index có hợp lệ không
                if (selectedIndex >= 0 && selectedIndex < playlist.Count)
                {
                    string selectedFilePath = playlist[selectedIndex].FilePath;
                    string selectedFileName = Path.GetFileName(selectedFilePath);

                    // Kiểm tra xem bài hát đang chơi có phải là bài hát đang được xóa không
                    bool isCurrentSongDeleted = currentSongIndex == selectedIndex;

                    // Hiển thị MessageBox hỏi người dùng có muốn xóa không
                    DialogResult result = MessageBox.Show("Do you want to delete the selected song?\nThis action will remove it from the playlist.", "Delete Song", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Xóa bài nhạc khỏi danh sách
                        playlist.RemoveAt(selectedIndex);
                        listBoxPlaylist.Items.RemoveAt(selectedIndex);

                        // Xóa file nhạc từ thư mục Music (nếu được chọn)
                        result = MessageBox.Show("Do you want to delete the song file from the 'Music' folder as well?", "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                File.Delete(selectedFilePath);
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show("Error deleting file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // Nếu bài hát đang chơi bị xóa, chuyển sang bài hát tiếp theo
                        if (isCurrentSongDeleted && currentSongIndex < playlist.Count)
                        {
                            Play(playlist[currentSongIndex].FilePath);
                        }
                    }
                }
            }
        }

    }
}

