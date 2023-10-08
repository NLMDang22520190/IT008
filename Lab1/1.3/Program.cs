using System;
namespace Bai_1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so pahn tu cua mang: ");
            int n = int.Parse(Console.ReadLine());

            int[] integers = ReadArray<int>(n, "So nguyen");
            double[] doubles = ReadArray<double>(n, "So thuc");
            string[] strings = ReadArray<string>(n, "Chuoi");

            Sequence<int> intSequence = new Sequence<int>(integers);
            int maxInt = intSequence.FindMax();
            int minInt = intSequence.FindMin();

            Sequence<double> doubleSequence = new Sequence<double>(doubles);
            double maxDouble = doubleSequence.FindMax();
            double minDouble = doubleSequence.FindMin();

            Sequence<string> stringSequence = new Sequence<string>(strings);
            string maxLengthString = stringSequence.FindMax();
            string minLengthString = stringSequence.FindMin();

            Console.WriteLine("So lon nhat trong day so nguyen la: " + maxInt);
            Console.WriteLine("So lon nho trong day so nguyen la: " + minInt);
            Console.WriteLine("So lon nhat trong day so thuc la: " + maxDouble);
            Console.WriteLine("So lon nho trong day so thuc la: " + minDouble);
            Console.WriteLine("Chuoi dai nhat trong day chuoi la: " + maxLengthString);
            Console.WriteLine("Chuoi ngan nhat trong day chuoi la: " + minLengthString);
        }

        static T[] ReadArray<T>(int lenght, string typeName) 
        {
            T[] array = new T[lenght]; 
            for (int i = 0; i < lenght; i++) 
            {
                Console.WriteLine($"Nhap {typeName} thu {i +1}");
                array[i] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            }
            return array;
        }
        class Sequence<T> where T : IComparable<T>
        {
            private T[] data;
            public Sequence(T[] data)
            {
                this.data = data;
            }
            public T FindMax() 
            {
                if (data.Length == 0)
                    throw new ArgumentException("Mang du lieu trong.");

                T max = data[0];
                foreach (T item in data)
                {
                    if (item.CompareTo(max) > 0)    
                        max = item;
                }
                return max;
            }
            public T FindMin()
            {
                if (data.Length == 0)
                    throw new ArgumentException("Mang du lieu trong.");
                T min = data[0];
                foreach(T item in data)
                {
                    if (item.CompareTo(min) < 0) 
                        min = item;
                }
                return min;
            }
        }
        
    }
}