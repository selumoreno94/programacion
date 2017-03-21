/* P31a)  Escribir en Fichero 1
Construye un programa que vaya leyendo las frases que el usuario teclea y 
las guarde en un fichero de texto. 
Terminará cuando la frase introducida sea "fin" (esa frase no deberá guardarse en el fichero). 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO; // <-- Necesario para trabajar con ficheros

class Program
{
    public static void Main()
    {

        // Declaramos un stream de escritura
        StreamWriter fichW1;

        /* Version construyéndolo con la clase File
        // Lo asociamos a un fichero físico
        //fichW1 = File.CreateText(@"C:\zDatosPruebas\textos1.txt");
        fichW1 = File.AppendText(@"C:\zDatosPruebas\textos1.txt");
        */
        // Versión construyéndolo con uno de sus constructores
        fichW1 = new StreamWriter(@"C:\zDatosPruebas\textos2.txt", false, Encoding.Unicode);


        // Escribimos en él
        Console.WriteLine("Comienza a escribir el texto");
        // uso una variable auxiliar (porque somos muy chiquetitos:))
        string frase = "";

        frase = Console.ReadLine();     // Leo del teclado
        while (frase != "fin")
        {
            // escribo la frase en "mi fichero" 
            fichW1.WriteLine(frase);

            // Leo del teclado la siguiente frase
            frase = Console.ReadLine();

        }

        // Lo cerramos
        fichW1.Close();


        Console.WriteLine("\n\nPulsa Intro pa salir");
        Console.ReadLine();
    }

}