/* P23c)	ColocaNums0_99: 
Repetir el anterior pero colocándolos de forma aleatoria en 100 intentos.

Avanzado: Además, hacer que se produzca un bip, en el que la frecuencia se calcule a partir del número. 			
 Console.Beep(int frecuencia, int duración)
*/


using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void ColocaElNumero(int i)
    {
        int columna, fila;
        columna = 6 + 7 * (i % 10); // salto de columna * valor de la unidad de i
        fila = 2 + 2 * (i / 10);    // salto de fila * valor de la decena de i
        Console.SetCursorPosition(columna, fila);
        Console.Write("{0}", i);
        //Console.Beep(100 * i + 200, 100);// Por tanteo calculo la frecuencia en función de num
    }


    static void Main(string[] args)
    {
        Random azar = new Random();
        int num;
        for (int i = 0; i < 100; i++) // cien intentos
        {
            num = azar.Next(100);       // Obtengo un número al azar [0..99]
            ColocaElNumero(num);        // Lo coloco en su posición de la pantalla
        }


        Console.SetCursorPosition(25, 23); // Para que no me salga el texto siguiente detrás del último número escrito
        Console.Write("Pulsa Intro para salir");
        Console.ReadLine();

    }


}
