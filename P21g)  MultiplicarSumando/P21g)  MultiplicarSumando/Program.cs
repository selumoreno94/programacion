/* P21g) 	MultiplicarSumando: 
1)	Recibe: Dos enteros a, b.
2)	Hace: Calcula el producto de los dos, sin utilizar la operación *, sabiendo que a * b es sumar la a “b veces”.
3)	Devuelve: El producto calculado.
En el programa se pedirá dos números [0..10000) y llamando al método, mostrará el producto de estos dos números.
Avanzado: Optimizarlo para que dé las menos vueltas posibles.

*/

using System;

class Program
{
    static int CapturaEntero(string texto, int min, int max)
    {
        int num;
        bool esCorrecto;
        do
        {
            Console.Write("\n\t {0} [{1}..{2}]: ", texto, min, max);
            esCorrecto = Int32.TryParse(Console.ReadLine(), out num);
            if (!esCorrecto)
                Console.WriteLine("\n\t ** ERROR de FORMATO **");
            else if (num < min || num > max)
            {
                Console.WriteLine("\n\t ** ERROR: VALOR FUERA DE RANGO **");
                esCorrecto = false;
            }
        } while (!esCorrecto);

        return num;
    }

    static int MultiplicarSumando(int a, int b)
    {
        int producto = 0;
        // Para que dé las menos vueltas posibles, si b>a intercambio sus valores
        if (b > a)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        // Cuando llegamos aquí b es menor o igual que a
        for (int i = 0; i < b; i++)
        {
            producto = producto + a;
        }

        return producto;
    }

    static void Main(string[] args)
    {
        int num1, num2;
        num1 = CapturaEntero("Dime el primer  factor: ", 0, 9999);
        num2 = CapturaEntero("Dime el segundo factor: ", 0, 9999);
        // la llamada al método, directamente en la presentación (podíamos haber guardado el resultado en una variable y mostrarla)
        Console.WriteLine("\n\n\tEl producto de {0} x {1} = {2}", num1, num2, MultiplicarSumando(num1, num2));

        Console.Write("\n\n\n\t\t\t\tPulsa Intro para salir");
        Console.ReadLine();

    }
}
