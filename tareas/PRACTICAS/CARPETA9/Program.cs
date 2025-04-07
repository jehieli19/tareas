using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RegistroVentasCSV
{
    class Program
    {
        static string nombreArchivo = "ventas.csv";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Registro y Cálculo de Ventas ---");
                Console.WriteLine("1. Registrar Venta");
                Console.WriteLine("2. Calcular Total de Ventas del Día");
                Console.WriteLine("3. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarVenta();
                        break;
                    case "2":
                        CalcularTotalVentas();
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

        static void RegistrarVenta()
        {
            Console.WriteLine("\n--- Registrar Nueva Venta ---");

            Console.Write("Nombre del Producto: ");
            string nombreProducto = Console.ReadLine();

            Console.Write("Cantidad Vendida: ");
            string cantidadVendidaStr = Console.ReadLine();
            if (!int.TryParse(cantidadVendidaStr, out int cantidadVendida) || cantidadVendida <= 0)
            {
                Console.WriteLine("Error: La cantidad vendida debe ser un número entero mayor que cero.");
                return;
            }

            Console.Write("Precio Unitario: ");
            string precioUnitarioStr = Console.ReadLine();
            if (!decimal.TryParse(precioUnitarioStr, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal precioUnitario) || precioUnitario <= 0)
            {
                Console.WriteLine("Error: El precio unitario debe ser un número mayor que cero.");
                return;
            }

            string lineaVenta = $"{nombreProducto},{cantidadVendida},{precioUnitario.ToString(CultureInfo.InvariantCulture)}";

            try
            {
                File.AppendAllText(nombreArchivo, lineaVenta + Environment.NewLine);
                Console.WriteLine("Venta registrada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
            }
        }

        static void CalcularTotalVentas()
        {
            Console.WriteLine("\n--- Cálculo del Total de Ventas del Día ---");

            if (!File.Exists(nombreArchivo))
            {
                Console.WriteLine($"El archivo '{nombreArchivo}' no existe. Primero debe registrar ventas.");
                return;
            }

            decimal totalVentas = 0;
            try
            {
                string[] lineas = File.ReadAllLines(nombreArchivo);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length == 3)
                    {
                        string nombreProducto = datos[0];
                        if (int.TryParse(datos[1], out int cantidadVendida) &&
                            decimal.TryParse(datos[2], NumberStyles.Float, CultureInfo.InvariantCulture, out decimal precioUnitario))
                        {
                            totalVentas += cantidadVendida * precioUnitario;
                        }
                        else
                        {
                            Console.WriteLine($"Advertencia: Formato incorrecto en la línea: {linea}. Se omitirá para el cálculo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Advertencia: Formato incorrecto en la línea: {linea}. Se omitirá para el cálculo.");
                    }
                }

                Console.WriteLine($"El total de ventas del día es: {totalVentas.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
        }
    }
}