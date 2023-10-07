namespace _1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(3, 4);

            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
            Console.WriteLine($"{a} / {b} = {a / b}");

            Console.WriteLine($"{a} == {b}: {a == b}");
            Console.WriteLine($"{a} != {b}: {a != b}");
            Console.WriteLine($"{a} < {b}: {a < b}");
            Console.WriteLine($"{a} > {b}: {a > b}");

            Fraction toFraction = 13;
            Console.WriteLine($"{toFraction} to fraction: {toFraction}");

            double decimalValue = a.ToDouble();
            Console.WriteLine($"{a.ToString()} to decimal: {decimalValue}");

            Fraction[] fractions = { new Fraction(3, 4), new Fraction(1, 2), new Fraction(2, 3) };
            Array.Sort(fractions);

            Console.WriteLine("Sorted Array");
            foreach (var fraction in fractions)
            {
                Console.WriteLine(fraction);
            }
        }
    }
}