using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class PersonaRepositorio
    {
        string fileName = "Persona.txt";

        public string Guardar(Persona persona)
        {
            var escritor = new StreamWriter(fileName, true);
            escritor.WriteLine(persona.ToString());
            escritor.Close();

            return "nn";
        }

        public string Guardado(List<Persona> personas)
        {

            var escritor = new StreamWriter(fileName, false);
            foreach (var item in personas)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();

            return "datos actalizados";
        }
        public List<Persona> ConsultarDatos()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                StreamReader  reader = new StreamReader(fileName);
                while (!reader.EndOfStream) 
                { 
                    var linea = reader.ReadLine();
                    personas.Add(Map(linea));
                }
                reader.Close();
                return personas;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Persona Map(string linea)
        {
            Persona persona = new Persona();
            var datos = linea.Split(';');
            persona.ID = datos[0];
            persona.Nombre = datos[1];
            persona.Sexo = datos[2];
            persona.Edad = int.Parse(datos[3]);
            persona.Pulsaciones = int.Parse(datos[4]);

            return persona;

        }
    }
}
