/*
/* P32f_Películas:  
 * Se te entrega un fichero en el que hemos copiado el contenido de un directorio de películas, 
 * con todos sus datos, tal como sale de la instrucción:         dir G:\Peliculas > pelis.TXT 
 * (Nota: hemos quitado las líneas que sobran)  Observa las líneas del fichero para ver lo que ocupa cada concepto y 
 * los separadores que aparecen. Se pretende realizar un programa que muestre en pantalla la tabla de películas con 
 * la siguiente cabecera: Nº Película Formato Tamaño          Donde  Nº es el número de orden en que se lee del
 * fichero Película es el nombre de la película antes del punto de la extensión. Formato: Ejemplos: AVI o MKV o MPG… 
 * (en mayúsculas) aparece detrás del punto del nombre. Tamaño: En Gb con dos decimales. Ej.: 2,18  
Avanzado: que aparezca el nombre sin la valoración (Lo que está entre paréntesis al final del nombre) 
 * y haya una columna con la Valoración. En esta columna sólo debe aparecer la valoración sin los paréntesis.  
Nota: Se puede utilizar cualquier método de la clase string
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace P32f_Peliculas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listaPelis = new List<string>();
            StreamReader fichero = new StreamReader(@"Datos\pelis.TXT", Encoding.Default);

            while (!fichero.EndOfStream)
            {
                //listaPelis.Add(fichero.ReadLine()); // Así sería si quiero leer la linea completa, pero como sé que só me sirve a partir del caracter 22...
                listaPelis.Add(fichero.ReadLine().Substring(22)); // Sólo guardo la par útil del registro
            }
            // vamos a presentar
            string strTam, nombre, formato, valoración;
            double tam;

            Console.WriteLine("  Nº\tPelícula Formato   Tamaño    Valoración"); //Imprime la cabecera.
            //for (int i = 0; i < listaPelis.Count; i++)
            int num = 1;
            string[] tablaParaSplit;
            int pos;
            foreach (string linea in listaPelis)
            {
                //El tamaño comienza en la posición 0 y tiene una longitud máxima de 13 caracteres
                strTam = linea.Substring(0, 13).Trim();
                // convierto la cadena en double
                tam = Math.Round(Convert.ToDouble(strTam) / 1000000000, 2);

                //El nombre completo, con valoración y extensión, comienza en la posición 14 y llega hasta el final
                nombre = linea.Substring(14).Trim();
                tablaParaSplit = nombre.Split('(', ')'); // Con esto, el nombre quedará en la posición 0 y la valoración en la posición 1 y el resto en la 2
                valoración = tablaParaSplit[1];
                // para el formato lo pasamos a mayúsculas y le quitamos el punto
                //formato = tablaParaSplit[2].ToUpper().Replace(".",""); // Una forma de hacerlo con Split
                pos = nombre.LastIndexOf('.');
                formato = nombre.Substring(pos + 1).ToUpper(); // Otra forma sin split

                Console.WriteLine("  {0}\t{1}\t{2}\t{3}\t{4}", num++, tablaParaSplit[0].PadRight(36, '.'), formato, valoración, tam);

            }



            Console.ReadKey();
        }
    }
}
