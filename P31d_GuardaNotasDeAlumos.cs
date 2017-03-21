// Alumno: 

/* P31d_GuardaNotasDeAlumnos:

Construye dos tablas tApell y tNomb como hiciste en otras prácticas anteriores. A continuación realizamos el siguiente proceso:
1)   Construimos una lista de string listAlumnos y la cargamos con los “Apellidos, Nombre” de cada alumno a partir de las dos tablas anteriores.
Para esto construye y utiliza el método siguiente:
ConstruyeListaAlumnos:
Recibe: dos tablas: la de apellidos y la de nombre
Hace: Construye una lista de string listaAlumnos y la cargamos con los “Apellidos, Nombre” de cada alumno a partir de las dos tablas anteriores.
Devuelve: La lista de alumnos construida.
2)   Construimos una lista de tablas de floats listaNotas con las mismas filas que la anterior pero en cada posición tiene una tabla con las tres notas de cada alumno, es decir, en la pos n se guardará la tabla con las tres notas del alumno de posición n. Estas tablas se cargarán con notas obtenidas al azar, entre 0.0 y 9.9, (con un decimal).
Para esto construye y utiliza el método siguiente:
ConstruyeListaNotas:
Recibe: Un entero: el número de alumnos
Hace: Construimos una lista de tablas floats de notas. Para cada alumno, guarda una tabla de floats tNotas con las tres notas de cada uno, obtenidas al azar, entre 0.0 y 9.9, (con un decimal).
Devuelve: La lista de notas construida.
3)   Presentamos la tabla de doble entrada, alumnos/notas donde aparece cada alumno con sus tres notas y la media de las tres. A esta presentación se le pondrá una cabecera:
id  Alumno  Prog   ED    BD   Media
Para esto construye y utiliza el método siguiente:
PresentaNotasAlumnos
Recibe: dos listas: la de alumnos y la de notas
Hace: Presentamos la tabla de doble entrada, alumnos/notas donde aparece cada alumno con sus tres notas y la media de las tres. A esta presentación se le pondrá una cabecera:
id  Alumno  Prog   ED    BD   Media
Devuelve: Nada.
 

 
4)   Luego se le pedirá el nombre del fichero en el que guardar los valores de la lista. El programa añadirá la extensión .TXT al nombre del fichero y averiguará si el fichero ya existe en la carpeta de pruebas.
Si no existe ya el fichero, lo construirá.
Si existe, preguntará si quieres sobreescribirlo (usa PreguntaSiNo) si contesta sí lo construirá como si no existiera.
5)   Guardará la presentación tal como se mostró en la pantalla.
Para esto construye y utiliza el método siguiente:
GuardaNotasAlumnos
Recibe: dos listas (la de alumnos y la de notas) y la ruta del fichero.
Hace: Guarda los datos con la misma estructura que lo hacía PresentaNotasAlumnos en la pantalla
Devuelve: Nada.
 
 

        string[] tNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };
        string[] tApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };
 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class Program
{
    public static Boolean PreguntaSiNo(string texto)
    {
        ConsoleKeyInfo tecla;
        char resp;
        do
        {
            Console.Write("\n\t {0}: ", texto);
            tecla = Console.ReadKey();
            resp = tecla.KeyChar;

            if (Char.ToUpper(resp) == 'S')
                return true;

            else if (Char.ToUpper(resp) == 'N')
                return false;

        } while (Char.ToUpper(resp) != 'N' || Char.ToUpper(resp) != 'S');

        return false;

    }

    static List<string> ConstruyeListaAlumnos(string[] tApellidos, string[] tNombres)
    {
        List<string> listaAlumnos = new List<string>();
        for (int i = 0; i < tApellidos.Length; i++)
        {
            listaAlumnos.Add(tNombres[i] + " " + tApellidos[i]);
        }
        return listaAlumnos;
    }

    static List<float[]> ConstruyeListaNotas(int numeroAlumnos)
    {
        Random generator = new Random();

        List<float[]> listaNotas = new List<float[]>();

        // Para cada alumno, consigo la tabla con sus tres notas y la guardo en la lista
        for (int pos = 0; pos < numeroAlumnos; pos++)
        {
            // Construimos la tabla de float y la lista que vamos a devolver
            float[] tNotas = new float[3];
            //la tabla con las tres notas del alumno de posición pos
            for (int i = 0; i < 3; i++)
                tNotas[i] = generator.Next(100) / 10F;
            // guardo en la lista dicha tabla
            listaNotas.Add(tNotas);
        }
        return listaNotas;
    }

    static void PresentaNotaAlumnos(List<string> listaAlumnos, List<float[]> listaNotas)
    {
        double suma;
        // Escribimos la cabecera
        Console.WriteLine("id" + "\t\t" + "Alumno" + "\t\t\t" + "Prog" + "\t" + "ED" + "\t" + "BD" + "\t" + "Media");
        // para cada alumno
        for (int i = 0; i < listaAlumnos.Count; i++)
        {
            // ... mostramos el alumno
            Console.Write(i + 1 + "\t" + listaAlumnos[i]);
            Console.SetCursorPosition(40, i + 1);
            // ... y sus tres notas

            suma = 0;
            foreach (float nota in listaNotas[i])
            {
                Console.Write("{0}\t", nota);
                suma += nota;
            }
            Console.WriteLine(Math.Round(suma / 3, 2));
            //// Lo mismo pero MBP
            //Console.Write("{0}\t", listaNotas[i][0]);
            //Console.Write("{0}\t", listaNotas[i][1]);
            //Console.Write("{0}\t", listaNotas[i][2]);
            //Console.WriteLine(Math.Round((listaNotas[i][0] + listaNotas[i][1] + listaNotas[i][2]) / 3.0,2));
        }
    }
    private static void GuardaNotasAlumnos(List<string> listaAlumnos, List<float[]> listaNotas, string ruta)
    {
        StreamWriter medias;

        bool respuesta = true;
        if (File.Exists(ruta))
        {
            respuesta = PreguntaSiNo("Fichero ya existe, Deseja Sobreescribirlo[S/N]? ");
            if (respuesta)
                medias = File.CreateText(ruta); // crea archivos directamente //
            else
                return;
        }
        else
            medias = File.CreateText(ruta);

        double suma;
        // Escribimos la cabecera
        medias.WriteLine("id   Alumno                        Prog   ED   BD    Media\n--   ---------------------------   ----  ---   ---   -----");

        // para cada alumno
        for (int i = 0; i < listaAlumnos.Count; i++)
        {
            // ... mostramos el alumno
            medias.Write((i + 1).ToString("00") + "   " + listaAlumnos[i].PadRight(30, ' '));
            // ... y sus tres notas

            suma = 0;
            foreach (float nota in listaNotas[i])
            {
                medias.Write("{0}", nota.ToString("N1") + "   ");
                suma += nota;
            }
            medias.WriteLine(Math.Round(suma / 3, 2).ToString("N2"));
        }
        medias.Close();
        Console.WriteLine("\n\t\tOperación Realizada con Exito !!!");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        string[] tNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };
        string[] tApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };
        List<string> listaAlumnos = ConstruyeListaAlumnos(tApellidos, tNombres);
        List<float[]> listaNotas = ConstruyeListaNotas(tNombres.Length);
        PresentaNotaAlumnos(listaAlumnos, listaNotas);
        Console.Write("\nEscriba el nombre del fichero en el que quiere guardar la tabla: ");
        string nombre = Console.ReadLine();
        GuardaNotasAlumnos(listaAlumnos, listaNotas, @"C:\zDatosPruebas\" + nombre + ".txt");
        Console.WriteLine("\n\n\t\tPulsa intro para salir");
        Console.ReadLine();
    }
}