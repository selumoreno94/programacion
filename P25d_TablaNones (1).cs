/*25d)	TablaNones: 
 * Declaramos la tabla global tNones.
 * El programa pregunta cuántos impares vas a cargar en la tabla [entre 5 y 100]. 
 * Luego llama al método CargaTablaNones, que recibe un entero, numE, e inicializa y carga la tabla 
   tNones con los primeros “numE” números impares.
 * Por último preguntará en cuántas columnas los quiere [entre 1 y 8] y llamará a 
   MuestraTabla, que recibe el número de columnas en que las va a mostrar y presenta 
   cada elemento con su índice delante.

*/

using System;

class P13a_TablaNones
{
    static int[] tNones; // declaración de la tabla. (No definimos su tamaño)
    
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

    static void CargaTablaNones(int numE)
    {
        tNones = new int[numE];  // Definimos el tamaño de la tabla
        // Ahora la rellenamos con los números impares
        int impar = 1;
        for (int i = 0; i < numE; i++)
        {
            tNones[i] = impar;
            impar += 2;
        }
    }

    static void PresentaTabla(int numColums)
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

    static void Main(string[] args)
    {
        int tamTabla, numColumnas, rep;
        bool repetir = false;
        do
        {
            tamTabla = CapturaEntero("\n\t\tNúmero de elementos: ", 5, 100);

            numColumnas = CapturaEntero("\n\t\tEn cuántas columnas?: ", 1, 8);

            CargaTablaNones(tamTabla);

            PresentaTabla(numColumnas);

            rep = CapturaEntero("\n\t\t¿Quieres repetir? (1=si 0=NO): ", 0, 1);

            repetir = (1 == rep);

            // Las dos líneas anteriores se resumen en esta:
            //repetir = (1==CapturaEntero("\n\t\t¿Quieres repetir? (1=si 0=NO): ", 0, 1));

        } while (repetir);

        Console.WriteLine("\n\n\t\tPulsa intro para salir");
        Console.ReadLine();

    }





}
