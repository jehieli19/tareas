using System; 
public class CalificacionAlumno  
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("Ingrese la calificación de la precticas:"); //  calificación de prácticas
        double practicas = Convert.ToDouble(Console.ReadLine()); // Lee  y convierte la calificación de prácticas

        Console.WriteLine("Ingrese la calificación del examen:"); // calificación de un  examen
        double examen = Convert.ToDouble(Console.ReadLine()); // Lee y convierte la calificación del examen

        Console.WriteLine("Ingrese la calificación de tareas:"); // calificación de las  tareas
        double tareas = Convert.ToDouble(Console.ReadLine()); // Lee y convierte la calificación de tareas

        double calificacionTotal = (practicas * 0.55) + (examen * 0.30) + (tareas * 0.15); // Calcula la calificación en su total

        Console.WriteLine("La calificación total del alumno es: " + calificacionTotal); // Muestra la calificación total al final 
    }
}

