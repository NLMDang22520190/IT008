using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Playerr
{
    public class Song
    {
        public string FilePath { get; set; }
        public string Title { get; set; }

        //public Song(string title, string filePath)
        //{
        //    Title = title;
        //    FilePath = filePath;
        //}

        public Song(string filePath, string title)
        {
            Title = title;
            FilePath = filePath;
        }
    }

    // Hàm xử lý sự kiện khi button2 được click


    //#region methods

    //// Hàm khởi tạo danh sách bài hát
    //private void InitializePlaylist()
    //{
    //    // Đảm bảo danh sách trống trước khi thêm
    //    playlist.Clear();
    //    listBoxPlaylist.Items.Clear();

    //    // Tạo thư mục lưu trữ nếu chưa tồn tại
    //    if (!Directory.Exists(storedMusicFolder))
    //    {
    //        Directory.CreateDirectory(storedMusicFolder);
    //    }

    //    // Lấy danh sách các file âm nhạc trong thư mục
    //    string[] musicFiles = Directory.GetFiles(storedMusicFolder, "*.mp3");

    //    foreach (var filePath in musicFiles)
    //    {
    //        // Lấy tên file không có phần mở rộng
    //        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

    //        // Thêm bài hát vào danh sách và ListBox
    //        playlist.Add(new Song(fileNameWithoutExtension, filePath));
    //        listBoxPlaylist.Items.Add(fileNameWithoutExtension);
    //    }
    //}




    //// Hàm phát bài hát hiện tại
    //private void PlayCurrentSong()
    //{
    //    if (playlist.Count > 0)
    //    {
    //        // Nếu đang có bài hát đang phát, dừng nó trước khi chuyển sang bài hát khác
    //        if (outputDevice != null)
    //        {
    //            StopCurrentSong();
    //        }

    //        // Lấy vị trí chọn trên ListBox
    //        if (listBoxPlaylist.SelectedIndex >= 0)
    //        {
    //            currentSongIndex = listBoxPlaylist.SelectedIndex;
    //        }

    //        // Lấy thông tin của bài hát đang chọn
    //        Song currentSong = playlist[currentSongPlayingIndex];

    //        // Nếu không phải là bài hát đang chơi, chuyển sang bài hát mới
    //        if (currentSongIndex != currentSongPlayingIndex)
    //        {
    //            currentSong = playlist[currentSongIndex];
    //        }

    //        // Tạo đối tượng đọc file âm thanh cho bài hát
    //        audioFile = new AudioFileReader(currentSong.FilePath);
    //        audioFile.Position = pausedPosition;

    //        // Tạo đối tượng phát âm thanh sử dụng thư viện NAudio
    //        outputDevice = new WaveOutEvent();
    //        outputDevice.Init(audioFile);

    //        // Nếu đang tạm dừng, tiếp tục từ vị trí tạm dừng
    //        if (isPaused)
    //        {
    //            outputDevice.Play();
    //        }
    //        else
    //        {
    //            // Nếu không phải là bài hát đang chơi, phát bài hát mới
    //            if (currentSongIndex != currentSongPlayingIndex)
    //            {
    //                outputDevice.Play();
    //            }
    //            else
    //            {
    //                // Nếu là bài hát đang chơi và đang phát, tạm dừng nó
    //                outputDevice.Pause();
    //            }
    //        }

    //        // Hiển thị thông tin bài hát đang phát
    //        labelNowPlaying.Text = "Now Playing: " + currentSong.Title;

    //        // Bắt đầu đồng hồ đếm thời gian
    //        timer1.Start();
    //    }
    //}

    //// Hàm dừng bài hát hiện tại
    //private void StopCurrentSong()
    //{
    //    if (outputDevice != null)
    //    {
    //        // Dừng và giải phóng tài nguyên của đối tượng phát âm thanh
    //        outputDevice.Stop();
    //        outputDevice.Dispose();
    //        audioFile.Dispose();
    //        labelNowPlaying.Text = "Now Playing: ";
    //    }

    //    // Dừng đồng hồ đếm thời gian
    //    timer1.Stop();
    //}

    //// Hàm cập nhật thanh tiến trình
    //private void UpdateProgressBar()
    //{
    //    if (audioFile != null && outputDevice != null)
    //    {
    //        int totalSeconds = (int)audioFile.TotalTime.TotalSeconds;
    //        int currentPosition = (int)audioFile.CurrentTime.TotalSeconds;

    //        // Đảm bảo không chia cho 0
    //        if (totalSeconds > 0)
    //        {
    //            // Tính toán tỉ lệ và cập nhật ProgressBar
    //            int progressValue = (currentPosition * progressBarSong.Maximum) / totalSeconds;
    //            progressBarSong.Value = progressValue;
    //        }
    //    }
    //}

    //#endregion

    //#region events

    //// Sự kiện khi Form được load
    //private void Form1_Load(object sender, EventArgs e)
    //{
    //    // Khởi tạo danh sách bài hát
    //    InitializePlaylist();
    //}

    //// Sự kiện khi nút mở file được click
    //private void buttonOpen_Click(object sender, EventArgs e)
    //{
    //    // Hiển thị hộp thoại mở file
    //    OpenFileDialog openFileDialog = new OpenFileDialog();
    //    openFileDialog.Filter = "Audio Files|*.mp3;*.wav|All Files|*.*";
    //    openFileDialog.Title = "Select a Music File";

    //    if (openFileDialog.ShowDialog() == DialogResult.OK)
    //    {
    //        // Lấy đường dẫn của file đã chọn
    //        string selectedFilePath = openFileDialog.FileName;
    //        string selectedFileName = Path.GetFileNameWithoutExtension(selectedFilePath);

    //        try
    //        {
    //            // Thư mục của ứng dụng
    //            string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

    //            // Thư mục để lưu trữ nhạc
    //            string musicFolder = Path.Combine(appDirectory, "Music");

    //            // Tạo thư mục nếu chưa tồn tại
    //            if (!Directory.Exists(musicFolder))
    //            {
    //                Directory.CreateDirectory(musicFolder);
    //            }

    //            // Đường dẫn đến file nhạc trong thư mục của ứng dụng
    //            string destinationFilePath = Path.Combine(musicFolder, selectedFileName + Path.GetExtension(selectedFilePath));

    //            // Copy file nhạc vào thư mục của ứng dụng
    //            File.Copy(selectedFilePath, destinationFilePath, true);

    //            // Thêm bài hát mới vào danh sách
    //            playlist.Add(new Song(selectedFileName, destinationFilePath));
    //            listBoxPlaylist.Items.Add(selectedFileName);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error: {ex.Message}");
    //        }
    //    }
    //}

    //// Sự kiện khi nút play/pause được click
    //private void buttonPlay_Click(object sender, EventArgs e)
    //{
    //    // Nếu bài hát đang được tạm dừng, chuyển thành nút pause
    //    if (currentSongIndex != currentSongPlayingIndex)
    //    {
    //        pausedPosition = 0;
    //        isPaused = true;
    //    }

    //    // Nếu đang tạm dừng, chuyển thành nút pause
    //    if (isPaused)
    //    {
    //        currentSongPlayingIndex = currentSongIndex;
    //        set_background_for_pause_button();
    //    }
    //    else // Nếu đang phát, chuyển thành nút play/pause
    //    {
    //        // Nếu không phải là bài hát đang chơi, chuyển thành nút pause
    //        if (currentSongIndex != currentSongPlayingIndex)
    //        {
    //            set_background_for_pause_button();
    //        }
    //        else // Nếu là bài hát đang chơi, chuyển thành nút play/pause và lưu vị trí tạm dừng
    //        {
    //            pausedPosition = audioFile.Position;
    //            set_background_for_playpause_button();
    //        }
    //    }

    //    // Phát bài hát
    //    PlayCurrentSong();

    //    // Đảo trạng thái tạm dừng
    //    isPaused = !isPaused;

    //    // Hiển thị trạng thái tạm dừng
    //    label1.Text = isPaused.ToString();
    //    label2.Text = currentSongPlayingIndex.ToString();
    //    label3.Text = currentSongIndex.ToString();

    //}

    //// Sự kiện khi nút dừng được click
    //private void buttonStop_Click(object sender, EventArgs e)
    //{
    //    // Dừng bài hát
    //    StopCurrentSong();
    //}

    //// Sự kiện khi nút next được click
    //private void buttonNext_Click(object sender, EventArgs e)
    //{
    //    // Dừng bài hát
    //    //StopCurrentSong();

    //    // Chuyển thành nút pause và chuyển sang bài hát kế tiếp
    //    set_background_for_pause_button();
    //    currentSongIndex = (currentSongIndex + 1) % playlist.Count;
    //    currentSongPlayingIndex = (currentSongPlayingIndex + 1) % playlist.Count;
    //    //currentSongIndex = currentSongPlayingIndex;
    //    //currentSongPlayingIndex = currentSongIndex;
    //    pausedPosition = 0;
    //    isPaused = true;
    //    //label1.Text = isPaused.ToString();
    //    PlayCurrentSong();
    //    isPaused = false;
    //    label1.Text = isPaused.ToString();
    //    label2.Text = currentSongPlayingIndex.ToString();
    //    label3.Text = currentSongIndex.ToString();

    //}

    //// Sự kiện khi nút previous được click
    //private void buttonPrevious_Click(object sender, EventArgs e)
    //{
    //    // Dừng bài hát
    //    //StopCurrentSong();

    //    // Chuyển thành nút pause và chuyển sang bài hát trước đó
    //    set_background_for_pause_button();
    //    currentSongIndex = (currentSongIndex - 1 + playlist.Count) % playlist.Count;
    //    //currentSongPlayingIndex = currentSongIndex;
    //    pausedPosition = 0;
    //    isPaused = false;
    //    label1.Text = isPaused.ToString();
    //    label2.Text = currentSongPlayingIndex.ToString();
    //    label3.Text = currentSongIndex.ToString();

    //    PlayCurrentSong();
    //}

    //// Sự kiện khi một bài hát mới được chọn trên ListBox
    //private void listBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // Lưu vị trí bài hát mới được chọn
    //    currentSongIndex = listBoxPlaylist.SelectedIndex;

    //    // Nếu là bài hát đang chơi
    //    if (currentSongIndex == currentSongPlayingIndex)
    //    {
    //        // Nếu đang tạm dừng, hiển thị nút play/pause
    //        if (isPaused)
    //        {
    //            set_background_for_playpause_button();
    //        }
    //        else // Nếu đang phát, hiển thị nút pause
    //        {
    //            set_background_for_pause_button();
    //        }
    //    }
    //    else // Nếu là bài hát mới, hiển thị nút play
    //        set_background_for_play_button();
    //}

    //// Sự kiện định kỳ của đồng hồ đếm thời gian
    //private void timer1_Tick(object sender, EventArgs e)
    //{
    //    // Cập nhật thanh tiến trình
    //    UpdateProgressBar();
    //}



    //#endregion
}
