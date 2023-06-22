using IBussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Functions;

namespace BussinesLogic
{
    [AttributeParameter(4)]
    public class Rectangle : IShape
    {
        public int id { get; set; }
        public Points points { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public void setValues(string[] p, int id)
        {
            try
            {
                this.id = id;
                this.points = new Points(double.Parse(p[0]), double.Parse(p[1]));
                this.width = double.Parse(p[2]);
                this.height = double.Parse(p[3]);
            }
            catch (Exception)
            {
                throw new Exception("The parameters must be numeric");
            }
        }

        public void printShape()
        {
            Console.WriteLine($"Shape {this.id}: Rectangle upper left corner at ({this.points.x}, {this.points.y}) and width size {this.width} and height size {this.height}");
        }



        public bool shapeExists(double x, double y)
        {

            bool exist = (x < this.points.x + this.width) && (x > this.points.x) &&
                        (y < this.points.y + this.height) && (y > this.points.y);
            if (exist)
            {
                double area = this.width * this.height;
                printShape();
                Console.WriteLine($"Area: {area}\n");
            }
            return exist;
        }
    }
}
