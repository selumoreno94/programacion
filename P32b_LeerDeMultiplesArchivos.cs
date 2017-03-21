/* P32b: Lectura de múltiples ficheros
 * Repetir el aparatado anterior pero primero se le pide al usuario que escriba la ruta
 * de la carpeta de los ficheros que vamos a leer. 
 * Luego pedira un nombre de fichero TXT, sin escribir su extension. 
 * 
 * El programa leera el fichero.TXT, si existe, y lo mostrara en pantalla.
 * 
 * A continuacion preguntara (usando PreguntaSiNo) si quiere leer otro, de la misma carpeta, 
 * y repetira el proceso hasta que se responda no
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    public static bool PreguntaSiNo(string p)
    {
        bool respuesta = false;
        char tecla;
        bool error = false;
        // Hacemos la pregunta
        do
        {
            error = false;
            Console.Write("\n\n{0} (s=Sí; n=No): ", p);
            // Capturamos la respuesta (una pulsación)
            tecla = (Console.ReadKey()).KeyChar;
            if (tecla == 's' || tecla == 'S')
                respuesta = true;
            else if (tecla == 'n' || tecla == 'N')
                respuesta = false;
            else
            {
                Console.Write("\n\n\t** Error: por favor, responde s o n **");
                error = true;
            }
        } while (error);
        return respuesta;
    }

    static void Main(string[] args)
    {
        StreamReader fichR;
        bool respuesta = true;
        string directorio;
        string ruta;
        string archivo;
        string fila;


        Console.Write("\n¿De qué directorio desea leer los ficheros?  ");
        directorio = Console.ReadLine();
        directorio = @"C:\zDatosPruebas"; // durante las pruebas
        do
        {
            Console.Write("\n¿Qué archivo .TXT desea abrir? (sólo el nombre) ");
            archivo = Console.ReadLine();
            // componemos la ruta completa
            ruta = directorio + @"\" + archivo + ".txt";

            if (File.Exists(ruta))  //  <-- Si existe la ruta
            {
                fichR = File.OpenText(ruta);   //  <-- Abro el stream

                Console.WriteLine("\n");
                while (!fichR.EndOfStream)      //   <-- Mientras no llegue al final 
                {
                    fila = fichR.ReadLine();    // estas dos filas se pueden resumir en una sola: Console.WriteLine(fichR.ReadLine());
                    Console.WriteLine(fila);
                }

                fichR.Close();  //  <-- No se te olvide cerrar
            }
            else
            {
                Console.WriteLine("\n\t ** NO EXISTE **");
            }
            respuesta = PreguntaSiNo("¿Desea leer otro archivo?");
            Console.Clear();
        } while (respuesta);
    }
}

