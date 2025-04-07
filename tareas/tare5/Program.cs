using System; 

public class Calculo_Corredores // Define la clase principal del programa
{
    public static void Main(string[] args) // El método Main, punto de entrada del programa
    {
        double distancia = 1500; // Declara y asigna la distancia de la carrera (1500 metros)

        while (true) // Inicia un bucle infinito que se ejecuta hasta que se introduce (0, 0)
        {
            Console.Write("Ingrese los minutos: "); // Muestra un mensaje para ingresar los minutos
            string minutosStr = Console.ReadLine(); // Lee la entrada del usuario como una cadena
            int minutos = int.Parse(minutosStr); // Convierte la cadena a un entero

            Console.Write("Ingrese los segundos: "); // Muestra un mensaje para ingresar los segundos
            string segundosStr = Console.ReadLine(); // Lee la entrada del usuario como una cadena
            int segundos = int.Parse(segundosStr); // Convierte la cadena a un entero

            if (minutos == 0 && segundos == 0) // Comprueba si se ingresó (0, 0) para salir del bucle
            {
                break; // Sale del bucle while, finalizando la entrada
            }

            double tiempoEnSegundos = (minutos * 60) + segundos; // Calcula el tiempo total en segundos
            double velocidad = distancia / tiempoEnSegundos; // Calcula la velocidad en metros por segundo

            Console.WriteLine($"Tiempo: {minutos} minutos y {segundos} segundos"); // Muestra el tiempo del corredor
            Console.WriteLine($"Velocidad: {velocidad:F2} m/s"); // Muestra la velocidad formateada a 2 decimales
            Console.WriteLine(); // Imprime una línea en blanco para separar los resultados
        }
      }
       } 