using System;

public class SumaYPromedio
{
    public static void Main(string[] args)
    {
        // Declaración de  arreglo para almacenar 10 nu enteros
        int[] numeros = new int[10];

        // Declaración de  variable para almacenar la suma de los números
        int suma = 0;

        // Bucle for para pedir al usuario que ingrese 10 números
        for (int i = 0; i < 10; i++)
        {
            // Mostrar un mensaje pidiendo al usuario que ingrese el número actual
            Console.Write($"Ingresa el número {i + 1}: ");

            // Leer la entrada del usuario, convertirla a entero y almacenarla en el arreglo
            numeros[i] = int.Parse(Console.ReadLine());

            // Agregar el número ingresado a la variable suma
            suma += numeros[i];
        }

        // Calcular el promedio de los números
        // Se convierte la suma a double para obtener un resultado decimal
        double promedio = (double)suma / 10;

        // Mostrar la suma de los números
        Console.WriteLine($"La suma de los números es: {suma}");

        // Mostrar el promedio de los números
        Console.WriteLine($"El promedio de los números es: {promedio}");
    }
}





