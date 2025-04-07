using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Mostrar el producto más caro.");
        Console.WriteLine("2. Calcular ventas.");
        Console.WriteLine("3. Buscar un producto por nombre.");
        Console.WriteLine("4. Mostrar el inventario.");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                PRODUCTOS.PRODUCTOCARO();
                break;
            case "2":
                PRODUCTOS.CALCULAR_VENTAS();
                break;
            case "3":
                PRODUCTOS.ProductoBuscado();
                break;
            case "4":
                PRODUCTOS.MostrarInventario();
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}

public class PRODUCTOS
{
    public string CODIGO { get; set; }
    public string PRODUCTO { get; set; }
    public string CATEGORIA { get; set; }
    public string PRECIO { get; set; }
    public string STOCK { get; set; }
    public string CANTIDAD_VENDIDA { get; set; }

    public static void PRODUCTOCARO()
    {
        try
        {
            string jsonString = File.ReadAllText("productos.json");
            var productos = JsonSerializer.Deserialize<List<PRODUCTOS>>(jsonString);

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No existen productos.");
                return;
            }

            var productoMasCaro = productos.OrderByDescending(p => Convert.ToDecimal(p.PRECIO)).FirstOrDefault();

            if (productoMasCaro != null)
            {
                Console.WriteLine($"El producto más caro es: {productoMasCaro.PRODUCTO} con un precio de {productoMasCaro.PRECIO}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El archivo 'productos.json' no se encontró.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
    }

    public static void ProductoBuscado()
    {
        try
        {
            string jsonString = File.ReadAllText("productos.json");
            var productos = JsonSerializer.Deserialize<List<PRODUCTOS>>(jsonString);

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No existen productos.");
                return;
            }

            Console.Write("Ingrese el nombre del producto a buscar: ");
            string productoBuscado = Console.ReadLine();

            var producto = productos.FirstOrDefault(p => p.PRODUCTO.Equals(productoBuscado, StringComparison.OrdinalIgnoreCase));

            if (producto != null)
            {
                Console.WriteLine($"Producto encontrado: {producto.PRODUCTO}, Precio: {producto.PRECIO}, Stock: {producto.STOCK}");
            }
            else
            {
                Console.WriteLine($"El producto '{productoBuscado}' no se encuentra en el inventario.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
    }

    public static void CALCULAR_VENTAS()
    {
        try
        {
            Console.WriteLine("Escriba el nombre del producto:");
            string nombreProducto = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad vendida:");
            int cantidadVendida = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el precio unitario:");
            decimal precioUnitario = decimal.Parse(Console.ReadLine());

            decimal totalVenta = cantidadVendida * precioUnitario;
            Console.WriteLine($"El total de la venta es: {totalVenta}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Entrada no válida.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }
    }

    public static void MostrarInventario()
    {
        try
        {
            string jsonString = File.ReadAllText("productos.json");
            var productos = JsonSerializer.Deserialize<List<PRODUCTOS>>(jsonString);

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No existen productos.");
                return;
            }

            Console.WriteLine("Inventario:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Producto: {producto.PRODUCTO}, Precio: {producto.PRECIO}, Stock: {producto.STOCK}");
            }
        }           
   }           
              
