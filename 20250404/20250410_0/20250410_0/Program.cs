namespace ConsoleApp1
{

    //OCP
    //class Circle
    //{
    //    public double radius {  get; set; }
    //    public Circle(double radius)
    //    {
    //        this.radius = radius;
    //    }
    //}
    //class Rectangle
    //{
    //    public double width { get; set; }
    //    public double height { get; set; }
    //    public Rectangle(double width, double height)
    //    {
    //        this.width = width;
    //        this.height = height;
    //    }
    //}
    //class AreaCal
    //{
    //    public double CalArea(object shape)
    //    {
    //        if(shape is Circle circle)
    //        {
    //            return Math.PI * circle.radius * circle.radius;
    //        }
    //        else if(shape is Rectangle rectangle)
    //        {
    //            return rectangle.width * rectangle.height;
    //        }
    //        return 0;
    //    }
    //}
    //ocp적용하면?
    interface IShape
    {
        double GetArea();
    }
    class Circle : IShape
    {
        public double radius { get; set; }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double GetArea() 
        {
            return Math.PI * radius * radius;
        }
    }
    class Rectangle : IShape 
    {
        public double width { get; set; }
        public double height { get; set; }
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double GetArea()
        {
            return width * height;  
        }
    }
    class Triangle : IShape
    {
        public double b { get; set; }
        public double h { get; set; }
        public Triangle(double b, double h)
        {
            this.b = b;
            this.h = h;
        }
        public double GetArea()
        {
            return (b * h)/2;
        }
    }
    class AreaCal
    {
        public static void CalArea(List<IShape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.GetArea();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>
          {
            new Circle(5),
            new Rectangle(5,5),
            new Triangle(5,10)

          };
            AreaCal.CalArea(shapes);
        }
    }
}
