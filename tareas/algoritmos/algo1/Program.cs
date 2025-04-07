using System;

public class CajaOxxo
{
    private double precioProducto;
    private double pagoCliente;

    public CajaOxxo(double precio)
    {
        precioProducto = precio;
    }

    public void RecibirPago(double pago)
    {
        pagoCliente = pago;
    }

    public double CalcularCambio()
    {
        if (pagoCliente < precioProducto)
        {
            Console.WriteLine("El pago es insuficiente.");
            return -1; // Indica pago insuficiente
        }
        else
        {
            return pagoCliente - precioProducto;
        }
    }

    public void ImprimirRecibo()
    {
        if (pagoCliente >= precioProducto)
        {
            double cambio = CalcularCambio();
            Console.WriteLine("\n--- Recibo Oxxo ---");
            Console.WriteLine($"Precio del producto: ${precioProducto:F2}");
            Console.WriteLine($"Pago del cliente: ${pagoCliente:F2}");
            Console.WriteLine($"Cambio a regresar: ${cambio:F2}");
            Console.WriteLine("¡Gracias por su compra!");
        }
        else
        {
            Console.WriteLine("No se puede imprimir el recibo por pago insuficiente.");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el precio del producto:");
        if (double.TryParse(Console.ReadLine(), out double precio))
        {
            CajaOxxo caja = new CajaOxxo(precio);

            Console.WriteLine("Ingrese la cantidad con la que paga el cliente:");
            if (double.TryParse(Console.ReadLine(), out double pago))
            {
                caja.RecibirPago(pago);
                double cambio = caja.CalcularCambio();

                if (cambio >= 0)
                {
                    Console.WriteLine($"\nEl cambio a regresar es: ${cambio:F2}");
                    caja.ImprimirRecibo();
                }
            }
            else
            {
                Console.WriteLine("Cantidad de pago inválida.");
            }
        }
        else
        {
            Console.WriteLine("Precio del producto inválido.");
        }

        Console.ReadKey(); // Para que la consola no se cierre inmediatamente
    }
}