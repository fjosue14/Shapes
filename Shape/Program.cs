using BussinesLogic;
using IBussinesLogic;
using System.Globalization;
using Util;
using Util.Functions;

public class Program
{
    static int id = 0;// Se utiliza una variable auto incremental para que se mas facil identificar para el usuario, tambien se peso usar un uuid.
                      //Se utiliza una lista debido a que se facilita a la hora de hacer iteraciones, ademas que los arreglos se definen con una cantida fija en memori y que los diccionarios consumirian mayor menoria
    static List<IShape> lshape;
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        lshape = new List<IShape>();
        bool exit = false;
        Console.Title = "Shape Exercise";
        Console.WriteLine("Shape Exercise\nFernando Hernandez");
        while (!exit)
        {
            //procesa la linea capturada en la consola
            string line = Console.ReadLine().Trim();
            if (!line.Equals(string.Empty))
            {
                exit = proccessLine(line);
            }
            else
            {
                Console.WriteLine("Select an option");
                Help.Show();
            }

        }
        Environment.Exit(0);
    }

    public static bool proccessLine(string line)
    {
        bool result = false;
        string[] parameters = line.Split(' ');

        //transforma la primera letra en mayuscula
        string opc = parameters[0].ToString().ToCapitalize();

        //Si solo hay dos parametros verifica que sean numericos para realizar la busqueda
        if (parameters.Length == 2)
        {
            double x = double.Parse(parameters[0]);
            double y = double.Parse(parameters[1]);
            //antes de buscar verifica que hayan items, sino muestra mensaje
            if (lshape.Count() > 0)
            {
                int counter = 0;
                lshape.ForEach(shape => { if (shape.shapeExists(x, y)) counter++; });

                if (counter == 0)
                {
                    Console.WriteLine("No data found");
                }
            }
            else
            {
                Console.WriteLine("There is no data to look for");
            }

            return false;
        }

        //verifica el valor del primer paramtero
        switch (opc)
        {
            case Constant._CIRCLE:
            case Constant._SQUARE:
            case Constant._RECTANGLE:
            case Constant._TRIANGLE:
            case Constant._DONUT:
                try
                {
                    IShape shape = ShapeBL.Get(opc, parameters, id);
                    lshape.Add(shape);
                    id++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case Constant._EXIT:
                result = true;
                break;
            case Constant._HELP:
                Help.Show();
                break;
            default:
                //sino es ninguna de las opciones anteriores, verifica si es una direccion del archivo
                if (File.Exists(opc))
                {
                    //Valida que la extension del archivo sea valida
                    if (Path.GetExtension(opc).ToUpper().Equals(Constant._TXT))
                        ShapeBL.Process(opc, ref lshape, ref id);//procesa las lineas del archivo
                    else
                        Console.WriteLine($"Extension file invalid.");
                }
                //varifica si la escribio algo en la consola
                else if (!opc.Equals(string.Empty))
                {
                    Console.WriteLine($"Value \"{opc}\" doesn't match with an option or a valid path.");
                    Help.Show();
                }
                else
                {
                    Console.WriteLine("Select an option");
                    Help.Show();
                }
                break;
        }

        return result;
    }
}