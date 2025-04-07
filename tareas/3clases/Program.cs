using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3clases
{


    class Program
    {
        static void Main(string[] args)
        {
            // Crear un gestor de personas
            gestorpersonas gestor = new gestorpersonas();

            // Crear dos objetos Persona
            Persona persona1 = new Persona { Nombre = "Jehieli", Edad = 30 };
            Persona persona2 = new Persona { Nombre = "Luis", Edad = 16 };

            // Agregar las personas al gestor
            gestor.AgregarPersona(persona1);
            gestor.AgregarPersona(persona2);

            // Listar las personas agregadas
            Console.WriteLine("Listado de personas:");
            gestor.ListarPersonas();

            // Validar si son mayores de edad
            Console.WriteLine($"\n¿Es {persona1.Nombre} mayor de edad? {Validador.EsMayorDeEdad(persona1.Edad)}");
            Console.WriteLine($"¿Es {persona2.Nombre} mayor de edad? {Validador.EsMayorDeEdad(persona2.Edad)}");
        }

        private class gestorpersonas
        {
            public gestorpersonas()
            {
            }
        }
    }
}