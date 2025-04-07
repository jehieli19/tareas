using System; 
public class SerieNumeros // Define la clase SerieNumeros
{
    public static void Main(string[] args) 
    {
        int contador = 0; // Inicializa el contador de números
        int numero; // Declara la variable para almacenar el número leído

        Console.WriteLine("Ingrese una serie de números (0 para terminar):"); // Pide la serie de números

        do // Inicia un bucle do-while
        {
            numero = Convert.ToInt32(Console.ReadLine()); // Lee un número y lo convierte a entero

            if (numero != 0) // Si el número no es 0
            {
                Console.WriteLine(numero); // Muestra el número
                contador++; // Incrementa el contador
            }
        } while (numero != 0); // Repite el bucle mientras el número no sea 0

        Console.WriteLine("Se leyeron " + contador + " números."); // Muestra la cantidad de números leídos
    }
}