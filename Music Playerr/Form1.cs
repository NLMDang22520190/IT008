using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace Music_Playerr
{
    public partial class Form1 : Form
    {
        private List<Song> playlist = new List<Song>();
        private string storedMusicFolder = "./Music/";
        private int currentSongIndex = 0;
        private SoundPlayer player = new SoundPlayer();
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private bool isPaused = false;
        private long pausedPosition = 0;
        public Form1()
        {
            InitializeComponent();
        }

        #region methods

        private void InitializePlaylist()
        {
            // Đảm bảo rằng danh sách đang trống trước khi thêm
            playlist.Clear();
            listBoxPlaylist.Items.Clear();

            // Đọc tất cả các file âm nhạc trong thư mục
            string[] musicFiles = Directory.GetFiles(storedMusicFolder, "*.mp3");

            foreach (var filePath in musicFiles)
            {
                // Lấy tên tệp tin không có phần mở rộng
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                // Thêm bài hát vào danh sách và ListBox
                playlist.Add(new Song(fileNameWithoutExtension, filePath));
                listBoxPlaylist.Items.Add(fileNameWithoutExtension);
            }
        }

        private void PlayCurrentSong()
        {
            if (playlist.Count > 0)
            {
                if (outputDevice != null)
                {
                    StopCurrentSong();
                }

                if (listBoxPlaylist.SelectedIndex >= 0)
                {
                    currentSongIndex = listBoxPlaylist.SelectedIndex;
                }

                Song currentSong = playlist[currentSongIndex];

                // Nếu đã dừng trước đó, thì tiếp tục từ vị trí đã dừng
                if (isPaused)
                {
                    audioFile = new AudioFileReader(currentSong.FilePath);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    outputDevice.Pause();  // Dừng ngay lập tức để thiết lập vị trí
                    audioFile.Position = pausedPosition;  // Thiết lập vị trí
                    outputDevice.Play();
                    isPaused = false;
                }
                else
                {
                    // Nếu chưa dừng, tiếp tục phát bình thường
                    audioFile = new AudioFileReader(currentSong.FilePath);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                }

                labelNowPlaying.Text = "Now Playing: " + currentSong.Title;
            }
        }


        private void StopCurrentSong()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                audioFile.Dispose();
                labelNowPlaying.Text = "Now Playing: ";
            }
        }

        #endregion

        #region events
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializePlaylist();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav|All Files|*.*";
            openFileDialog.Title = "Select a Music File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                string selectedFileName = Path.GetFileNameWithoutExtension(selectedFilePath);

                try
                {
                    // Thư mục của ứng dụng
                    string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                    // Thư mục để lưu trữ nhạc
                    string musicFolder = Path.Combine(appDirectory, "Music");

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(musicFolder))
                    {
                        Directory.CreateDirectory(musicFolder);
                    }

                    // Đường dẫn đến file nhạc trong thư mục của ứng dụng
                    string destinationFilePath = Path.Combine(musicFolder, selectedFileName + Path.GetExtension(selectedFilePath));

                    // Copy file nhạc vào thư mục của ứng dụng
                    File.Copy(selectedFilePath, destinationFilePath, true);

                    // Thêm bài hát mới vào danh sách
                    playlist.Add(new Song(selectedFileName, destinationFilePath));
                    listBoxPlaylist.Items.Add(selectedFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            PlayCurrentSong();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopCurrentSong();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentSongIndex = (currentSongIndex + 1) % playlist.Count;
            PlayCurrentSong();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            currentSongIndex = (currentSongIndex - 1 + playlist.Count) % playlist.Count;
            PlayCurrentSong();
        }

        private void listBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSongIndex = listBoxPlaylist.SelectedIndex;
        }

        #endregion




    }
}