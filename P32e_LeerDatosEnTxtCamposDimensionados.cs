/* P32d) Leer Datos En Fichero.Txt Con Campos dimensionados: (Versión básica)
Repetir la práctica anterior pero obteniendo los datos del fichero AlumNotasId_CD.txt, 
sabiendo que los tamaños de cada campo son los siguientes:
  id: 3b;   alumno: 28b;   notaProg: 3b;   notaED: 3b;   notaBD: 3b;
 * 
Es decir, el enunciado sería:
Realiza un programa que lea el fichero AlumNotasId_CD.txt que tienes en la carpeta Datos. 
Se sabe que cada fila contiene los campos: id, nombre, nota1, nota2 y nota3 
a cada uno de los cuales se les ha dado el siguiente tamaño:
            id: 3b;   alumno: 28b;   notaProg: 3b;   notaED: 3b;   notaBD: 3b;
 
A partir de estas filas obtenidas, rellena una tabla de string tabAlums y otra de 
float tabNotas de tres columnas. 
A continuación presentar los datos con su cabecera
 Importante: 
 1.	Utilizar Ruta Relativa y mantener la estructura de archivos que se te entrega. 
 2.	El archivo debe estar abierto el menor tiempo posible.
 3.	Se puede utilizar una lista auxiliar pero tienes que actuar como si no se supiera 
    el número de alumnos que guarda el fichero.
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
        // construyo una lista donde guardar las líneas del fichero (registros)
        List<string> listaReg = new List<string>();

        // el StreamReader para leer los datos
        StreamReader fichDatos = new StreamReader(@"..\..\Datos\AlumNotasId_CD.txt", Encoding.Default);
        // Leemos todas las lineas del fichero y las guardamos en la lista
        string linea;
        while (!fichDatos.EndOfStream)
        {
            linea = fichDatos.ReadLine();   // <-- Leo una línea
            listaReg.Add(linea);            // <-- la guardo en la lista
        }

        // ya hemnos leído todas las líneas, por lo tanto cierro el stream
        fichDatos.Close();

        // guardo el tamaño de la lista (es decir, el númer de alumnos), porque lo voy a usar varias veces
        int numAlumnos = listaReg.Count;
        // construyo las tres tablas con el número de filas obtenidas
        byte[] tabIds = new byte[numAlumnos];
        string[] tabAlumnos = new string[numAlumnos];
        float[,] tabNotas = new float[numAlumnos, 3];

        // ahora vamos a rellenar las tres tablas desglosando las líneas que tengo en listaReg
        string[] tabCampos; // <-- tabla donde guardaremos los campos de cada registro

        // Recorremos la lista de registros 
        for (int i = 0; i < numAlumnos; i++)
        {
            // obtengo el id
            tabIds[i] = Convert.ToByte(listaReg[i].Substring(0,3));
            // obtengo el nombre
            tabAlumnos[i] = listaReg[i].Substring(3, 28);
            // en las tres siguientes posiciones de tabCampos están las tres notas
            tabNotas[i, 0] = Convert.ToSingle(listaReg[i].Substring(31, 3));
            tabNotas[i, 1] = Convert.ToSingle(listaReg[i].Substring(34, 3));
            tabNotas[i, 2] = Convert.ToSingle(listaReg[i].Substring(37));
        }

        //--- mostramos los datos

        int fila = 2;
        double media;
        Console.WriteLine("  Id \tAlumnos   \t\t\tProg    Ed      BD      Media");
        Console.WriteLine("  ---------------------------------------------------------------------");
        for (int i = 0; i < tabAlumnos.Length; i++)
        {
            // calculo la media
            media = Math.Round((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3, 2);
            Console.SetCursorPosition(2, fila);
            Console.Write("{0}  {1}", tabIds[i], tabAlumnos[i]);
            Console.SetCursorPosition(40, fila);
            Console.Write(tabNotas[i, 0] + "\t" + tabNotas[i, 1] + "\t" + tabNotas[i, 2] + "\t" + media);
            fila++;
        }

        Console.WriteLine("\n\n\t Pulsa intro para salir");
        Console.ReadLine();
    }
}
