using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalcularCalificaciones
{
    // Clase que representa a un estudiante con su nombre y calificaciones
    class Estudiante
    {
        public string Nombre { get; set; }
        public List<double> Calificaciones { get; set; }

        // Constructor de la clase Estudiante
        public Estudiante(string nombre)
        {
            Nombre = nombre;
            Calificaciones = new List<double>();
        }

        // Método para agregar una calificación al estudiante
        public void AgregarCalificacion(double calificacion)
        {
            Calificaciones.Add(calificacion);
        }

        // Método para calcular el promedio de las calificaciones del estudiante
        public double CalcularPromedio()
        {
            if (Calificaciones.Count == 0)
            {
                return 0; // Evitar división por cero si no hay calificaciones
            }
            return Calificaciones.Average();
        }

        // Método para obtener la información del estudiante en formato para guardar en el archivo
        public string ObtenerInfoParaArchivo()
        {
            return $"{Nombre},{string.Join(",", Calificaciones)}";
        }

        // Método estático para crear un objeto Estudiante a partir de una línea del archivo
        public static Estudiante CrearDesdeArchivo(string linea)
        {
            string[] partes = linea.Split(',');
            if (partes.Length >= 1)
            {
                string nombre = partes[0];
                Estudiante estudiante = new Estudiante(nombre);
                for (int i = 1; i < partes.Length; i++)
                {
                    if (double.TryParse(partes[i], out double calificacion))
                    {
                        estudiante.AgregarCalificacion(calificacion);
                    }
                    else
                    {
                        Console.WriteLine($"Advertencia: No se pudo leer la calificación '{partes[i]}' para {nombre}.");
                    }
                }
                return estudiante;
            }
            return null;
        }
    }

    class Program
    {
        static string nombreArchivo = "calificaciones.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Ingresar calificaciones de alumnos");
                Console.WriteLine("2. Calcular promedios");
                Console.WriteLine("3. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarCalificaciones();
                        break;
                    case "2":
                        CalcularPromedios();
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }

        // Método para permitir al usuario ingresar las calificaciones de varios alumnos y guardarlas en el archivo
        static void RegistrarCalificaciones()
        {
            Console.WriteLine("\n--- Ingreso de Calificaciones ---");
            using (StreamWriter escritor = File.AppendText(nombreArchivo))
            {
                while (true)
                {
                    Console.Write("Ingrese el nombre del alumno (o 'fin' para terminar): ");
                    string nombreAlumno = Console.ReadLine();

                    if (nombreAlumno.ToLower() == "fin")
                    {
                        break;
                    }

                    Estudiante estudiante = new Estudiante(nombreAlumno);
                    for (int i = 1; i <= 3; i++)
                    {
                        double calificacion;
                        Console.Write($"Ingrese la calificación {i} de {nombreAlumno}: ");
                        string inputCalificacion = Console.ReadLine();
                        if (double.TryParse(inputCalificacion, out calificacion))
                        {
                            estudiante.AgregarCalificacion(calificacion);
                        }
                        else
                        {
                            Console.WriteLine("Error: Por favor, ingrese un valor numérico para la calificación.");
                            i--; // Decrementar para volver a intentar la misma calificación
                        }
                    }

                    // Guardar la información del estudiante en el archivo
                    escritor.WriteLine(estudiante.ObtenerInfoParaArchivo());
                    Console.WriteLine($"Calificaciones de {nombreAlumno} guardadas.");
                    Console.WriteLine("----------------------------------");
                }
            }
            Console.WriteLine("Ingresa calificaciones de otros alumnos o 'fin' para terminar.");
        }

        // Método para leer la información del archivo, calcular el promedio de cada alumno y mostrar los resultados
        static void CalcularPromedios()
        {
            Console.WriteLine("\n--- Promedios de los alumnos ---");
            if (File.Exists(nombreArchivo))
            {
                List<Estudiante> estudiantes = new List<Estudiante>();
                using (StreamReader lector = new StreamReader(nombreArchivo))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        Estudiante estudiante = Estudiante.CrearDesdeArchivo(linea);
                        if (estudiante != null)
                        {
                            estudiantes.Add(estudiante);
                        }
                    }
                }

                if (estudiantes.Count > 0)
                {
                    foreach (Estudiante estudiante in estudiantes)
                    {
                        Console.WriteLine($"El promedio de {estudiante.Nombre} es: {estudiante.CalcularPromedio():F2}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron datos de alumnos en el archivo.");
                }
            }
            else
            {
                Console.WriteLine($"El archivo '{nombreArchivo}' no existe. Primero debe ingresar las calificaciones.");
            }
        }
    }
}