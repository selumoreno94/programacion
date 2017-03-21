/* P26b)	Tabla2dNotas
Construye dos tablas tApell y tNomb como hiciste en la práctica anterior. 
 * A continuación realizamos el siguiente proceso:
1)	Construimos una tabla de string tAlumnos y la cargamos con los “Apellidos, Nombre” de cada alumno a partir de las 
    dos tablas anteriores.
2)	Construimos una tabla de floats tNotas con las mismas filas que la anterior pero de dos dimensiones 
    (tres columnas), para guardar las notas de los alumnos, es decir, en la fila n se guardarán las tres notas del alumno 
    de posición n. Esta tabla se cargará con notas obtenidas al azar, entre 0.0 y 9.9, (con un decimal).
3)	Presentamos la tabla de doble entrada, alumnos/notas donde aparece cada alumno con sus tres notas y la media de las tres. 
    A esta presentación se le pondrá una cabecera: 
                                    id  Alumno  Prog   ED    BD   Media
 */
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] tApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };
        string[] tNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };

        // 1)	Construimos una tabla de string tAlumnos...
        int numAlumnos = tNombres.Length;
        string[] tAlumnos = new string[numAlumnos];
        //... y la cargamos con los “Apellidos, Nombre” de cada alumno, a partir de las dos tablas anteriores.
        for (int i = 0; i < numAlumnos; i++)
            tAlumnos[i] = tApellidos[i] + ", " + tNombres[i];

        //2)	Construimos una tabla de floats tNotas con las mismas filas que la anterior pero de dos dimensiones 
        //    (tres columnas), para guardar las notas de los alumnos, es decir, en la fila n se guardarán las tres notas del alumno 
        //    de posición n. Esta tabla se cargará con notas obtenidas al azar, entre 0.0 y 9.9, (con un decimal).
        float[,] tNotas = new float[numAlumnos, 3];
        Random azar = new Random();
        for (int i = 0; i < numAlumnos; i++)
        {
            tNotas[i, 0] = (float)azar.Next(0, 100) / 10;       // <-- Para que salga un float con un decimal
            tNotas[i, 1] = azar.Next(0, 100) / 10F;             // <-- Otra forma de hacer lo mismo
            tNotas[i, 2] = (float)(azar.Next(0, 100) / 10.0);   // <-- Otra forma de hacer lo mismo
        }

        //3)	Presentamos la tabla de doble entrada, alumnos/notas donde aparece cada alumno con sus tres notas y la media de las tres. 
        //      A esta presentación se le pondrá una cabecera: id  Alumno  Prog   ED    BD   Media
        Console.Clear();
        Console.WriteLine("\n\tid  Alumno                      Prog    ED      BD      Media");
        double media;
        int fila = 2, columna = 40;
        for (int i = 0; i < numAlumnos; i++)
        {
            fila++;
            media = Math.Round((tNotas[i, 0] + tNotas[i, 1] + tNotas[i, 2]) / 3, 2);
            Console.Write("\n\t {0} {1}", (i + 1).ToString("00"), tAlumnos[i]);
            Console.SetCursorPosition(columna, fila);
            Console.Write("{0}  \t{1} \t{2} \t{3}", tNotas[i, 0], tNotas[i, 1], tNotas[i, 2], media);

        }



        Console.WriteLine("\n\n\t\tPulsa intro para salir");
        Console.ReadLine();
    }

}