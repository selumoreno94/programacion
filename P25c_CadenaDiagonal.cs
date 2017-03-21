/*P25c)	CadenaDiagonal: 
El tipo string se puede tratar en algunos aspectos como una tabla de caracteres (tiene la propiedad .Length 
y se puede acceder a sus caracteres con el [ ]). 
Teniendo esto en cuenta hacer que el programa pida una frase y la muestre en pantalla de forma inclinada, 
siguiendo la diagonal de la pantalla. 
 */
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string frase;
        int col = 0, fil = 3; // columna y fila
        // 1º Pedimos la frase
        Console.Write("\n\tDime tu frase: ");
        frase = Console.ReadLine();

        //// Presentamos la frase en diagonal (con SetCursorPosition)
        //for (int i = 0; i < frase.Length; i++)
        //{
        //    Console.SetCursorPosition(col + 2 * i, fil + i);
        //    Console.Write(frase[i]);
        //}

        //// Presentamos la frase en diagonal (colocando espacios)
        //for (int i = 0; i < frase.Length; i++)
        //{
        //    for (int j = 0; j < i; j++)
        //    {
        //        Console.Write("  ");
        //    }
        //    Console.WriteLine(frase[i]);
        //}

        // Presentamos la frase en diagonal (con una cadena que crece)
        string espacios = "  ";
        for (int i = 0; i < frase.Length; i++)
        {
            Console.WriteLine(espacios + frase[i]);
            espacios += "  ";
            if (espacios.Length == 78)
                espacios = "";
        }

        //// Presentamos la frase en diagonal Ida y vuelta (con SetCursorPosition)
        //for (int i = 0; i < frase.Length; i++)
        //{
        //    if(i<40)
        //        Console.SetCursorPosition(col + 2 * i, fil + i);
        //    else // Para que vuelva si llego al final
        //        Console.SetCursorPosition(col + 80 - 2 * (i-40), fil + i);

        //    Console.Write(frase[i]);
        //}



        Console.Write("\n\n\n\t\tPulsa Intro para salir");
        Console.ReadLine();
    }
}