/* P33a) Leer Datos de Fichero.Txt Con Campos dimensionados y escribir en Fichero.Txt Con Campos Separados
Repetir la práctica LeerDatosEnTxtCamposDimensionados (32.e) anterior con las siguientes modificaciones:
•	Los datos se guardan en listas en lugar de tablas. Por tanto, las notas se guardan en una lista de tablas de 3 notas (float)
•	En esta ocasión no se permite lista auxiliar, es decir, hay que cargar las listas conforme se va leyendo del fichero.
•	Por último guardar los datos (sin espacios laterales) separados por ';' en un fichero de nombre AlumNotasId_CD.txt
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
        // Construyo las tres lista que necesito
        List<byte> listaIds = new List<byte>();
        List<string> listaAlumnos = new List<string>();
        List<float[]> listaNotas = new List<float[]>();

        // el StreamReader para leer los datos
        StreamReader fichDatos = new StreamReader(@"..\..\Datos\AlumNotasId_CD.txt", Encoding.Default);
        // Leemos todas las lineas del fichero y las guardamos en la lista
        string linea;
        while (!fichDatos.EndOfStream)
        {
            linea = fichDatos.ReadLine();   // <-- Leo una línea
            // obtengo el id y lo guardo
            listaIds.Add(Convert.ToByte(linea.Substring(0, 3)));
            // obtengo el nombre y lo guardo
            listaAlumnos.Add(linea.Substring(3, 28));
            // en las tres siguientes posiciones de linea están las tres notas
            float[] notas = new float[3];
            notas[0] = Convert.ToSingle(linea.Substring(31, 3));
            notas[1] = Convert.ToSingle(linea.Substring(34, 3));
            notas[2] = Convert.ToSingle(linea.Substring(37));
            listaNotas.Add(notas);

        }
        // ya hemnos leído todas las líneas, por lo tanto cierro el stream
        fichDatos.Close();

        // guardo el tamaño de la lista (es decir, el númer de alumnos), porque lo voy a usar varias veces
        int numAlumnos = listaIds.Count;

        //--- mostramos los datos y los guardamos en el fichero

        // el StreamReader para leer los datos
        StreamWriter fichDatosW = new StreamWriter(@"..\..\Datos\AlumNotasId_CS.txt");

        int fila = 2;
        double media;
        Console.WriteLine("  Id \tAlumnos   \t\t\tProg    Ed      BD      Media");
        Console.WriteLine("  ---------------------------------------------------------------------");
        for (int i = 0; i < numAlumnos; i++)
        {
            // muestro los datos
            Console.SetCursorPosition(2, fila);
            Console.Write("{0}  {1}", listaIds[i], listaAlumnos[i]);
            Console.SetCursorPosition(40, fila);
            // calculo la media
            media = Math.Round((listaNotas[i][0] + listaNotas[i][1] + listaNotas[i][2]) / 3, 2);
            Console.Write(listaNotas[i][0] + "\t" + listaNotas[i][1] + "\t" + listaNotas[i][2] + "\t" + media);
            fila++;
            // los guardo
            fichDatosW.Write(listaIds[i] + ";");
            fichDatosW.Write(listaAlumnos[i].Trim() + ";"); // .Trim() paraq quitar los espacios laterales
            fichDatosW.WriteLine(listaNotas[i][0] + ";" + listaNotas[i][1] + ";" + listaNotas[i][2]);
        }
        fichDatosW.Close();

        Console.WriteLine("\n\n\t Pulsa intro para salir");
        Console.ReadLine();
    }
}