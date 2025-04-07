using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

public class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
}

public class Cliente
{
    public List<Producto> Carrito { get; set; } = new List<Producto>();

    public void AgregarAlCarrito(Producto producto)
    {
        Carrito.Add(producto);
    }

    public decimal CalcularTotal()
    {
        return Carrito.Sum(p => p.Precio);
    }
}

public class Inventario
{
    private static readonly string NombreArchivo = "inventario.json";
    private static List<Producto> inventario = new List<Producto>();

    public static void Main(string[] args)
    {
        InicializarInventario();

        while (true)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar inventario");
            Console.WriteLine("3. Vender productos");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarProducto();
                    break;
                case "2":
                    MostrarInventario();
                    break;
                case "3":
                    VenderProductos();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private static void InicializarInventario()
    {
        inventario.Add(new Producto { Codigo = "2120", Nombre = "table", Cantidad = 935, Precio = 5000.10m });
        inventario.Add(new Producto { Codigo = "9012", Nombre = "lap", Cantidad = 200, Precio = 15000.10m });
        inventario.Add(new Producto { Codigo = "2525", Nombre = "cel", Cantidad = 50, Precio = 9000.12m });
        GuardarInventario();
    }

    private static void AgregarProducto()
    {
        Console.Write("Ingrese el código del producto: ");
        string codigo = Console.ReadLine();

        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cantidad del producto: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Cantidad no válida.");
            return;
        }

        Console.Write("Ingrese el precio del producto: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
        {
            Console.WriteLine("Precio no válido.");
            return;
        }

        inventario.Add(new Producto { Codigo = codigo, Nombre = nombre, Cantidad = cantidad, Precio = precio });
        GuardarInventario();
        Console.WriteLine("Producto agregado exitosamente.");
    }

    private static void GuardarInventario()
    {
        string jsonString = JsonSerializer.Serialize(inventario);
        File.WriteAllText(NombreArchivo, jsonString);
    }

    private static List<Producto> LeerInventario()
    {
        if (File.Exists(NombreArchivo))
        {
            string jsonString = File.ReadAllText(NombreArchivo);
            return JsonSerializer.Deserialize<List<Producto>>(jsonString) ?? new List<Producto>();
        }

        return inventario;
    }

    private static void MostrarInventario()
    {
        inventario = LeerInventario();

        if (inventario.Count == 0)
        {
            Console.WriteLine("El inventario está vacío.");
            return;
        }

        Console.WriteLine("\n--- Inventario ---");
        foreach (Producto producto in inventario)
        {
            Console.WriteLine($"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Stock: {producto.Cantidad}, Precio: {producto.Precio:C}");
        }

        decimal totalInventario = inventario.Sum(p => p.Precio * p.Cantidad);
        Console.WriteLine($"\nTotal del inventario: {totalInventario:C}");
    }

    private static void VenderProductos()
    {
        Cliente cliente = new Cliente();

        while (true)
        {
            Console.WriteLine("\n--- Venta de productos ---");
            MostrarInventario();
            Console.Write("Ingrese el código del producto que desea comprar (o 'fin' para terminar): ");
            string codigo = Console.ReadLine();

            if (codigo.ToLower() == "fin")
            {
                break;
            }

            Producto producto = inventario.Find(p => p.Codigo == codigo);
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
                continue;
            }

            Console.Write("Ingrese la cantidad que desea comprar: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0 || cantidad > producto.Cantidad)
            {
                Console.WriteLine("Cantidad no válida o insuficiente en inventario.");
                continue;
            }

            producto.Cantidad -= cantidad;
            cliente.AgregarAlCarrito(new Producto
            {
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Cantidad = cantidad,
                Precio = producto.Precio * cantidad
            });

            Console.WriteLine($"{producto.Nombre} agregado al carrito.");
        }

        decimal totalCompra = cliente.CalcularTotal();
        Console.WriteLine($"\nTotal de la compra: {totalCompra:C}");
        Console.Write("Ingrese el monto con el que paga el cliente: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal pagoCliente))
        {
            Console.WriteLine("Monto no válido.");
            return;
        }

        if (pagoCliente < totalCompra)
        {
            Console.WriteLine("El monto es insuficiente.");
            return;
        }

        decimal cambio = pagoCliente - totalCompra;
        Console.WriteLine($"Cambio del cliente: {cambio:C}");
        GuardarInventario();
  
    }   
}