/* P23b)	ColocaNums0_99: 
Repetir el apartado anterior, pero calculando la posición de cada número en función de su valor. 
Nota: Para esto hay que hacerlo utilizando Console.SetCursorPosition(columna,fila) 
Donde:   columna = 6 + 7 * <unidad del número> 		
            fila = 2 + 2 * <decena del número >;   
 
Valor añadido: Además, hacer que se produzca un bip en el que la frecuencia también se calcule a partir del número. 
 Console.Beep(int frecuencia, int duración).
*/


using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void ColocaNums099()
    {
        int columna, fila;
        for (int i = 0; i < 100; i++)
        {
            columna = 6 + 7 * (i % 10); // salto de columna * valor de la unidad de i
            fila = 2 + 2 * (i / 10);    // salto de fila * valor de la decena de i
            Console.SetCursorPosition(columna, fila);
            Console.Write("{0}", i);
        }
    }


    static void Main(string[] args)
    {
        ColocaNums099();


        Console.Write("\n\n\t\tPulsa Intro para salir");
        Console.ReadLine();

    }
}
