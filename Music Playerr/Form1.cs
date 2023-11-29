namespace Music_Playerr
{
    public partial class Form1 : Form
    {
        private List<Song> playlist = new List<Song>();
        private string storedMusicFolder = "./Music/";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializePlaylist();
        }
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
    }
}