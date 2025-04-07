using System;
using System.Text.Json;
public class Program
{
    public static void Main(string[] args)
    {
        
        string[] nombres = new string[3];
        int[] calificaciones = new int[3];

       
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.Write($"Ingrese el nombre del alumno {i + 1}: ");
            nombres[i] = Console.ReadLine();

            Console.Write($"Ingrese la calificación del alumno {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out calificaciones[i]) || calificaciones[i] < 0 || calificaciones[i] > 100)
            {
                Console.WriteLine("Por favor, ingrese una calificación válida (0-100): ");
            }
        }

        Console.Write("Ingrese el nombre que desea buscar: ");
        string nombreBuscado = Console.ReadLine();

        
        int posicion = -1; 
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase)) // Comparación sin distinción de mayúsculas y minúsculas
            {
                posicion = i;
                break; 
            }
        }

    
}
 {
        
        int[] numeros = new int[10];

    
        int suma = 0;

        for (int i = 0; i < 10; i++)
        {
        
            Console.Write($"Ingresa el número {i + 1}: ");

           lo
            numeros[i] = int.Parse(Console.ReadLine());

           
            suma += numeros[i];
        }

     
        double promedio = (double)suma / 10;

        Console.WriteLine($"La suma de los números es: {suma}");

       
        Console.WriteLine($"El promedio de los números es: {promedio}");
    }
} 

 

