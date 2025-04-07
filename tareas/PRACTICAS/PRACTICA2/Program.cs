
using System;

public class BuscarNombreEnArreglo
{
    public static void Main(string[] args)
    {
        // Crear un arreglo de 5 nombres
        string[] nombres = new string[5];

        // Pedir al usuario que ingrese los nombres
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.Write($"Ingrese el nombre {i + 1}: ");
            nombres[i] = Console.ReadLine();
        }

        // Pedir al usuario que ingrese el nombre a buscar
        Console.Write("Ingrese el nombre que desea buscar: ");
        string nombreBuscado = Console.ReadLine();

        // Buscar el nombre en el arreglo
        int posicion = -1; // Inicializar la posición en -1 (no encontrado)
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase)) // Comparación sin distinción de mayúsculas y minúsculas
            {
                posicion = i;
                break; // Detener la búsqueda si se encuentra el nombre
            }
        }

        // Mostrar el resultado
        if (posicion != -1)
        {
            Console.WriteLine($"El nombre '{nombreBuscado}' se encuentra en la posición {posicion + 1} del arreglo.");
        }
        else
        {
            Console.WriteLine($"El nombre '{nombreBuscado}' no se encuentra en el arreglo.");
        }
    }
}