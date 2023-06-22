using IBussinesLogic;
using Util.Functions;

namespace BussinesLogic
{
    public static class ShapeBL
    {
        /// <summary>
        /// function to read a file and get data
        /// </summary>
        /// <param name="path">file path</param>
        public static void Process(string path, ref List<IShape> lshape, ref int id)
        {
            int counter = 0;
            int counterError = 0;
            string line;

            using (StreamReader file = new StreamReader(@path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    try
                    {
                        string[] parameters = line.Trim().Split(' ');
                        string opc = parameters[0].ToString().ToCapitalize();
                        IShape shape = Get(opc, parameters, id);
                        lshape.Add(shape);
                        id++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Line {counter} could not be loaded, detail: {ex.Message}\n");
                        counterError++;
                    }


                }
                Console.WriteLine($"Lines read {counter}, lines with error {counterError}, lines loaded {counter - counterError}\n");

            }
        }

        /// <summary>
        /// function to get instance of class
        /// </summary>
        /// <param name="c">class</param>
        /// <param name="p">parameters</param>
        /// <returns>IShape</returns>
        public static IShape Get(string c, string[] p, int id)
        {
            string objectToInstantiate = $"BussinesLogic.{c}, BussinesLogic";

            var objectType = Type.GetType(objectToInstantiate);
            p = p.Where(val => val.ToCapitalize() != c).ToArray();

            int pLength = p.Length;
            var AttributeParameter = objectType.GetCustomAttributes(typeof(AttributeParameter), false).First();
            int objectTypeLength = ((AttributeParameter)AttributeParameter).parameter;

            if (pLength != objectTypeLength)
            {
                throw new Exception($"The number of parameters for the {c} is {objectTypeLength} " +
                    $"and {pLength} were received\n");
            }

            dynamic instantiatedObject = Activator.CreateInstance(objectType) as IShape;

            instantiatedObject.setValues(p, id);
            instantiatedObject.printShape();

            return instantiatedObject;
        }

    }
}
