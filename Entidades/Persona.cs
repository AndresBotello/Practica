using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public string ID { get; set; }

        public string Nombre { get; set; }

        public string Sexo { get; set; }

        public int Edad { get; set;}

        public int Pulsaciones { get; set;}

        public Persona()
        {
        }

        public Persona(string iD)
        {
            ID = iD;
        }

        public Persona(string iD, string nombre, string sexo, int edad, int pulsaciones)
        {
            ID = iD;
            Nombre = nombre;
            Sexo = sexo;
            Edad = edad;
            Pulsaciones = pulsaciones;
        }

        public override string ToString()
        {
            return $"{ID};{Nombre};{Sexo};{Edad};{Pulsaciones};";
        }
    }


}
