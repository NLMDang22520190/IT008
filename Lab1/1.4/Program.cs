using System.Reflection.PortableExecutable;

namespace ConsoleApp1
{
    public class NhietKe
    {
        private int nhiet;
        public event EventHandler ThayDoiNhietDo;
        public int Nhiet
        {
            get { return nhiet; }
            set
            {
                nhiet = value;
                NhietDoThayDoi();
            }
        }

        public void NhietDoThayDoi()
        {
            ThayDoiNhietDo?.Invoke(this, EventArgs.Empty);
        }
    }

    public class ManHinh
    {
        public void HienThiNhietDo(object sender, EventArgs e)
        {
            if (sender is NhietKe nhietKe)
                Console.WriteLine("Nhiet do hien tai: " + nhietKe.Nhiet + " do C");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var NhietKe = new NhietKe();
            var ManHinh = new ManHinh();
            var random = new Random();
            NhietKe.ThayDoiNhietDo += ManHinh.HienThiNhietDo;
            for (int i = 0; i < 5; i++)
            {
                int NhietDo = random.Next(1, 100);
                NhietKe.Nhiet = NhietDo;
                Thread.Sleep(500);
            }

        }
    }
}