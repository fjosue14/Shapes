using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussinesLogic
{

    /// <summary>
    /// interfaces para el mapeo de las figuras
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Identificador unico para los registros
        /// </summary>
        int id { get; set; }
        /// <summary>
        /// Agrega los parametros para cada clase y su id
        /// </summary>
        /// <param name="p">parametros de la clase</param>
        /// <param name="id">Identificador unico</param>
        void setValues(string[] p, int id);

        /// <summary>
        /// Muestra en consola la informacion de la figura
        /// </summary>
        void printShape();
        /// <summary>
        /// Verifica si las coordenas X y Y estan dentro de la forma
        /// </summary>
        /// <param name="x">Coordena X</param>
        /// <param name="y">Coordena Y</param>
        bool shapeExists(double x, double y);

    }
}
