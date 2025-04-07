using System;

public class ReciboAgua
{
    private double metrosCubicosConsumidos;
    private const double LitrosPorMetroCubico = 1000;

    public ReciboAgua(double metrosCubicos)
    {
        metrosCubicosConsumidos = metrosCubicos;
    }

    public double ObtenerMetrosCubicos()
    {
        return metrosCubicosConsumidos;
    }

    public double CalcularConsumoLitros()
    {
        return metrosCubicosConsumidos * LitrosPorMetroCubico;
    }

    public void MostrarConsumo()
    {
        double litrosConsumidos = CalcularConsumoLitros();
        Console.WriteLine($"\n--- Reporte de Consumo de Agua ---");
        Console.WriteLine($"Metros cúbicos consumidos: {metrosCubicosConsumidos:F2} m³");
        Console.WriteLine($"Litros de agua consumidos: {litrosConsumidos:F2} litros");
        Console.WriteLine("------------------------------------");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la cantidad de metros cúbicos de agua reportada en su recibo:");
        if (double.TryParse(Console.ReadLine(), out double metrosCubicos))
        {
            ReciboAgua recibo = new ReciboAgua(metrosCubicos);
            recibo.MostrarConsumo();
        }
        else
        {
            Console.WriteLine("Cantidad de metros cúbicos inválida. Por favor, ingrese un número.");
        }

        Console.ReadKey(); // Para que la consola no se cierre inmediatamente
    }
}
