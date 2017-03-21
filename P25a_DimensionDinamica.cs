/*P25a)	DimensionDinamica: 
 * Pide al usuario el tamaño de una tabla de enteros [10..50]. 
 * Se construye la tabla de enteros tabEnt con dicho tamaño. 
 * Luego va pidiendo los valores de los elementos de la tabla [-200..500], hasta que introduzcas un 0 ó 
   se hayan cargado todos. 
 * Por último mostrará todos los elementos de tabEnt precedidos por su índice. Ejemplo:  0) 24.
   Nota: Por supuesto, utilizaremos CapturaEntero.
*/
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static int CapturaEntero(int min, int max, string texto)
    {
        int miEntero;
        bool esEntero;

        do
        {
            Console.Write("\n\t{0} [{1}..{2}]: ", texto, min, max);
            esEntero = int.TryParse(Console.ReadLine(), out miEntero);

            if (!esEntero)  // Comprobamos el formato
                Console.WriteLine("\n** Error. no ha introducido un número entero **");
            else if (miEntero < min || miEntero > max) // Comprobamos el rango
                Console.WriteLine("\n** Error. Valor fuera de rango **");

        } while (!esEntero || miEntero < min || miEntero > max);

        return miEntero;
    }

    static void Main(string[] args)
    {
        int tamañoTabla;
        int[] tabEnt; //<-- Declaramos la tabla (todavía no sabemos su tamaño)

        // 1º Pedimos el tamaño de la tabla
        tamañoTabla = CapturaEntero(10, 50, "Dime el tamaño de la tabla");

        // 2º Construimos la tabla
        tabEnt = new int[tamañoTabla];

        // 3º Damos valores a los elementos de la tabla
        for (int i = 0; i < tamañoTabla; i++)
        {
            tabEnt[i] = CapturaEntero(-200, 500, ("¿valor de la posición " + i + "?"));
            if (tabEnt[i] == 0) // Si introduce 0, me salgo del bucle
                break;
        }


        // 4º Presentamos los valores con su índice
        for (int i = 0; i < tamañoTabla; i++) // también se puede poner tabEnt.Length
        {
            Console.WriteLine("{0}) {1}", i, tabEnt[i]);
        }

        Console.Write("\n\n\n\t\tPulsa Intro para salir");
        Console.ReadLine();
    }
}