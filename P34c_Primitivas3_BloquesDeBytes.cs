/*P34b) Escritura en Fichero Binario: Uso de la propiedad .Position
Como en la práctica anterior, leer el fichero Primitivas08.TXT y guardar los datos en un fichero binario, 
de nombre Primitivas08.Dat.
A continuación, leer los datos del fichero Primitivas08.Dat y mostrarlos en pantalla, parando cada 20 registros, 
 * pero en esta versión, sin haberlo cerrado antes.
 * También hay que realizar la lectura sin utilizar un contador auxiliar, sino la propiedad Position del FileStream. 
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
        StreamReader lectorTxt = new StreamReader(@"Datos\Primitivas08.txt");

        // En esta versión construyo el FileStream para guardar los datos en binario y poder leerlos después
        // AHORA NECESITO ACEDER EN MODO LECTURA Y ESCRITURA
        FileStream fichBin = new FileStream(@"Datos\Primitivas08.Dat", FileMode.Create, FileAccess.ReadWrite);

        string linea;

        string[] tablaCampos; // crea tabla para guardar los numeros como string pero, ya tratados
        byte[] tabCamposBytes = new byte[10];
        while (!lectorTxt.EndOfStream)
        {
            linea = lectorTxt.ReadLine(); // Para cada línea...

            tablaCampos = linea.Split(';'); // <-- la desgloso en campos (como string's)

            // esta es la única diferencia en la escritura, respecto la versión anterior
            for (int i = 0; i < tablaCampos.Length; i++)
                tabCamposBytes[i] = Convert.ToByte(tablaCampos[i]); // <-- /Convierto cada campo a byte y lo guardo como tal en la tabla

            // Guardamos los 10 bytes de una vez
            fichBin.Write(tabCamposBytes, 0, 10);
        }

        lectorTxt.Close(); // cierro el fichero TXT de laectura

        // En este punto, el cursor del fichero binario se ha quedado al final del mismo
        // Coloco el cursor del fichero al principio del mismo para comenzar a leer

        // Con Seek salto 0 a partir del origen
        //fichBin.Seek(0, SeekOrigin.Begin);  // Utilizando el método Seek
        fichBin.Position = 0;      // Más simple, sabiendo que la primera posición es la cero

        Console.Clear();
        //int cuentaBytes = 0; ya no necewsito esto porque leeré registro a registro
        int cuentaFilas = 0; // me servirá para hacer una parada de 20 en 20
        long tamFichero = fichBin.Length;  // <-- Tamño del fichero
        byte num;
        Console.WriteLine("\n\tFecha\tn1   n2   n3   n4   n5   n6\tComp\tReint.\n");
        while (fichBin.Position < tamFichero)
        {
            // Leo 10 bytes que sé que tiene mi registro, los muestro en pantalla...
            fichBin.Read(tabCamposBytes, 0, 10);

            #region Presentación de los datos

            cuentaFilas++;
            if (cuentaFilas == 20)
            {
                cuentaFilas = 0;
                Console.WriteLine("\n\t\tPresione Cualquier Tecla para Continuar");
                Console.ReadKey();
                Console.WriteLine("\n\tFecha\tn1   n2   n3   n4   n5   n6\tComp\tReint.\n");
            }
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
            Console.WriteLine("\t{0}\t{1}", tabCamposBytes[8], tabCamposBytes[9]);

            #endregion
        }
        fichBin.Close();
        Console.WriteLine("\n\t\tPresione Cualquier Tecla para Salir");

        Console.ReadKey();
    }
}
