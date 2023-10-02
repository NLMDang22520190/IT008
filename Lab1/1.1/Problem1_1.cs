using System;
namespace Problem1_1
{
    public class Point
    {
        private int x;
        private int y;
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public void input()
        {
            System.Console.Write("Enter x: ");
            this.x = System.Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Enter y: ");
            this.y = System.Convert.ToInt32(System.Console.ReadLine());
        }
        public void output()
        {
            System.Console.WriteLine("x = " + this.x);
            System.Console.WriteLine("x = " + this.y);
        }
        public static double Length_Of_Edge(Point P1, Point P2)
        {
            return Math.Sqrt((P1.x - P2.x) * (P1.x - P2.x) + (P2.y - P1.y) * (P2.y - P1.y));
        }
    }
    public class Shape
    {
        protected int Number_Of_Points;
        protected Point[] Points;
        protected string Name;
        public Shape()
        {
            this.Number_Of_Points = 0;
            this.Points = new Point[0];
            this.Name = "";
        }
        public virtual void setup_Number_Of_Points(string Name)
        {
            this.Name = Name;
            if (this.Name == "Circle")
            {
                this.Number_Of_Points = 1;
            }
            else if (this.Name == "Triangle")
            {
                this.Number_Of_Points = 3;
            }
            else
            {
                this.Number_Of_Points = 4;
            }
            this.Points = new Point[this.Number_Of_Points];
            for (int i = 0; i < this.Number_Of_Points; i++)
            {
                this.Points[i] = new Point();
            }
        }
        public virtual double Perimeter()
        {
            return 1;
        }
        public virtual double Area()
        {
            return 2;
        }
        public virtual void input()
        {
            
        }
        public virtual void output()
        {

        }
        public virtual bool checkShape()
        {
            return false;
        }
    }
    public class Circle : Shape
    {
        private double Radius;
        public Circle()
        {
            base.setup_Number_Of_Points("Circle");
        }
        public override void input()
        {
            while (true)
            {
                System.Console.WriteLine("enter Circle: ");
                System.Console.WriteLine("enter center point: ");
                this.Points[0].input();
                System.Console.Write("enter Radius: ");
                this.Radius = System.Convert.ToDouble(System.Console.ReadLine());
                if (checkShape() == false)
                {
                    System.Console.WriteLine("Radius is wrong, please re-enter");
                    continue;
                }
                System.Console.WriteLine(" ");
                System.Console.WriteLine(" ");
                break;
            }
        }
        public override bool checkShape()
        {
            if (this.Radius <= 0)
            {
                return false;
            }
            return true;
        }
        public override double Area()
        {
            return 3.14 * Radius * Radius;
        }
        public override double Perimeter()
        {
            return 2 * 3.14 * Radius;
        }
        public override void output()
        {
            System.Console.WriteLine("Name Shape: " + this.Name);
            System.Console.WriteLine("Position of center point: ");
            this.Points[0].output();
            System.Console.WriteLine("Radius: " + this.Radius);
            System.Console.WriteLine("Perimeter: " + Perimeter());
            System.Console.WriteLine("Area: " + Area());
            System.Console.WriteLine(" ");
            System.Console.WriteLine(" ");
        }
    }
    public class Triangle : Shape
    {
        private double Edge1;
        private double Edge2;
        private double Edge3;
        public Triangle()
        {
            base.setup_Number_Of_Points("Triangle");
        }
        public override bool checkShape()
        {
            if (Edge1 + Edge2 > Edge3 && Edge2 + Edge3 > Edge1 && Edge3 + Edge1 > Edge2)
            {
                return true;
            }
            return false;
        }
        public void set_Value_Of_Edges()
        {
            this.Edge1 = Point.Length_Of_Edge(this.Points[0], this.Points[1]);
            this.Edge2 = Point.Length_Of_Edge(this.Points[1], this.Points[2]);
            this.Edge3 = Point.Length_Of_Edge(this.Points[2], this.Points[0]);
        }
        public override double Perimeter()
        {
            return this.Edge1 + this.Edge2 + this.Edge3;
        }
        public override double Area()
        {
            double Pe = Perimeter();
            return Math.Sqrt((Pe - this.Edge1) * (Pe - this.Edge2) * (Pe - this.Edge3) * Pe);
        }
        public override void input()
        {
           while (true)
           {
                System.Console.WriteLine("enter Triangle: ");
                System.Console.WriteLine("Note: The points that you enter cannot overlap.");
                System.Console.WriteLine("enter Points: ");
                for (int i = 1; i <= this.Number_Of_Points; i++)
                {
                    System.Console.WriteLine("enter Point " + i + " : ");
                    this.Points[i - 1].input();
                    System.Console.WriteLine(" ");
                }  
                set_Value_Of_Edges();
                if (checkShape() == false)
                {
                    System.Console.WriteLine("Some points are wrong, please re-enter");
                    continue;
                }
                break;
           }
        }
        public override void output()
        {
            System.Console.WriteLine("Name Shape: " + this.Name);
            System.Console.WriteLine("Position of points: ");
            for (int i = 1; i <= this.Number_Of_Points; i++)
            {
                System.Console.WriteLine("Position of Point " + i + " : ");
                this.Points[i - 1].output();
            }
            System.Console.WriteLine("Length of Edges : ");
            System.Console.WriteLine("Edge1: " + Edge1);
            System.Console.WriteLine("Edge2: " + Edge2);
            System.Console.WriteLine("Edge3: " + Edge3);
            System.Console.WriteLine("Perimeter: " + Perimeter());
            System.Console.WriteLine("Area: " + Area());
        }
    }
    class Recangle : Shape
    {
        private double Length;
        private double Wide;
        public override void setup_Number_Of_Points(string Name)
        {
            base.setup_Number_Of_Points(Name);
        }
        public Recangle()
        {
            setup_Number_Of_Points("Recangle");
        }
        public override bool checkShape()
        {
            double Edge1 = Point.Length_Of_Edge(this.Points[0], this.Points[1]);
            double Edge2 = Point.Length_Of_Edge(this.Points[1], this.Points[2]);
            double Edge3 = Point.Length_Of_Edge(this.Points[2], this.Points[3]);
            double Edge4 = Point.Length_Of_Edge(this.Points[3], this.Points[0]);
            double Edge5 = Point.Length_Of_Edge(this.Points[0], this.Points[2]);
            double Edge6 = Point.Length_Of_Edge(this.Points[1], this.Points[3]);
            if (Edge1 == Edge3 && Edge2 == Edge4 && Edge5 == Edge6)
            {
                return true;
            }
            return false;
        }
        public override void input()
        {
            while (true)
            {
                System.Console.WriteLine("enter Recangle: ");
                System.Console.WriteLine("Note: You must enter the points that form a rectangle. The order of vertices A, B, C, D forms a ring.");
                for (int i = 1; i <= this.Number_Of_Points; i++)
                {
                    System.Console.WriteLine("enter Point " + i + " : ");
                    this.Points[i - 1].input();
                }
                if (checkShape() == false)
                {
                    System.Console.WriteLine("Some points are wrong, please re-enter");
                    continue;
                }
                System.Console.WriteLine(" ");
                setLength();
                setWide();
                break;
            }
        }
        public void setWide()
        {
            this.Wide = Math.Min(Point.Length_Of_Edge(this.Points[0], this.Points[1]), Point.Length_Of_Edge(this.Points[1], this.Points[2]));
        }
        public void setLength()
        {
            this.Length = Math.Max(Point.Length_Of_Edge(this.Points[0], this.Points[1]), Point.Length_Of_Edge(this.Points[1], this.Points[2]));
        }
        public override double Perimeter()
        {
            return 2 * (this.Length + this.Wide);
        }
        public override double Area()
        {
            return this.Length * this.Wide;
        }
        public override void output()
        {
            System.Console.WriteLine("Name Shape: " + this.Name);
            System.Console.WriteLine("Position of points: ");
            for (int i = 1; i <= this.Number_Of_Points; i++)
            {
                System.Console.WriteLine("Position of Point " + i + " : ");
                this.Points[i - 1].output();
            }
            System.Console.WriteLine("Wide: " + this.Wide);
            System.Console.WriteLine("Length: " + this.Length);
            System.Console.WriteLine("Perimeter: " + Perimeter());
            System.Console.WriteLine("Area: " + Area());
        }
    }
    class Square : Recangle
    {
        private double Edge;
        public Square()
        {
            base.setup_Number_Of_Points("Square");
        }
        public override void input()
        {
           while (true)
           {
                System.Console.WriteLine("enter Points: ");
                for (int i = 1; i <= this.Number_Of_Points; i++)
                {
                    System.Console.WriteLine("enter Point " + i + " : ");
                    this.Points[i - 1].input();
                }
                if (checkShape() == false)
                {
                    System.Console.WriteLine("Some points are wrong, please re-enter");
                    continue;
                }
                setEdge();
                break;
           }
        }
        public override bool checkShape()
        {
            double Edge1 = Point.Length_Of_Edge(this.Points[0], this.Points[1]);
            double Edge2 = Point.Length_Of_Edge(this.Points[1], this.Points[2]);
            double Edge3 = Point.Length_Of_Edge(this.Points[2], this.Points[3]);
            double Edge4 = Point.Length_Of_Edge(this.Points[3], this.Points[0]);
            double Edge5 = Point.Length_Of_Edge(this.Points[0], this.Points[2]);
            double Edge6 = Point.Length_Of_Edge(this.Points[1], this.Points[3]);
            if (Edge1 == Edge3 && Edge2 == Edge4 && Edge5 == Edge6 && Edge1 == Edge2) 
            {
                return true;
            }
            return false;
        }
        public void setEdge()
        {
            Point.Length_Of_Edge(this.Points[0], this.Points[1]);
        }
        public override double Area()
        {
            return this.Edge * this.Edge;
        }
        public override double Perimeter()
        {
            return 4 * this.Edge;
        }
        public override void output()
        {
            System.Console.WriteLine("Name Shape: " + this.Name);
            System.Console.WriteLine("Position of Points: ");
            for (int i = 1; i <= this.Number_Of_Points; i++)
            {
                System.Console.WriteLine("Position of point " + i + " : ");
                this.Points[i - 1].output();
            }
            System.Console.WriteLine("Edge: " + this.Edge);
            System.Console.WriteLine("Perimeter: " + Perimeter());
            System.Console.WriteLine("Area: " + Area());
        }
    }
    class Start
    {
        private string[] s;
        private int Number_Of_Shapes;
        private Shape[] shapes;
        public Start()
        {
            this.Number_Of_Shapes = 1;
            shapes = new Shape[1];
            shapes[0] = new Shape();
            this.s = new string[] {"Circle", "Triangle", "Recangle", "Square"};
        }
        public void input()
        {
            System.Console.Write("enter the Number of shapes: ");
            this.Number_Of_Shapes = Convert.ToInt32(System.Console.ReadLine());
            this.shapes = new Shape[this.Number_Of_Shapes];
            Random random = new Random();
            for (int i = 0; i < this.Number_Of_Shapes; i++)
            {
                int randomNumber = random.Next(0, 3);
                if (this.s[randomNumber] == "Circle")
                {
                    shapes[i] = new Circle();
                    shapes[i].input();
                }
                else if (this.s[randomNumber] == "Triangle")
                {
                    shapes[i] = new Triangle();
                    shapes[i].input();
                }
                else if (this.s[randomNumber] == "Recangle")
                {
                    shapes[i] = new Recangle();
                    shapes[i].input();
                }
                else
                {
                    shapes[i] = new Square();
                    shapes[i].input();
                }
            }
        }
        public void output()
        {
            System.Console.WriteLine("===================================");
            System.Console.WriteLine("LIST SHAPES");
            for (int i = 0; i < this.Number_Of_Shapes; i++)
            {
                shapes[i].output();
            }
        }
    }
    class Problem1_1
    {
        public static void Main(string[] args)
        {
           Start st = new Start();
           st.input();
           st.output();
        }
    }
}
