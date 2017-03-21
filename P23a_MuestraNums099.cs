/* P23a_TablanumsNums099
Presentar una tabla de números, del 0 al 99 en 10 filas de 10 columnas, separando las filas una posición, 
para que queden bien distribuidos.

Avanzado: Además, hacer que se produzca un bip, en el que la frecuencia se calcule a partir del número. 			
 Console.Beep(int frecuencia, int duración)
*/


using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void MuestraNums099()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i % 10 == 0) // <-- Si es múltiplo de 10 doy un salto de línea
                Console.WriteLine();

            Console.Write("  {0}\t", i);
        }
    }


    static void Main(string[] args)
    {
        MuestraNums099();

        
        Console.Write("\n\n\t\tPulsa Intro para salir");
        Console.ReadLine();

    }
}
