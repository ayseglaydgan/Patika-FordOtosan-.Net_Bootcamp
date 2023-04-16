using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.TestLayer
{
    public abstract class Shape
    {
        public abstract double area();
    }
    class Circle : Shape
    {
        private double radius;
        public Circle(double r)
        {
            radius = r;
        }
        public override double area()
        {
            return (3.14 * radius * radius);
        }
    }
    class Square : Shape
    {
        private double side;
        public Square(double s)
        {
            side = s;
        }
        public override double area()
        {
            return (side * side);
        }
    }
    class Triangle : Shape
    {
        private double tbase;
        private double theight;
        public Triangle(double b, double h)
        {
            tbase = b;
            theight = h;
        }
        public override double area()
        {
            return (0.5 * tbase * theight);
        }
    }

    public class AbstractionTest
    {
        [Test]
        public void Test3()
        {
            Circle c = new Circle(5.0);
            Console.WriteLine("Area of Circle = {0}", c.area());
            Square s = new Square(2.5);
            Console.WriteLine("Area of Square = {0}", s.area());
            Triangle t = new Triangle(2.0, 5.0);
            Console.WriteLine("Area of Triangle = {0}", t.area());
        }
    }
}
