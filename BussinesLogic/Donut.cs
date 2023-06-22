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
    public class Donut : IShape
    {
        public int id { get; set; }
        public Points points { get; set; }
        public double radiusBig { get; set; }
        public double radiusSmall { get; set; }
        public void setValues(string[] p, int id)
        {
            try
            {
                this.id = id;
                this.points = new Points(double.Parse(p[0]), double.Parse(p[1]));

                double radius1 = double.Parse(p[2]);
                double radius2 = double.Parse(p[3]);

                if(radius1 < radius2)
                {
                    this.radiusBig = radius2;
                    this.radiusSmall = radius1;
                }
                else
                {
                    this.radiusBig = radius1;
                    this.radiusSmall = radius2;
                }
                
            }
            catch (Exception)
            {
                throw new Exception("The parameters must be numeric");
            }
        }

        public void printShape()
        {
            Console.WriteLine($"Shape {id}: Donut with centre at ({this.points.x}, {this.points.y}) and radius {this.radiusSmall} and {this.radiusBig}\n");
        }

        

        public bool shapeExists(double x, double y)
        {
            //Se utiliza la ecuacion del circuferencia para verificar el punto, donde el punto tiene que estar fuera del circulo pequeño y dentro del circulo grande
            double rB = Math.Pow(this.radiusBig, 2);
            double rS = Math.Pow(this.radiusSmall, 2);
            double circ = Math.Pow((x - this.points.x), 2) + Math.Pow((y - this.points.y), 2);

            bool exist = circ > rS && circ < rB;

            if (exist)
            {
                printShape();
                double area = Math.PI * (rB - rS);
                Console.WriteLine($"Area: {area}\n");
            }
            return exist;
        }
    }
}
