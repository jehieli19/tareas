
using System;

public class OrdenamientoBurbuja
{
    public static void Main(string[] args)
    {
        // Solicitar al usuario la cantidad de números a ordenar
        Console.WriteLine("Ingrese la cantidad de números a ordenar:");
        int cantidad = int.Parse(Console.ReadLine());

        // Crear un arreglo para almacenar los números ingresados
        int[] numeros = new int[cantidad];

        // Solicitar al usuario que ingrese los números
        Console.WriteLine("Ingrese los números:");
        for (int i = 0; i < cantidad; i++)
        {
            numeros[i] = int.Parse(Console.ReadLine());
        }

        // Llamar a la función para ordenar el arreglo
        OrdenarBurbuja(numeros);

        // Mostrar el arreglo ordenado
        Console.WriteLine("Arreglo ordenado:");
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(numeros[i] + " ");
        }
    }

    // Función que implementa el algoritmo de ordenamiento de burbuja
    public static void OrdenarBurbuja(int[] arreglo)
    {
        int n = arreglo.Length; // Obtener la longitud del arreglo

        // Bucle externo: recorre el arreglo n-1 veces
        for (int i = 0; i < n - 1; i++)
        {
            // Bucle interno: compara elementos adyacentes y los intercambia si es necesario
            for (int j = 0; j < n - i - 1; j++)
            {
                // Comparar elementos adyacentes
                if (arreglo[j] > arreglo[j + 1])
                {
                    // Intercambiar arreglo[j] y arreglo[j+1]
                    int temp = arreglo[j];
                    arreglo[j] = arreglo[j + 1];
                    arreglo[j + 1] = temp;
                }
            }
        }
    }
}
