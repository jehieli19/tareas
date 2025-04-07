using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3clases
{
    internal class gestorpersona
    {
        private List<Persona> personas = new List<Persona>();

        // Método para agregar una persona
        public void AgregarPersona(Persona persona)
        {
            personas.Add(persona);
        }

        // Método para listar las personas
        public void ListarPersonas()
        {
            foreach (var persona in personas)
            {
                Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
            }
        }
    }
}