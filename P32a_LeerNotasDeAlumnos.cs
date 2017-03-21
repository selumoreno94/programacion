/*P32a)	LeerNotasDeAlumnos
Hacer un programa que vaya leyendo las líneas que hemos escrito en el fichero que guardamos con 
GuardaNotasDeAlumnos anterior y las muestre en pantalla. 
Antes de abrir el fichero, comprobará su existencia usando File.Exists(@"<ruta>"). 
 * Si no existe, dará mensaje de error y Fin.*/
using System;
using System.IO;   // Para StreamReader

public class Program
{

    public static void Main()
    {
        StreamReader fichero;
        string linea; // para guardar lo que vayamos leyendo
        //--- Apertura del stream
        Console.Write("\n\t¿Nombre del fichero a leer?: ");
        string nombreFichero = Console.ReadLine();

        // Primero averiguo si el fichero existe en la carpeta de pruebas
        string ruta = @"C:\zDatosPruebas\" + nombreFichero + ".txt";

        if (File.Exists(ruta))
            fichero = File.OpenText(ruta);
        else
        {
            Console.WriteLine("El fichero no existe. Pulsa Intro y te vas");
            Console.ReadLine();
            return;
        }

        //--- Lectura del contenido
        #region Una forma de hacerlo: Línea a línea, Controlando el fin del fichero "fichero.EndOfStream"
        //while (!fichero.EndOfStream)    // Mientras no estoy en el final del fichero
        //{
        //    linea = fichero.ReadLine(); // leo la línea...
        //    Console.WriteLine(linea);   // ... y la presento en la pantalla
        //}
        //// Si he llegado al final del fichero salimos del while
        #endregion


        #region Otra forma de hacerlo: Línea a línea, Controlando la lectura==null
        //// Leo la primera línea
        //linea = fichero.ReadLine();
        //while (linea != null)           // Mientras la línea leída no sea null
        //{
        //    Console.WriteLine(linea);   // La presento en la pantalla...
        //    linea = fichero.ReadLine(); // ... y leo la siguiente
        //}
        //// la línea ha sido null (final del fichero) salimos del while
        //// y cierro
        #endregion


        #region Otra forma: Leyendo el fichero del Tirón
        linea = fichero.ReadToEnd(); // leo la línea, que en realidad es todo el fichero...
        Console.WriteLine(linea);   // ... y la presento en la pantalla
        #endregion

        // y cierro
        fichero.Close();


        Console.WriteLine("\n\nPulsa Intro para salir");
        Console.ReadLine();
    }

}
