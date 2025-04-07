using System;
using System.Linq;

namespace EliminarNumeroArregloOO
{
    // Clase que representa un arreglo de números con funcionalidades de agregar y eliminar.
    class ArregloNumerico
    {
        private int[] _numeros;

        // Constructor para inicializar el arreglo con un tamaño específico.
        public ArregloNumerico(int tamaño)
        {
            _numeros = new int[tamaño];
            Longitud = tamaño;
        }

        // Propiedad para obtener la longitud del arreglo.
        public int Longitud { get; }

        // Propiedad para acceder a los elementos del arreglo (solo lectura para este ejemplo).
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Longitud)
                {
                    return _numeros[index];
                }
                throw new IndexOutOfRangeException("Índice fuera de los límites del arreglo.");
            }
            // No se implementa el setter para mantener la inicialización desde fuera.
        }

        // Método para establecer el valor en una posición específica del arreglo.
        public void EstablecerValor(int indice, int valor)
        {
            if (indice >= 0 && indice < Longitud)
            {
                _numeros[indice] = valor;
            }
            else
            {
                throw new IndexOutOfRangeException("Índice fuera de los límites del arreglo.");
            }
        }

        // Método para eliminar un número específico del arreglo y devolver un nuevo arreglo sin ese número.
        public ArregloNumerico EliminarNumero(int numeroAEliminar)
        {
            // Utilizamos LINQ para filtrar los números que no son iguales al número a eliminar.
            int[] nuevoArregloInterno = _numeros.Where(num => num != numeroAEliminar).ToArray();

            // Creamos una nueva instancia de ArregloNumerico con el nuevo tamaño.
            ArregloNumerico nuevoArregloObjeto = new ArregloNumerico(nuevoArregloInterno.Length);

            // Copiamos los elementos del nuevo arreglo interno al nuevo objeto ArregloNumerico.
            for (int i = 0; i < nuevoArregloInterno.Length; i++)
            {
                nuevoArregloObjeto.EstablecerValor(i, nuevoArregloInterno[i]);
            }

            return nuevoArregloObjeto;
        }

        // Método para mostrar el contenido del arreglo.
        public void MostrarArreglo()
        {
            Console.Write("[");
            for (int i = 0; i < Longitud; i++)
            {
                Console.Write(_numeros[i]);
                if (i < Longitud - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear una instancia de la clase ArregloNumerico con un tamaño de 10.
            ArregloNumerico miArreglo = new ArregloNumerico(10);

            Console.WriteLine("--- Ingreso de 10 números al arreglo ---");

            // 2. Solicitar al usuario que ingrese 10 números y los guardar en el objeto ArregloNumerico.
            for (int i = 0; i < miArreglo.Longitud; i++)
            {
                Console.Write($"Ingrese el número {i + 1}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int numeroIngresado))
                {
                    miArreglo.EstablecerValor(i, numeroIngresado);
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese un número entero válido.");
                    i--; // Decrementar el índice para que el usuario vuelva a ingresar el número actual.
                }
            }

            Console.WriteLine("\nArreglo original:");
            miArreglo.MostrarArreglo();

            // 3. Solicitar al usuario el número que desea eliminar del arreglo.
            Console.Write("\nIngrese el número que desea eliminar del arreglo: ");
            string numeroAEliminarInput = Console.ReadLine();

            if (int.TryParse(numeroAEliminarInput, out int numeroAEliminar))
            {
                // 4. Llamar al método EliminarNumero del objeto ArregloNumerico para obtener un nuevo objeto sin el valor eliminado.
                ArregloNumerico nuevoArreglo = miArreglo.EliminarNumero(numeroAEliminar);

                // 5. Mostrar el nuevo arreglo sin el valor eliminado.
                Console.WriteLine("\nNuevo arreglo sin el valor eliminado:");
                nuevoArreglo.MostrarArreglo();

                if (miArreglo.Longitud == nuevoArreglo.Longitud)
                {
                    Console.WriteLine($"\nEl número {numeroAEliminar} no se encontró en el arreglo original.");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor, ingrese un número entero válido para eliminar.");
            }

            Console.ReadKey();
        }
    }
}