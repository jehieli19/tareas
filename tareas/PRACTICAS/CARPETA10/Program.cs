using System;

namespace FilasMatriz
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Declaración para almacenar los valores.
            int[,] matriz = new int[3, 3];

            Console.WriteLine("--- Ingreso de valores para la matriz  ---");

            // 2. Bucle .
            for (int i = 0; i < 3; i++)
            {
                // 3. Bucle para iterar a través de las columnas de la matriz 
                for (int j = 0; j < 3; j++)
                {
                    // 4. Solicitar al usuario que ingrese el valor
                    Console.Write($"Ingrese el valor para la celda [{i + 1},{j + 1}]: ");
                    string input = Console.ReadLine();

                    // 5. Intentar convertir la entrada de la persona (que es una cadena) 
                    if (int.TryParse(input, out int valorIngresado))
                    {
                        // 6. Si la conversión es exitosa, asignar el valor ingresado a la celda 
                        matriz[i, j] = valorIngresado;
                    }
                    else
                    {
                        // 7. Si la conversión falla (el usuario no ingresó un número entero válido), mostrar un mensaje de error.
                        Console.WriteLine("Error: Por favor, ingrese un número entero .");
                        // 8. Decrementar el índice de la columna (j--) para que el bucle vuelva a la misma columna
                        //    en la misma fila, permitiendo al usuario intentar ingresar el valor nuevamente.
                        j--;
                    }
                }
            }

            Console.WriteLine("\nMatriz original:");
            // 9. Llamar al método MostrarMatriz para mostrar la matriz 
            MostrarMatriz(matriz);

            // 10. Solicitar al usuario el número por el cual desea multiplicar
            Console.Write("\nIngrese el número por el cual desea multiplicar cada fila: ");
            string numeroMultiplicadorInput = Console.ReadLine();

            // 11. Intentar convertir la entrada para multiplicador a un número entero.
            if (int.TryParse(numeroMultiplicadorInput, out int numeroMultiplicador))
            {
                // 12. Crear una nueva matriz de 3x3 para almacenar los resultados de la multiplicación.
                //     Es una buena práctica crear una nueva matriz para no modificar la original directamente.
                int[,] nuevaMatriz = new int[3, 3];
                // 13. Bucle exterior para iterar a través de las filas de la matriz original.
                for (int i = 0; i < 3; i++)
                {
                    // 14. Bucle interior para iterar a través de las columnas de la matriz original para la fila actual.
                    for (int j = 0; j < 3; j++)
                    {
                        // 15. Multiplicar el valor de la celda actual de la matriz original por el número multiplicador
                        //     y almacenar el resultado en la celda correspondiente de la nueva matriz.
                        nuevaMatriz[i, j] = matriz[i, j] * numeroMultiplicador;
                    }
                }

                // 16. Mostrar la nueva matriz con los valores actualizados después de la multiplicación.
                Console.WriteLine($"\nNueva matriz después de multiplicar cada fila por {numeroMultiplicador}:");
                // 17. Llamar al método MostrarMatriz para mostrar la nueva matriz.
                MostrarMatriz(nuevaMatriz);
            }
            else
            {
                // 18. Si el usuario no ingresa un número entero válido para el multiplicador, mostrar un mensaje de error.
                Console.WriteLine("Error: Por favor, ingrese un número entero válido para el multiplicador.");
            }

            // 19. Mantener la ventana de la consola abierta hasta que el usuario presione una tecla
            //     para que pueda ver la salida del programa antes de que se cierre automáticamente.
            Console.ReadKey();
        }

        // 20. Método auxiliar estático para mostrar los elementos de una matriz de 3x3 en la consola.
        static void MostrarMatriz(int[,] matriz)
        {
            // 21. Bucle exterior para iterar a través de las filas de la matriz.
            for (int i = 0; i < 3; i++)
            {
                // 22. Imprimir un corchete de apertura para indicar el inicio de la fila.
                Console.Write("[");
                // 23. Bucle interior para iterar a través de las columnas de la matriz para la fila actual.
                for (int j = 0; j < 3; j++)
                {
                    // 24. Imprimir el valor de la celda actual.
                    Console.Write(matriz[i, j]);
                    // 25. Si no es el último elemento de la fila, imprimir una coma y un espacio para separar los valores.
                    if (j < 2)
                    {
                        Console.Write(", ");
                    }
                }
                // 26. Imprimir un corchete de cierre para indicar el final de la fila y luego un salto de línea
                //     para pasar a la siguiente fila en la consola.
                Console.WriteLine("]");
            }
        }
    }
}