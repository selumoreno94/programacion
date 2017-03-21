/*
 P34a_Primitivas08 en binario 1 (versión simple: sin presentar bien los números)
Leer el fichero Primitivas08.TXT y guardar los datos (como bytes) en un fichero binario, 
de nombre Primitivas08.Dat. 
 * A continuación, abrir el fichero Primitivas08.Dat, leer los datos y 
mostrarlos en pantalla. Parar la presentación cada 20 registros.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Construyo el StreamReader para leer el fichero de texto
        StreamReader lectorTxt = new StreamReader(@"Datos\Primitivas08.txt"); //<-- o bien: = File.OpenText(@"Datos\Primitivas08.txt");

        // Construyo el BinaryWriter para escribir en el fichero Binario
        FileStream fichBin = new FileStream(@"Datos\Primitivas08.Dat", FileMode.Create, FileAccess.Write);
        BinaryWriter bW = new BinaryWriter(fichBin);

        string linea;

        string[] tablaCampos; //<-- Tabla donde guardaremos los campos de cada fila (como string)
        // Recorremos el fichero leyendo fila a fila (es decir, registro a registro)
        while (!lectorTxt.EndOfStream)
        {
            linea = lectorTxt.ReadLine(); // Para cada línea...

            tablaCampos = linea.Split(';'); // <-- la desgloso en campos (como string's)

            for (int i = 0; i < tablaCampos.Length; i++)
            {
                bW.Write(Convert.ToByte(tablaCampos[i])); // guarda los numeros como byte en el fichero destino
            }
        }
        // cierro los recursos abiertos
        lectorTxt.Close();
        bW.Close();
        fichBin.Close();



        // Abro un BinaryReader para LEER del fichero binario
        fichBin = new FileStream(@"Datos\Primitivas08.Dat", FileMode.Open, FileAccess.Read);
        BinaryReader leer = new BinaryReader(fichBin);

        Console.Clear();
        Console.WriteLine("\n\tDía\tMes\tn1\tn2\tn3\tn4\tn5\tn6\tComp\tReintegro\n");
        int cuentaCampos = 0;
        int cuentaFilas = 0; // me servirá para hacer una parada de 20 en 20
        long tamFichero = fichBin.Length;  // <-- Tamño del fichero

        for (long i = 0; i < tamFichero; i++)
        {
            Console.Write("{0}\t", leer.ReadByte().ToString("00"));
            cuentaCampos++;
            if (cuentaCampos == 10) // <-- Si he leído los diez bytes del registro...
            {
                Console.WriteLine();
                cuentaCampos = 0;
                cuentaFilas++;
                if (cuentaFilas == 20)
                {
                    cuentaFilas = 0;
                    Console.WriteLine("\n\t\tPresione Cualquier Tecla para Continuar");
                    Console.ReadKey();
                    Console.WriteLine("\n\tDía\tMes\tn1\tn2\tn3\tn4\tn5\tn6\tComp\tReintegro\n");
                }
            }
        }
        leer.Close();
        fichBin.Close();
        Console.WriteLine("\n\t\tPresione Cualquier Tecla para Salir");

        Console.ReadKey();
    }
}
