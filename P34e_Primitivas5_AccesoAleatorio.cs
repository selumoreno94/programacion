/*P34e) Lectura y Escritura en Fichero Binario
A partir del fichero binario Primitivas08.Dat realizar las siguientes operaciones:
1)	El programa presenta los datos, como en la práctica anterior pero sin parar cada 20 registros
    e indicando en la primera columna, el número de registro (comenzando en cero). 
 
2)	Pedirá un número de registro (usando CapturaEntero), lo leerá del fichero y lo mostrará en pantalla. 
    Esto se repite hasta que pidamos el registro -1. (Nota: ten en cuenta que cada registro ocupa 10 Bytes).

3)	Pide una fecha de origen. El programa, buscará en el fichero el día indicado, lo mostrará en pantalla 
    y escribirá la combinación al final del fichero. 
    Esto se repite tres veces.

4)	Por último nos mostrará de nuevo los datos como en el punto 1.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

        // En esta versión construyo el FileStream para guardar los datos en binario y poder leerlos después
        // AHORA NECESITO ACEDER EN MODO LECTURA Y ESCRITURA
        FileStream fichBin = new FileStream(@"Datos\Primitivas08.Dat", FileMode.Open, FileAccess.ReadWrite);

        //1)	El programa presenta los datos, como en la práctica anterior pero sin parar cada 20 registros
        //      e indicando en la primera columna, el número de registro (comenzando en cero).
        MuestraTodo(fichBin);

        // 2)	Pedirá un número de registro (usando CapturaEntero), lo leerá del fichero y lo mostrará en pantalla. 
        //      Esto se repite hasta que pidamos el registro cero. (Nota: ten en cuenta que cada registro ocupa 10 Bytes).

        int numReg;
        byte[] tabCamposBytes = new byte[10];
        do
        {
            numReg = CapturaEntero("\nDime el nº de registro a mostrar: (-1=salir)", -1, ((int)fichBin.Length - 1) / 10);
            if (numReg > -1)
            {
                // salto a la posición del registro
                fichBin.Seek(numReg * 10, SeekOrigin.Begin);
                // Leo todo el registro guardándolo en una tabla
                fichBin.Read(tabCamposBytes, 0, 10);
                Console.Write("\t{0}", numReg);
                MuestraRegistro(tabCamposBytes);
            }

        } while (numReg != -1);

        //3)	Pide una fecha de origen. El programa, buscará en el fichero el día indicado, lo mostrará en pantalla 
        //      y escribirá la combinación al final del fichero. 
        //      Esto se repite tres veces.
        byte diaBuscado, mesBuscado, dia = 0, mes = 0;
        byte[] maxDiaMes = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        bool encontrado;
        // Como voy a añadir tres registros me pongo en el final del fichero
        fichBin.Seek(0, SeekOrigin.End);

        for (int veces = 0; veces < 3; veces++)
        {
            encontrado = false;
            mesBuscado = Convert.ToByte(CapturaEntero("\n¿Mes a buscar?", 1, 12));
            diaBuscado = Convert.ToByte(CapturaEntero("¿Día a buscar?", 1, maxDiaMes[mesBuscado]));

            fichBin.Position = 0; // <-- Equivale a: fBin.Seek(0, SeekOrigin.Begin);
            while (fichBin.Position < fichBin.Length)
            {
                dia = (byte)fichBin.ReadByte(); // la primera lectura es el día (Ojo. lo lee como int y hay que convertirlo a byte)
                mes = (byte)fichBin.ReadByte(); // la segunda lectura es el mes
                // Si es la fecha que busco, relleno la tabla y la guardo
                if (diaBuscado == dia && mesBuscado == mes)
                {
                    encontrado = true;
                    tabCamposBytes[0] = dia;
                    tabCamposBytes[1] = mes;
                    for (int j = 2; j < 10; j++)
                        tabCamposBytes[j] = (byte)fichBin.ReadByte();


                    MuestraRegistro(tabCamposBytes);
                    // Como voy a añadir registro me pongo en el final del fichero
                    fichBin.Seek(0, SeekOrigin.End);
                    // lo guardo en el fichero 
                    fichBin.Write(tabCamposBytes, 0, 10);
                    break;// <-- Si lo he encontrado me salgo del bucle
                }
            }
            if (!encontrado)
                Console.WriteLine("\n\tNo hubo primitiva el {0}/{1}", diaBuscado, mesBuscado);
        }
        Console.WriteLine("\n\t\tPulse Cualquier Tecla para mostrar los registros");
        Console.ReadKey();
        // 4)	Por último nos mostrará de nuevo los datos como en el punto 1.
        MuestraTodo(fichBin);

        fichBin.Close();
        Console.WriteLine("\n\t\tPresione Cualquier Tecla para Salir");
        Console.ReadKey();
    }

    static void MuestraTodo(FileStream fichBin)
    {
        byte[] tabCamposBytes = new byte[10];
        int cont = 0;
        // me pongo al principio del fichero
        fichBin.Position = 0;
        Console.WriteLine("\n\tNº\tFecha\tn1   n2   n3   n4   n5   n6\tComp\tReint.\n");
        while (fichBin.Position < fichBin.Length)
        {
            // Leo 10 bytes que sé que tiene mi registro, los muestro en pantalla...
            fichBin.Read(tabCamposBytes, 0, 10);
            Console.Write("\t{0}", cont++);
            MuestraRegistro(tabCamposBytes);
        }
    }
    static void MuestraRegistro(byte[] tabCamposBytes)
    {
        Console.ForegroundColor = ConsoleColor.White;
        //--- A partir de aquí varía un poco respecto el anterior: Ya presentamos desde la tabla.
        // Presento la fecha
        Console.Write("\t{0}-{1}\t", tabCamposBytes[0].ToString("00"), tabCamposBytes[1].ToString("00")); // <-- Variante respecto al anterior
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Presento los demás números
        for (int i = 2; i < 8; i++)
        {
            if (tabCamposBytes[i] < 10)
                Console.Write(" ");
            Console.Write("{0}   ", tabCamposBytes[i]);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t{0}\t{1}", tabCamposBytes[8], tabCamposBytes[9]);
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
}
