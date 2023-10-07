namespace _1._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path;
            Console.Write("Nhap vao duong dan:");
            path = Console.ReadLine();
            Console.WriteLine(path);
            if (Directory.Exists(path))
            {
                Console.WriteLine("Thu muc ton tai: ");
                string[] filePath = Directory.GetDirectories(path);
                foreach (var item in filePath)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("Duong dan khong ton tai");


        }
    }
}