using IBussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Functions;

namespace BussinesLogic
{
    [AttributeParameter(6)]
    public class Triangle : IShape
    {
        public int id { get; set; }
        public List<Points> points { get; set; }
        public void setValues(string[] p, int id)
        {
            try
            {
                this.id = id;

                this.points = new List<Points>();
                points.Add(new Points(double.Parse(p[0]), double.Parse(p[1])));
                points.Add(new Points(double.Parse(p[2]), double.Parse(p[3])));
                points.Add(new Points(double.Parse(p[4]), double.Parse(p[5])));
            }
            catch (Exception)
            {
                throw new Exception("The parameters must be numeric");
            }
        }
        public void printShape()
        {
            string ver = "";
            this.points.ForEach(p => ver += $"({p.x} , {p.y}) ");
            Console.WriteLine($"Shape {id}: Triangle with vertices at { ver }");
        }

        public bool shapeExists(double x, double y)
        {

            //Se utiliza el algorimo de PUNTO INTERIOR A UN TRIÁNGULO para la verificacion 
            double orientacion  = (points.ElementAt(0).x - points.ElementAt(2).x) *
                (points.ElementAt(1).y - points.ElementAt(2).y) -
            (points.ElementAt(0).y - points.ElementAt(2).y) *
                (points.ElementAt(1).x - points.ElementAt(2).x);

            double tri1 = (points.ElementAt(0).x -x) *
                (points.ElementAt(1).y - y) -
            (points.ElementAt(0).y - y) *
                (points.ElementAt(1).x - x);

            double tri2 = (x - points.ElementAt(2).x) *
                (points.ElementAt(1).y - points.ElementAt(2).y) -
            (y - points.ElementAt(2).y) *
                (points.ElementAt(1).x - points.ElementAt(2).x);

            double tri3 = (points.ElementAt(0).x - points.ElementAt(2).x) *
                (y - points.ElementAt(2).y) -
            (points.ElementAt(0).y - points.ElementAt(2).y) *
                (x - points.ElementAt(2).x);


            bool exist = (orientacion > 0 && tri1 > 0 && tri2 > 0 && tri3 > 0) || (orientacion < 0 && tri1 < 0 && tri2 < 0 && tri3 < 0);
            if (exist)
            {
                double area = Math.Abs(points.Take(points.Count - 1)
                  .Select((p, i) => (points[i + 1].x - p.x) * (points[i + 1].y + p.y))
                  .Sum() / 2);
                printShape();
                Console.WriteLine($"Area of: {area}\n");
            }
            return exist;
        }
    }
}
