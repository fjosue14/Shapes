using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Help
    {
        /// <summary>
        /// Show help message 
        /// </summary>
        public static void Show()
        {
            Console.WriteLine(
                    "-- exit: to finish the execution.\n" +
                    "-- help: to print instructions.\n" +
                    "-- look for: put two numeric values.\n" +
                    "-- Instructions: User enters the name of a shape followed by the corresponding number of numeric parameters:\n" +
                        "\tFor the circle, the numbers are the x and y coordinates of the centre followed by the radius.\n" +
                        "\tFor the square it is x and y of one corner followed by the length of the side.\n" +
                        "\tFor the rectangle it is x and y of one corner followed by the two sides.\n" +
                        "\tFor the triangle it is the x and y coordinates of the three vertices(six numbers in total).\n" +
                        "\tFor the donut it is the x and y of the centre followed by the two radiuses.\n" +
                    "-- Read a file: for read a file put a valid path, only txt files (Example: C:\\Documents\\file.txt).\n"
                );
        }

    }
}
