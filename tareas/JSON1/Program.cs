using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Estudiante
{
    public string? Nombre { get; set; }
    public double Calificacion1 { get; set; }
    public double Calificacion2 { get; set; }
    public double Calificacion3 { get; set; }
    public double Promedio { get; set; }
    public string? Estado { get; set; }
}

public class ProgramaCalificaciones
{
    public static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>();
        string rutaArchivo = "calificaciones.json";

        try
        {
            Console.WriteLine("Ingrese los datos de los estudiantes:");
            while (true)
            {
                Estudiante estudiante = new Estudiante();

                Console.Write("Nombre del estudiante (o 'fin' para terminar): ");
                string? nombre = Console.ReadLine();
                if (string.IsNullOrEmpty(nombre) || nombre.ToLower() == "fin")
                {
                    break;
                }
                estudiante.Nombre = nombre;

                estudiante.Calificacion1 = ObtenerCalificacion("Calificación 1: ");
                estudiante.Calificacion2 = ObtenerCalificacion("Calificación 2: ");
                estudiante.Calificacion3 = ObtenerCalificacion("Calificación 3: ");

                estudiante.Promedio = (estudiante.Calificacion1 + estudiante.Calificacion2 + estudiante.Calificacion3) / 3;
                estudiante.Estado = estudiante.Promedio >= 7 ? "Aprobado" : "Reprobado"; // Cambio aquí

                estudiantes.Add(estudiante);
            }

            string json = JsonSerializer.Serialize(estudiantes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, json);

            if (File.Exists(rutaArchivo))
            {
                string jsonLeido = File.ReadAllText(rutaArchivo);
                List<Estudiante>? estudiantesLeidos = JsonSerializer.Deserialize<List<Estudiante>>(jsonLeido);

                if (estudiantesLeidos != null)
                {
                    Console.WriteLine("\nResultados:");
                    foreach (Estudiante estudiante in estudiantesLeidos)
                    {
                        Console.WriteLine($"Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio:F2}, Estado: {estudiante.Estado}");
                    }
                }
                else
                {
                    Console.WriteLine("Error al deserializar el archivo JSON.");
                }
            }
            else
            {
                Console.WriteLine("El archivo 'calificaciones.json' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        Console.ReadKey();
    }

    static double ObtenerCalificacion(string mensaje)
    {
        double calificacion;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out calificacion))
            {
                return calificacion;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Intente nuevamente.");
            }
        }
    }
}