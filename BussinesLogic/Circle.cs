
using IBussinesLogic;
using Util.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    //clase del circulo

    [AttributeParameter(3)]
    public class Circle : IShape
    {
        public int id { get; set; }
        public Points points { get; set; }
        public double radius { get; set; }

       
        public void setValues(string[] p, int id)
        {
            try
            {
                this.id = id;
                this.points = new Points(double.Parse(p[0]), double.Parse(p[1]));
                this.radius = double.Parse(p[2]);
            }
            catch (Exception)
            {
                throw new Exception("The parameters must be numeric");
            }

        }

        public void printShape()
        {
            Console.WriteLine($"Shape {this.id}: Circle with centre at ({this.points.x}, {this.points.y}) and radius {this.radius}");
        }

        public bool shapeExists(double x, double y)
        {
            //Se utiliza la ecuacion del circuferencia para verificar el punto 
            double r = Math.Pow(this.radius, 2);
            bool exist = Math.Pow((x - this.points.x), 2) + Math.Pow((y - this.points.y), 2) < r ;
            
            if (exist)
            {
                printShape();
                double area = Math.PI * r;
                Console.WriteLine($"Area: {area}\n");
            }
            return exist;
        }
    }
}
