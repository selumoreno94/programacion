/* P26a)	Tabla2dGente
Realizar el siguiente proceso (Entre un paso y el siguiente pon una pausa en la que el usuario tenga que pulsar una tecla)
1)	A partir de los apellidos y nombres que tienes más abajo, construir respectivamente 
    las tablas tApellidos y tNombres. 
2)	A continuación construye la tabla tab2dGente —con las mismas filas y dos columnas— y cárgalas colocando 
    para cada alumno el nombre en la primera columna y los apellidos en la segunda. 
3)	Luego presentar «Nombre Apellidos» de cada alumno a partir de la tabla tab2dGente
4)	Construye el vector de string tabApellNomb y rellénala con los “Apellidos, Nombres” tomándolos de la 
    tabla tab2dGente.
5)	Muestra tabApellNomb en pantalla.
6)	Muestra la persona cuyos «Apellidos, Nombre» tiene más caracteres.

Los datos:
Apellidos: "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez"

Nombres: "Álvaro", "Daniel Luis", "Juan Manuel", "Agustin", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio"

 */
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Pausa(string texto)
    {
        Console.WriteLine("\n\n\tPulsa una tecla para {0}", texto);
        Console.ReadKey();
    }
    static void Main(string[] args)
    {
        // 1)	A partir de los apellidos y nombres del enunciado construir las tablas tApellidos y tNombres. 
        Pausa("Construir las tablas tApellidos y tNombres");
        string[] tApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };
        string[] tNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };

        //2)  Construimos la tabla tab2dGente —con las mismas filas y dos columnas— 
        Pausa("Construir la tabla tab2dGente");
        int numPersonas = tNombres.Length;
        string[,] tab2dGente = new string[numPersonas, 2];

        //2.1 Cargamos tab2dGente colocando para cada alumno el nombre en la primera columna y los apellidos en la segunda.
        Pausa("Cargar la tabla tab2dGente");
        for (int i = 0; i < numPersonas; i++)
        {
            tab2dGente[i, 0] = tNombres[i];
            tab2dGente[i, 1] = tApellidos[i];
        }

        //3)	PresentaMos «Nombre Apellidos» de cada persona a partir de la tabla tab2dGente
        Pausa("Mostrar «Nombre Apellidos de cada persona» a partir de la tabla tab2dGente");
        for (int i = 0; i < numPersonas; i++)
        {
            Console.WriteLine("{0} {1}", tab2dGente[i, 0], tab2dGente[i, 1]);
        }

        //4)	Vector de string tabApellNomb con los “Apellidos, Nombres” tomándolos de la tabla tab2dGente.
        Pausa("Construir y cargar el Vector de string «tabApellNomb» tomándolos de la tabla tab2dGente");
        string[] tabApellNomb = new string[numPersonas];
        for (int i = 0; i < numPersonas; i++)
        {
            tabApellNomb[i] = tab2dGente[i, 1] + ", " + tab2dGente[i, 0];
        }


        //5)	Muestra tabApellNomb en pantalla.
        Pausa("Mostrar el Vector de string «tabApellNomb»");
        for (int i = 0; i < numPersonas; i++)
        {
            Console.WriteLine(tabApellNomb[i]);
        }


        //6)	Muestra la persona cuyos «Apellidos, Nombre» tiene más caracteres.
        Pausa("Mostrar la persona cuyos «Apellidos, Nombre» tiene más caracteres");

        string maxNombre = tabApellNomb[0]; // tomo la primera cadena como si fuera la más larga

        for (int i = 1; i < numPersonas; i++)
        {
            if (tabApellNomb[i].Length > maxNombre.Length)  // Si la actual es mayor
            {
                maxNombre = tabApellNomb[i];                // La tomo como la más larga
            }
        }

        Console.WriteLine("La persona con más caracteres en sus Apellidos, Nombre es: \n\t\t\t " + maxNombre);



        Console.WriteLine("\n\n\t\tPulsa intro para salir");
        Console.ReadLine();
    }
}