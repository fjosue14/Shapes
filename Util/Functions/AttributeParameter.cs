using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Functions
{
    /// <summary>
    /// Atributa para saber cuantos parametros espera la clase 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                       AttributeTargets.Struct)]
    public class AttributeParameter : Attribute
    {
        public int parameter;
        public AttributeParameter(int parameter)
        {
            this.parameter = parameter;
        }
    }
}
