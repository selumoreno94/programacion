
/* P04h) MultMenoresDe500enColumnas: 
Resolver el apartado c pero en esta versión el método recibe el número de columnas en que se mostrarán los múltiplos:
1)	Recibe: Dos enteros num y  colums.
2)	Hace: Presenta los múltiplos de num menores de 500 en el número de columnas que indique colums.
3)	Devuelve: Nada.
En el programa se pedirá un número de dos cifras y el número de columnas en los que se quiere presentar [1..8]. Se llamará a este método, pasándole dichos valores.
.

*/

using System;

class Program
{
    static int CapturaEntero(string texto, int min, int max)
    {
        int num;
        bool esCorrecto;
        do
        {
            Console.Write("\n\t {0} [{1}..{2}]: ", texto, min, max);
            esCorrecto = Int32.TryParse(Console.ReadLine(), out num);
            if (!esCorrecto)
                Console.WriteLine("\n\t ** ERROR de FORMATO **");
            else if (num < min || num > max)
            {
                Console.WriteLine("\n\t ** ERROR: VALOR FUERA DE RANGO **");
                esCorrecto = false;
            }
        } while (!esCorrecto);

        return num;
    }

    static void MultiplosMenoresDe500(int n, int colums)
    {
        int mult = n;
        int cont = 0;     // <-- Contador de columnas
        while (mult < 500)
        {
            if (cont % colums == 0)     // Cuando el contador sea múltiplo del número de columnas previsto
                Console.WriteLine(); //<-- Doy un salto de linea

            cont++;

            Console.Write("{0}\t", mult);
            mult = mult + n;
        }
    }
    static void Main(string[] args)
    {
        int num, columnas;
        num = CapturaEntero("Dime el número al que encontrar sus múltiplos: ", 10, 99);
        columnas = CapturaEntero("¿Número de columnas en que los quieres mostrar?: ", 1, 8);
        // la llamada al método
        MultiplosMenoresDe500(num, columnas);


        Console.Write("\n\n\n\t\t\t\tPulsa Intro para salir");
        Console.ReadLine();

    }
}
