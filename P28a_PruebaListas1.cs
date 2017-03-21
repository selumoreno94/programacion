/* P28a)	PruebaLista1: 
1)	Cargar una tabla de enteros cuyo tamaño se pide al usuario [10..90] con valores al azar de dos cifras.
2)	Cargar una lista de enteros con los valores de la tabla anterior.
3)	Mostrar en pantalla, en una columna, los valores de la tabla
4)	Mostrar en pantalla, en una columna a la derecha de la anterior, los valores de la Lista. Compáralos con los valores de la tabla.
5)	Ordenar la lista y mostrarla a la derecha de las dos columnas anteriores
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int CapturaEntero(string texto, int min, int max)
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
        int[] tablaEnteros;
        List<int> listaEnteros;
        // Pedimos el tamaño de la tabla
        int tamañoTabla = CapturaEntero("\n\nDime el tamaño de la tabla", 10, 90);
        // Construimos la tabla
        tablaEnteros = new int[tamañoTabla];

        Random azar = new Random(); // <-- Para obtener los valores al azar

        // 1) Cargamos la tabla
        // para eso hay que recorrerla
        for (int i = 0; i < tamañoTabla; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        {
            tablaEnteros[i] = azar.Next(10, 100); // <--  así escribimos un número entre 10 y 99 (dos cifras)
        }

        // 2) Cargamos la lista con los valores de la tabla

        // Construimos la lista (que lo podríamos haber hecho en la misma declaración)
        listaEnteros = new List<int>();

        // Recorremos la tabla para añadir sus valores a la lista 
        for (int i = 0; i < tamañoTabla; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        {
            listaEnteros.Add(tablaEnteros[i]);
        }

        // 3) Mostrar en pantalla los valores de la tabla
        Console.Clear();
        for (int i = 0; i < tamañoTabla; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        {
            Console.WriteLine("{0}\t", tablaEnteros[i]);
        }

        Console.WriteLine("\nPulsa una tecla para ver la lista");
        Console.ReadKey(true);


        // 4) Mostrar en pantalla los valores de la Lista, a la derecha de la anterior

        int fila = 0;
        for (int i = 0; i < listaEnteros.Count; i++)
        {
            Console.SetCursorPosition(10, fila++);
            Console.Write("{0}\t", listaEnteros[i]);
        }

        Console.WriteLine("\n\nPulsa una tecla para ver la lista ordenada");
        Console.ReadKey(true);

        //5)	Ordenar la lista... 

        listaEnteros.Sort();

        //...y mostrarla a la derecha de las dos columnas anteriores
        fila = 0;
        for (int i = 0; i < listaEnteros.Count; i++)
        {
            Console.SetCursorPosition(20, fila++);
            Console.Write("{0}\t", listaEnteros[i]);
        }

        Console.WriteLine("\n\nPulsa una tecla para ver la lista en orden inverso");
        Console.ReadKey(true);

        //5)	Invertimos el orden ... 

        listaEnteros.Reverse();

        //...y mostrarla a la derecha de las columnas anteriores
        fila = 0;
        for (int i = 0; i < listaEnteros.Count; i++)
        {
            Console.SetCursorPosition(30, fila++);
            Console.Write("{0}\t", listaEnteros[i]);
        }


        Console.WriteLine("\n\nPulsa una tecla para salir                                 ");
        Console.ReadKey(true);

    }
}
