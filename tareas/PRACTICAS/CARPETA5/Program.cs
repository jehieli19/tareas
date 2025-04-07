using System;
using System.IO;

public class GuardarYMostrarNombres
{
    public static void Main(string[] args)
    {
        // Guardar nombres en un archivo de texto
        try
        {
            using (StreamWriter escritor = new StreamWriter("nombres.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Ingresa el nombre {i + 1}: ");
                    string nombre = Console.ReadLine();
                    escritor.WriteLine(nombre);
                }
            }
            Console.WriteLine("Nombres guardados en el archivo 'nombres.txt'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al guardar los nombres: {ex.Message}");
            return;
        }

        // Leer nombres del archivo y mostrarlos en pantalla
        try
        {
            using (StreamReader lector = new StreamReader("nombres.txt"))
            {
                Console.WriteLine("\nNombres almacenados en el archivo:");
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo 'nombres.txt' no se encontró.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al leer el archivo: {ex.Message}");
        }
    }
}