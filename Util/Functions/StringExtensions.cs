using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Functions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Metodos para hacer la primera letra en mayuscula
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>string con la primera letra en mayuscula</returns>
        public static string ToCapitalize(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
