using IBussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Functions;

namespace BussinesLogic
{
    //clase del cuadrado
    //clase del cuadrado
    [AttributeParameter(3)]
    public class Square :  IShape
    {
        public int id { get; set; }
        public Points points { get; set; }
        public double side { get; set; }
 
        public void setValues(string[] p, int id)
        {
            try
            {
                this.id = id;
                this.points = new Points(double.Parse(p[0]), double.Parse(p[1]));
                this.side = double.Parse(p[2]);
            }
            catch (Exception)
            {
                throw new Exception("The parameters must be numeric");
            }
        }
        public void printShape()
        {
            Console.WriteLine($"Shape {this.id}: Square upper left corner at ({this.points.x}, {this.points.y}) and sizes {this.side}");
        }

        

        public bool shapeExists(double x, double y)
        {

            bool exist = (x < this.points.x + this.side) && (x > this.points.x) &&
                        (y < this.points.y + this.side) && (y > this.points.y);


            if (exist)
            {
                double area = this.side * this.side;
                printShape();
                Console.WriteLine($"Area of: {area}\n");
            }

            return exist;

        }



    }
}
