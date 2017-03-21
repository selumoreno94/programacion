/*P34.d)	Primitivas08aBinario4: R&W en un solo acceso
Repetir la práctica anterior pero realizando una sola escritura en el fichero .DAT y una sola lectura para presentar los datos.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Construyo el StreamReader para leer el fichero de texto
        StreamReader lectorTxt = new StreamReader(@"Datos\Primitivas08.txt");

        string linea;

        string[] tablaCampos; // crea tabla para guardar los numeros como string pero, ya tratados
        List<byte> listaBytes = new List<byte>(); // La uso porque no sé cuantos bytes voy a guardar

        while (!lectorTxt.EndOfStream)
        {
            linea = lectorTxt.ReadLine(); // Para cada línea...

            tablaCampos = linea.Split(';'); // <-- la desgloso en campos (como string's)

            // esta es la única diferencia en la escritura, respecto la versión anterior
            for (int i = 0; i < tablaCampos.Length; i++)
                listaBytes.Add(Convert.ToByte(tablaCampos[i])); // <-- /Convierto cada campo a byte y lo guardo como tal en la lista
        }
        lectorTxt.Close(); // cierro el fichero TXT de laectura

        byte[] tabBytes = listaBytes.ToArray(); // convertimos los datos de la lista en una tabla

        // En esta versión construyo el FileStream para guardar los datos en binario y poder leerlos después
        // AHORA NECESITO ACEDER EN MODO LECTURA Y ESCRITURA
        FileStream fichBin = new FileStream(@"Datos\Primitivas08.Dat", FileMode.Create, FileAccess.ReadWrite);

        // Guardamos los todos los bytes de una vez en el fichero binario
        fichBin.Write(tabBytes, 0, tabBytes.Length);

        // En este punto, el cursor del fichero binario se ha quedado al final del mismo
        // Coloco el cursor del fichero al principio del mismo para comenzar a leer

        // Con Seek salto 0 a partir del origen
        //fichBin.Seek(0, SeekOrigin.Begin);  // Utilizando el método Seek
        fichBin.Position = 0;      // Más simple, sabiendo que la primera posición es la cero

        // leemos los todos los bytes del fichero binario y lo guardamos en la tabla
        fichBin.Read(tabBytes, 0, tabBytes.Length);
        fichBin.Close();

        long cont = 0;
        Console.WriteLine("\n\tFecha\tn1   n2   n3   n4   n5   n6\tComp\tReint.\n");
        while (cont < tabBytes.Length)
        {
            #region Presentación de los datos
            Console.ForegroundColor = ConsoleColor.White;
            //--- A partir de aquí varía un poco respecto el anterior: Ya presentamos desde la tabla.
            // Presento la fecha
            Console.Write("\t{0}-{1}\t", tabBytes[cont++].ToString("00"), tabBytes[cont++].ToString("00")); // <-- Variante respecto al anterior
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Presento los demás números
            for (int i = 2; i < 8; i++)
            {
                if (tabBytes[cont] < 10)
                    Console.Write(" ");
                Console.Write("{0}   ", tabBytes[cont++]);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t{0}\t{1}", tabBytes[cont++], tabBytes[cont++]);

            #endregion
        }

        Console.WriteLine("\n\t\tPresione Cualquier Tecla para Salir");

        Console.ReadKey();
    }
}
