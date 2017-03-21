/* P31b)  GuardarNMultiplosDesde: 
Construye un método de nombre NMultiplosDesde que…
•	Recibe: Tres enteros num, cantidad y numDesde.
•	Hace: Construye un vector de tamaño cantidad  y guarda en él los primeros múltiplos de num que indique cantidad a partir de numDesde sin incluir éste.
Ejemplo: si num=19; cantidad=300 y numdesde=1000, guardará los 300 primeros múltiplos de 19 a partir del 1000.
•	Devuelve: la tabla construida.
En el programa se pedirá un número de dos cifras, la cantidad de sus múltiplos a representar y el número a partir del cual hallar los múltiplos, y se llamará a este método.
Luego se le pedirá el nombre del fichero en el que guardar los valores de la tabla. El programa añadirá la extensión .TXT al nombre del fichero y lo construirá. Luego guardará en dicho fichero —de la carpeta de pruebas— todos los valores, separados entre sí por el carácter ‘;’ (punto y coma)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO; // <-- Necesario para trabajar con ficheros

class Program
{
    public static int CapturaEntero(string mensaje, int min, int max)
    {
        int valor = 0;
        bool esCorrecto = false;
        do
        {
            Console.Write("{0} ({1}..{2}): ", mensaje, min, max);
            esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);//el usuario escribe algo y pulsa INTRO
            if (!esCorrecto || valor < min || valor > max)
            {
                Console.WriteLine(" ** NO VALIDO. ({0} a {1})  ** Pulsa Intro", min, max);
                Console.Beep(400, 400);
            }
        }
        while (!esCorrecto || valor < min || valor > max);

        return valor;
    }

    static int[] NMultiplosDesde(int num, int cantidad, int numDesde)
    {
        int[] vector = new int[cantidad];
        // averiguamos el primer múltiplo a partir de numDesde.
        int multiplo = num * (numDesde / num) + num;

        for (int i = 0; i < cantidad; i++)
        {
            vector[i] = multiplo + (num * i);
        }

        return vector;
    }

    public static void Main()
    {
        // Declaramos un stream de escritura
        StreamWriter fichW;
        int num2c = CapturaEntero("\n\tDime el número del que hallar sus múltiplos", 10, 99);
        int cantidad = CapturaEntero("\tDime la cantidad de múltiplos a guardar", 10, 1000);
        int aPartirDe = CapturaEntero("\tA partir de qué valor hallamos sus múltiplos?", 1000, 10000);

        int[] tablaMul = NMultiplosDesde(num2c, cantidad, aPartirDe);
        Console.Write("\n\tDime el nombre del archivo en el que guardarlo");
        string nombreArchivo = Console.ReadLine() + ".TXT";

        fichW = File.AppendText(@"C:\zDatosPruebas\" + nombreArchivo);

        for (int i = 0; i < cantidad; i++)
        {
            fichW.Write(tablaMul[i] + ";");
        }

        //// Recorrido usando foreach en lugar del for
        //foreach (int numero in tablaMul)
        //{
        //    fichW.Write(numero + ";");
        //}


        // Lo cerramos
        fichW.Close();


        Console.WriteLine("\n\nPulsa Intro pa salir");
        Console.ReadLine();
    }

}