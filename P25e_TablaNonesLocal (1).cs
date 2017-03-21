/*25e)	TablaNonesLocal: 
Repetir la práctica anterior con las siguientes variaciones:
1)	La tabla NO será global. (Esto implica que los métodos que utilizan la tabla, 
    tienen que recibirla como parámetro)
2)	Para preguntar si quiere repetir, construir y utilizar el método PreguntaSiNo, 
    que recibe una cadena (la pregunta) y devuelve true si pulsas ‘s’ (o ‘S’) o false si pulsas ‘n’ (o ‘N’).
*/

using System;

class P13a_TablaNones
{
    static int CapturaEntero(string texto, int min, int max)
    {
        int miEntero;
        bool esEntero;

        do
        {
            Console.Write("\n\t{0} [{1}..{2}]: ", texto, min, max);
            esEntero = int.TryParse(Console.ReadLine(), out miEntero);

            if (!esEntero)  // Comprobamos el formato
                Console.WriteLine("\n** Error. no ha introducido un número entero **");
            else if (miEntero < min || miEntero > max) // Comprobamos el rango
                Console.WriteLine("\n** Error. Valor fuera de rango **");

        } while (!esEntero || miEntero < min || miEntero > max);

        return miEntero;
    }

    static int[] CargaTablaNones(int numE)
    {
        int[] tNones = new int[numE];  // Construimos la tabla
        // Ahora la rellenamos con los números impares
        int impar = 1;
        for (int i = 0; i < numE; i++)
        {
            tNones[i] = impar;
            impar += 2;
        }
        return tNones;
    }

    static void PresentaTabla(int numColums, int[] tNones)
    {
        int contColum = 0;
        // Recorremos la tabla y presentamos sus elementos
        for (int i = 0; i < tNones.Length; i++)  // Aquí no tengo acceso a numE, por eso usamos tNones.Length
        {
            if (i < 10)
                Console.Write(" ");

            Console.Write("{0}) {1}\t", i, tNones[i]);

            contColum++;
            if (contColum == numColums) // si llegamos al número de columnas previsto...
            {
                Console.WriteLine();    // ... doy un salto de línea...
                contColum = 0;          // ... y reseteo el contador.
            }
        }
    }

    static bool PreguntaSiNo(string pregunta)
    {
        ConsoleKeyInfo tecla;
        char letra;
        bool salir = false;
        do
        {
            Console.Write("{0} (s=si n=NO): ", pregunta);
            tecla = Console.ReadKey();
            letra = tecla.KeyChar;
            if (letra == 's' || letra == 'S')
                salir = true;
            else if (letra == 'n' || letra == 'N')
                salir = false;
            else
                Console.WriteLine("\n\t Error: sólo vale s o n");

        } while (letra != 's' && letra != 'S' && letra != 'n' && letra != 'N');

        return salir;

    }

    static void Main(string[] args)
    {
        int[] tablaNones; // declaración de la tabla. (No definimos su tamaño)
        int tamTabla, numColumnas;
        bool repetir = false;
        do
        {
            tamTabla = CapturaEntero("\n\t\tNúmero de elementos: ", 5, 100);

            numColumnas = CapturaEntero("\n\t\tEn cuántas columnas?: ", 1, 8);

            tablaNones = CargaTablaNones(tamTabla);

            PresentaTabla(numColumnas, tablaNones);

            repetir = PreguntaSiNo("\n\n\t\t¿Quieres repetir? ");

        } while (repetir);

        Console.WriteLine("\n\n\t\tPulsa intro para salir");
        Console.ReadLine();
    }
}
