/*
 * P25f) PresentaFecha1
 *  Escribir el método CapturaFechaStrin, que no recibe nada, hace lo siguiente: Le pide al usuario
 *  que introduzca tres valores enters en este orden año, mes y día. Si la fecha es aceptable, devolverá
 *  la fecha en modo texto. Donde haya error, dará mensaje y pedirá de nuevo el dato.
 *  
 *   Ejemplo:     año = 2004; mes = 10; día = 8 -> Devolverá  8 de octubre de 2014
 *   
 *  Realizar también una sobrecarga de CapturaFechaString, que recibe los tres enteros, día, mes, año y 
 *  compone la fecha en modo texto y la devuelve como en la versión anterior
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string[] tMeses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
    static int[] tDiasMax = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // La utilizaremos para la sobrecarga, para hacerlo de una forma alternativa
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
    static string CapturaFechaString()
    {
        int año, mes, dia;
        año = CapturaEntero("Por favor, introduce un año", 1970, 2050);
        mes = CapturaEntero("Por favor, introduce un mes", 1, 12);
        dia = CapturaEntero("Por favor, introduce un día", 1, tDiasMax[mes]);
        return (dia + " de " + tMeses[mes] + " de " + año);
    }

    static string CapturaFechaString(int dia, int mes, int año)
    {
        return (dia + " de " + tMeses[mes] + " de " + año);
    }
    static void Main(string[] args)
    {
        string fecha;
        Console.WriteLine("\n\tProbando el método sin parámetros\n");
        fecha = CapturaFechaString();
        Console.Write("\n\t{0}", fecha);
        Console.Write("\n\t\t\t\t\tPulsa una tecla para continuar...");
        Console.ReadKey(true);

        Console.WriteLine("\n\n\tProbando el método con parámetros día, mes, año");
        int año, mes, dia;
        año = CapturaEntero("Por favor, introduce un año", 1970, 2050);
        mes = CapturaEntero("Por favor, introduce un mes", 1, 12);
        dia = CapturaEntero("Por favor, introduce un día", 1, tDiasMax[mes]);

        fecha = CapturaFechaString(dia, mes, año);
        Console.Write("\n\t{0}", fecha);

        Console.Write("\n\n\t\t\t\t\tPulsa una tecla para Salir");
        Console.ReadKey(true);
    }
}
