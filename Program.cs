namespace Figure
{

    abstract class Figure
    {
        public abstract double CalcSurface();
        public abstract void Input();
        public abstract void Output();

    }
    class Square : Figure
    {
        private int x;
        private int y;
        private int size;
        public Square() { }

        public Square(int x, int y, int size)
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public int getX()
        {
            return x;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public int getY()
        {
            return y;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public int getSize()
        {
            return size;
        }
        public void setSize(int size)
        {
            this.size = size;
        }
        public override double CalcSurface()
        {
            return size * size;
        }

        public override void Input()
        {
            Console.Write("x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("size: ");
            size = Convert.ToInt32(Console.ReadLine());

        }
        public override void Output()
        {
            Console.WriteLine("------------- output-------------------");
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);
            Console.WriteLine("size: " + size);
            Console.WriteLine("circle surface: " + CalcSurface());
        }
    }
    class Circle : Figure
    {
        private int x;
        private int y;
        private int radius;

        public Circle() { }
        public Circle(int x, int y, int radius)
        {
            this.radius = radius;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public int getY()
        {
            return y;
        }
        public void setY(int y)
        {
            this.y = y;
        }

        public int getRaduis()
        {
            return radius;
        }
        public void setRaduis(int radius)
        {
            this.radius = radius;
        }
        public override void Input()
        {
            Console.Write("x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("radius: ");
            radius = Convert.ToInt32(Console.ReadLine());

        }
        public override void Output()
        {
            Console.WriteLine("------------- output-------------------");
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);
            Console.WriteLine("radius: " + radius);
            Console.WriteLine("circle surface: " + CalcSurface());
        }
        public override double CalcSurface()
        {
            return Math.PI * radius * radius;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Figure f1, f2;
            f1 = new Square(10, 20, 5);
            f2 = new Circle(20, 10, 2);

            double surface = f1.CalcSurface();
            Console.WriteLine("square surface: " + surface);

            surface = f2.CalcSurface();
            Console.WriteLine("circle surface : " + surface);*/
            List<Figure> figures = new List<Figure>();

            Figure f1, f2;
            f1 = new Circle();
            f2=new Square();
            figures.Add(f1);
            figures.Add(f2);
            foreach(Figure f in figures)
            {
                try
                {
                    f.Input();
                    f.Output();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("all value must be integer number ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } 

        }
    }
}