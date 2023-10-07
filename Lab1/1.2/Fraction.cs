using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    internal class Fraction : IComparable<Fraction>
    {
        private int Numerator { get; set; }
        private int Denominator { get; set; }
        public Fraction(int numerator, int denominator)
        {

            if (denominator == 0)
            {
                throw new ArgumentException("Denominator can not be 0.");
            }

            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;

            if (denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private int GCD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Denominator / b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Numerator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new ArgumentException("Can not divide by zero");
            }

            int newNumerator = a.Numerator * b.Denominator;
            int newDenominator = a.Denominator * b.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (double)a.Numerator / a.Denominator > b.Numerator / b.Denominator;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (double)a.Numerator / a.Denominator < b.Numerator / b.Denominator;
        }

        public static implicit operator Fraction(int number)
        {
            return new Fraction(number, 1);
        }

        public double ToDouble()
        {
            return (double)Numerator / Denominator;
        }

        public int CompareTo(Fraction other)
        {
            double thisValue = (double)Numerator / Denominator;
            double otherValue = (double)other.Numerator / other.Denominator;

            if (thisValue < otherValue)
            {
                return -1;
            }
            else if (thisValue > otherValue)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
