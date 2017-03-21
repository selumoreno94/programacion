/* P25b_DiaDeLaSemana usando tablas (Partimos de P03a en que usábamos switch)
* Se le pide al usuario que introduzca un número entre 0 y 6, cada uno de los cuales indica el día de la semana en
 * que nos encontramos [0->Lunes...6->Domingo]. Luego pregunta cuántos días quiere avanzar numDias y el programa
 * calcula de la forma más eficiente en qué día de la semana caerá dentro de numDias
*/


using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static int CapturaEntero(string mensaje, int min, int max)
    {
        int valor = 0;
        bool esCorrecto = false;
        do
        {
            Console.Write("{0} ({1}..{2}): ", mensaje, min, max);
            esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);//el usuario escribe algo y pulsa INTRO
            if (!esCorrecto || valor < min || valor > max)
            {
                Console.WriteLine(" ** NO VALIDO. ({0} a {1})  ** Pulsa Intro", min, max);
                Console.Beep(400, 400);
            }
        }
        while (!esCorrecto || valor < min || valor > max);

        return valor;
    }

    static void Main(string[] args)
    {
        int numDias, diaDeLaSemana, diaDeLaSemanaFinal;
        string[] tabDiaSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
        diaDeLaSemana = CapturaEntero("\nIntroduce un dia de la semana del 0 (lunes) al 6 (domingo): ", 0, 6);

        Console.WriteLine("\n\tHoy es {0}", tabDiaSemana[diaDeLaSemana]);
        Console.Write("\tIntroduce cuántos días quieres avanzar: ");
        numDias = Convert.ToInt32(Console.ReadLine());

        diaDeLaSemanaFinal = (numDias + diaDeLaSemana) % 7;



        //---- Control del plural de la frase final (esto es opcional) 
        // Versión 1: usando una variable.
        //char plural = '\0'; // <-- carácter nulo
        //if (numDias != 1) 
        //    plural = 's'; // <-- Si es más de uno será una 's' de plural
        //Console.WriteLine("\n\tEstamos a " + nombreDiaSemana +  " y dentro de " + numDias + " día" + plural + " será " + nombreDiaSemanaFinal);

        // Versión 2: sin usar variable.
        if (numDias == 1)
            Console.WriteLine("\n\tEstamos a " + tabDiaSemana[diaDeLaSemana] + " y dentro de 1 día será " + tabDiaSemana[diaDeLaSemana + 1]);
        else
            Console.WriteLine("\n\tEstamos a " + tabDiaSemana[diaDeLaSemana] + " y dentro de " + numDias + " días será " + tabDiaSemana[diaDeLaSemanaFinal]);

        Console.WriteLine("\n\n\t\tPulsa Intro para salir");
        Console.ReadLine();

    }
}
