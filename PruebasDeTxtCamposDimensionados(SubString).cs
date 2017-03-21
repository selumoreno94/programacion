// Pruebas de registro con campos dimensionados (SubString)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class Program
{
    static string QuitaEspaciosDerecha(string texto)
    {
        while (texto[texto.Length - 1] == ' ') // <-- Mientras en la última posición haya un espacio en blanco
            texto = texto.Substring(0, texto.Length - 1); // <-- recorto la cadena en una posición

        return texto;


    }
    static string CuadraTexto(string texto, int numChar)
    {
        // esta versión es más simple pero sólo sirve si la longitud que quemos no pasa de 80
        texto += "                                                           "; // <-- 80 espacios
        return texto.Substring(0, numChar);

        // Esta versión sirve siempre
        //for (int i = texto.Length; i < numChar; i++)
        //    texto += ' ';

        //return texto;
    }

    static string CuadraTexto(string texto, int numChar, char caracterdeRelleno)
    {
        // Esta versión sirve siempre
        for (int i = texto.Length; i < numChar; i++)
            texto += caracterdeRelleno;

        return texto;
    }

    // Te dejo ésta para que tú la hagas
    static string CuadraTexto(string texto, int numChar, char caracterdeRelleno, sbyte colocaTexto)
    {
        // si colocaTexto== -1 el texto queda a la izquierda
        // si colocaTexto== 1 el texto queda a la derecha
        // si colocaTexto== 0 el texto queda en el centro

    }

    static void Main(string[] args)
    {
        // supongamos que tenemos el siguiente registro:

        string reg = "Adrian    Ortega  97898711120";

        // sabemos que está compuesto por los siguientescampos:
        // nombre  apellido1 telefono edad, cuyos tamaños en bytes son:
        //  10b       8b        9b      3b

        // Obtener cada campo por separado, guardándolos en la tabla
        string[] tabCampos = new string[4];
        tabCampos[0] = reg.Substring(0, 10); // toma 10b desde la posición 0
        tabCampos[1] = reg.Substring(10, 8);
        tabCampos[2] = reg.Substring(18, 9);
        tabCampos[3] = reg.Substring(27);       // desde la posición 27 hasta el final

        // mostramos los campos para comprobar que se han obtenido de forma correcta:
        Console.WriteLine("Nombre       Apellido   teléfono    Edad");
        Console.WriteLine("----------   --------   ---------   ----");
        for (int i = 0; i < tabCampos.Length; i++)
        {
            Console.Write("{0}   ", tabCampos[i]);
        }

        // ¿Cómo hacemos para que presente la frase siguiente?:
        // <fulano de tal tiene tantos años> que en nuestro caso sería
        // Adrián Ortega tiene 20 años
        // Usando el método .Trim()

        //Console.WriteLine("\n\n{0} {1} tiene {2} años", tabCampos[0].Trim(), tabCampos[1].Trim(), tabCampos[3].Trim());
        Console.WriteLine("\n\n{0} {1} tiene {2} años", QuitaEspaciosDerecha(tabCampos[0]), QuitaEspaciosDerecha(tabCampos[1]), QuitaEspaciosDerecha(tabCampos[3]));


        //----- Intentaremos hacer la operación contraria:
        //      configurar un registro como el anterior a partir de los datos introducidos por el usuario:
        Console.Write("\n\n¿Nombre?: ");
        string nombre = Console.ReadLine();
        Console.Write("¿Primer Apellido?: ");
        string apellido1 = Console.ReadLine();
        Console.Write("¿Teléfono?: ");
        string telefono = Console.ReadLine();
        Console.Write("¿Edad?: ");
        string edad = Console.ReadLine();

        reg = CuadraTexto(nombre, 10) +
            CuadraTexto(apellido1, 8) +
            CuadraTexto(telefono, 9) +
            CuadraTexto(edad, 3);
        // Mostramos el registro comparando su longitud
        Console.WriteLine("\n\n123456789|1234567|12345678|12|");
        Console.WriteLine(reg);


        Console.WriteLine("\n\n\t Pulsa intro para salir");
        Console.ReadLine();
    }

}
