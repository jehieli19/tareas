using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

// Clase que representa un producto con sus propiedades
public class Producto
{
    public string Codigo { get; set; } // Código único del producto
    public string Nombre { get; set; } // Nombre del producto
    public int Cantidad { get; set; } // Cantidad en stock
    public decimal Precio { get; set; } // Precio unitario del producto
}

// Clase que representa al cliente y su carrito de compras
public class Cliente
{
    public List<Producto> Carrito { get; set; } = new List<Producto>(); // Lista de productos en el carrito

    // Método para agregar un producto al carrito
    public void AgregarAlCarrito(Producto producto)
    {
        Carrito.Add(producto);
    }

    // Método para calcular el total de la compra
    public decimal CalcularTotal()
    {
        return Carrito.Sum(p => p.Precio);
    }
}

// Clase que maneja el inventario de productos
public class Inventario
{
    private static readonly string NombreArchivo = "inventario.json"; // Nombre del archivo JSON para guardar el inventario
    private static List<Producto> inventario = new List<Producto>(); // Lista de productos en el inventario

    // Método principal del programa
    public static void Main(string[] args)
    {
        InicializarInventario(); // Inicializa el inventario con productos y sus precios

        // Bucle principal del programa
        while (true)
        {
            // Menú de opciones
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar inventario");
            Console.WriteLine("3. Vender productos");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            // Lógica para manejar la opción seleccionada
            switch (opcion)
            {
                case "1":
                    AgregarProducto(); // Llama a la función para agregar un producto
                    break;
                case "2":
                    MostrarInventario(); // Llama a la función para mostrar el inventario
                    break;
                case "3":
                    VenderProductos(); // Llama a la función para vender productos
                    break;
                case "4":
                    return; // Sale del programa
                default:
                    Console.WriteLine("Opción no válida."); // Mensaje de error si la opción no es válida
                    break;
            }
        }
    }

    // Método para inicializar el inventario con productos predefinidos
    private static void InicializarInventario()
    {
        inventario.Add(new Producto { Codigo = "1520", Nombre = "Coca", Cantidad = 900, Precio = 25 });
        inventario.Add(new Producto { Codigo = "2120", Nombre = "Galleta", Cantidad = 935, Precio = 500 });
        inventario.Add(new Producto { Codigo = "9012", Nombre = "Juego", Cantidad = 200, Precio = 1500 });
        inventario.Add(new Producto { Codigo = "2525", Nombre = "Teléfono", Cantidad = 50, Precio = 5000 });
        GuardarInventario(); // Guarda el inventario en el archivo JSON
    }

    // Método para agregar un nuevo producto al inventario
    private static void AgregarProducto()
    {
        // ... (Código para agregar producto, similar al anterior)
    }

    // Método para guardar el inventario en el archivo JSON
    private static void GuardarInventario()
    {
        string jsonString = JsonSerializer.Serialize(inventario); // Serializa la lista a formato JSON
        File.WriteAllText(NombreArchivo, jsonString); // Escribe el JSON en el archivo
    }

    // Método para leer el inventario del archivo JSON
    private static List<Producto> LeerInventario()
    {
        if (File.Exists(NombreArchivo))
        {
            // Si el archivo existe, lo lee y deserializa el JSON a una lista de Productos
            string jsonString = File.ReadAllText(NombreArchivo);
            return JsonSerializer.Deserialize<List<Producto>>(jsonString) ?? new List<Producto>();
        }
        // Si el archivo no existe, devuelve la lista del inventario en memoria.
        return inventario;
    }

    // Método para mostrar el inventario en la consola
    private static void MostrarInventario()
    {
        inventario = LeerInventario(); // Lee el inventario del archivo

        if (inventario.Count == 0)
        {
            // Si el inventario está vacío, muestra un mensaje
            Console.WriteLine("El inventario está vacío.");
            return;
        }

        // Si el inventario no está vacío, muestra los datos de cada producto
        Console.WriteLine("\n--- Inventario ---");
        foreach (Producto producto in inventario)
        {
            Console.WriteLine($"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Stock: {producto.Cantidad}, Precio: {producto.Precio:C}");
        }

        decimal totalInventario = inventario.Sum(p => p.Precio); // Calcula el total del inventario
        Console.WriteLine($"\nTotal del inventario: {totalInventario:C}"); // Muestra el total del inventario
    }

    // Método para vender productos al cliente
    private static void VenderProductos()
    {
        Cliente cliente = new Cliente(); // Crea un nuevo objeto Cliente
        // Bucle para permitir al cliente agregar productos al carrito
        while (true)
        {
            Console.WriteLine("\n--- Venta de productos ---");
            MostrarInventario(); // Muestra el inventario disponible
            Console.Write("Ingrese el código del producto que desea comprar (o 'fin' para terminar): ");
            string codigo = Console.ReadLine();

            if (codigo.ToLower() == "fin")
            {
                break; // Sale del bucle si el cliente escribe "fin"
            }

            // Busca el producto en el inventario por código
            Producto producto = inventario.Find(p => p.Codigo == codigo);
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
                continue; // Vuelve al inicio del bucle si el producto no se encuentra
            }

            cliente.AgregarAlCarrito(producto); // Agrega el producto al carrito del cliente
            Console.WriteLine($"{producto.Nombre} agregado al carrito.");
        }

        decimal totalCompra = cliente.CalcularTotal(); // Calcula el total de la compra
        Console.WriteLine($"\nTotal de la compra: {totalCompra:C}"); // Muestra el total de la compra

        Console.Write("Ingrese el monto con el que paga el cliente: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal pagoCliente))
        {
            Console.WriteLine("Monto no válido.");
            return; // Sale de la función si el monto no es válido
        }

        if (pagoCliente < totalCompra)
        {
            Console.WriteLine("El monto es insuficiente.");
            return; // Sale de la función si el monto es insuficiente
        }

        decimal cambio = pagoCliente - totalCompra; // Calcula el cambio del cliente
        Console.WriteLine($"Cambio del cliente: {cambio:C}"); // Muestra el cambio del cliente
    }
}