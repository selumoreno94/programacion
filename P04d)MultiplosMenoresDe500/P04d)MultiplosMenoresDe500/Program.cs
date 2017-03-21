/* P04d)MultiplosMenoresDe500: 
 Construir este método que:
•	Recibe: Un enteros num.
•	Hace: Presenta los múltiplos de num menores de 500.
•	Devuelve: Nada.

Prueba del método
En el programa se pedirá un número de dos cifras y se llamará a este método, 
pasándole dicho número.

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

    static void MultiplosMenoresDe500(int n)
    {
        int mult = n; // <-- El primer múltiplo.
        Console.WriteLine("\n");
        while (mult < 500)  // Mientras el múltiplo sea menor de 500
        {
            Console.Write("{0}\t", mult);   // <-- Escribo el múltiplo
            mult = mult + n;              // <-- Obtengo el siguiente
        }
    }
    static void Main(string[] args)
    {
        int num;
        num = CapturaEntero("Dime el número al que encontrar sus múltiplos: ", 10, 99);

        // la llamada al método
        MultiplosMenoresDe500(num);


        Console.Write("\n\n\n\t\t\t\tPulsa Intro para salir");
        Console.ReadLine();

    }
}
