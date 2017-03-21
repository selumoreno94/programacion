/* P28b)	PruebaListaMétodos: 
Repetir el apartado anterior, es decir
1)	Cargar una tabla de enteros cuyo tamaño se pide al usuario [10..90] con valores al azar de dos cifras.
2)	Cargar una lista de enteros con los valores de la tabla anterior.
3)	Mostrar en pantalla, en una columna, los valores de la tabla
4)	Mostrar en pantalla, en una columna a la derecha de la anterior, los valores de la Lista. Compáralos con los valores de la tabla.
5)	Ordenar la lista y mostrarla a la derecha de las dos columnas anteriores

* pero utilzando los métodos siguientes, además de CapturaEntero.
1)	GeneraTabla: Recibe el tamaño de la tabla y devuelve una tabla de dicho tamaño, cargada con números aleatorios
                 de dos cifras. Utilizaremos este método para obtener la primera tabla.
2)	MuestraColeccion: Recibe una tabla de enteros. 
                      Muestra los elementos de la tabla en vertical, a la izquierda de la pantalla.
3)	MuestraColeccion: Recibe una lista de enteros y un entero col. 
                      Muestra los elementos de la lista colocados en la columna que indique col.
4)	Pausa: Recibe un texto y muestra el mensaje “Pulsa una tecla para “ + texto. 
           Esperará una pulsación para que continúe el programa.

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

    static int[] GeneraTabla(int tamañoTabla)
    {
        Random azar = new Random(); // <-- Para obtener los valores al azar
        int[] tablaEnteros = new int[tamañoTabla];
        // 1) Cargamos la tabla
        // para eso hay que recorrerla
        for (int i = 0; i < tamañoTabla; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        {
            tablaEnteros[i] = azar.Next(10, 100); // <--  así escribimos un número entre 10 y 99 (dos cifras)
        }
        return tablaEnteros;
    }

    static void MuestraColeccion(int[] tabla)
    {
        for (int i = 0; i < tabla.Length; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        {
            Console.WriteLine("{0}", tabla[i]);
        }
    }

    static void MuestraColeccion(List<int> lista, int col)
    {
        int fila = 0;
        for (int i = 0; i < lista.Count; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        {
            Console.SetCursorPosition(col, fila++);
            Console.WriteLine("{0}", lista[i]);
        }
    }

    static void Pausa(string texto)
    {
        Console.WriteLine("\n\n\tPulsa una tecla para {0}", texto);
        Console.ReadKey(true);
    }
    static void Main(string[] args)
    {
        int[] tablaEnteros;
        List<int> listaEnteros;
        // Pedimos el tamaño de la tabla
        int tamañoTabla = CapturaEntero("\n\nDime el tamaño de la tabla", 10, 90);

        // 1)----- Generar una tabla de enteros
        tablaEnteros = GeneraTabla(tamañoTabla);

        // 2)----- Cargamos la lista con los valores de la tabla
        //----- Forma Tracicional ------------
        //// Construimos la lista (que lo podríamos haber hecho en la misma declaración)
        //listaEnteros = new List<int>();

        //// Recorremos la tabla para añadir sus valores a la lista 
        //for (int i = 0; i < tamañoTabla; i++)  // si no tenemos el tamaño ponemos  tablaEnteros.Length
        //{
        //    listaEnteros.Add(tablaEnteros[i]);
        //}

        //----- Forma Actual y corta ------------
        listaEnteros = tablaEnteros.ToList<int>();

        // 3)----- Mostrar en pantalla los valores de la tabla
        Console.Clear();
        MuestraColeccion(tablaEnteros);

        // 4)----- Mostrar en pantalla los valores de la Lista, en la columna 10
        Pausa("ver la lista");

        MuestraColeccion(listaEnteros, 10);

        //5)----- Ordenar la lista y mostrarla en la columna 20
        Pausa("ver la lista ordenada");

        //a) Ordenamos la lista... 
        listaEnteros.Sort();

        //b)...y mostrarla en la columna 20
        MuestraColeccion(listaEnteros, 20);


        //6)----- Invertir el orden de la lista y mostrarla en la columna 30
        Pausa("ver la lista en orden inverso");

        //a) Invertimos el orden ... 
        listaEnteros.Reverse();

        //b)...y mostrarla en la columna 30
        MuestraColeccion(listaEnteros, 30);

        // en el siguiente mensaje se ponen los espacios para borrar de la pantalla el resto del mensaje anterior
        Pausa("salir                                 ");

    }
}
