using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Logica
{
    public class PersonaService
    {
        List<Persona> listapersona;
        PersonaRepositorio personaRepositorio=new PersonaRepositorio();
        public PersonaService()
        {
            listapersona=personaRepositorio.ConsultarDatos();
        }
        public void Agregar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la identidficacion:     ");
            string Id = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre:     ");
            string Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo[M/F]:     ");
            string Sexo = Console.ReadLine().ToUpper();

            Console.WriteLine("Ingrese la edad:    ");
            int Edad = int.Parse(Console.ReadLine());

            

            int pulsaciones;
            if (Sexo == "F")
            {
                pulsaciones = (220 - Edad) / 10;

            }
            else
            {
                pulsaciones = (210 - Edad) / 10;
            }
            
            Console.WriteLine("pulsaciones:  "+pulsaciones);
           

            Persona persona = new Persona(Id,Nombre, Sexo,Edad, pulsaciones);

            Console.Write(personaRepositorio.Guardar(persona));
            Console.ReadKey();
        }

        public List<Persona> ConsultarDatos()
        {
            return listapersona;
        }

        public void Mostrar()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 2); Console.WriteLine("Listado general");
            Console.SetCursorPosition(10, 4); Console.Write("Identificacion");
            Console.SetCursorPosition(28, 4); Console.Write("Nombre");
            Console.SetCursorPosition(40, 4); Console.Write("Sexo");
            Console.SetCursorPosition(46, 4); Console.Write("Edad");
            Console.SetCursorPosition(56, 4); Console.Write("Pulsacion");
            int posicion = 2;
            foreach (var item in personaRepositorio.ConsultarDatos())
            {
                Console.SetCursorPosition(15, 4 + posicion); Console.Write(item.ID);
                Console.SetCursorPosition(29, 4 + posicion); Console.Write(item.Nombre);
                Console.SetCursorPosition(42, 4 + posicion); Console.Write(item.Sexo);
                Console.SetCursorPosition(48, 4 + posicion); Console.Write(item.Edad);
                Console.SetCursorPosition(52, 4 + posicion); Console.Write(item.Pulsaciones);
                posicion++;

            }
            Console.ReadKey();
        }

        public Persona BuscarId(string id)
        {
            foreach (var item in listapersona)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Eliminar(Persona persona)
        {
            if ( persona == null)
            {
                return false;
            }
            var buscado = BuscarId(persona.ID);
            if (buscado != null)
            {
                listapersona.Remove(buscado);
                Actualizar(listapersona);
                return true;
            }
            return false;
        }
        
        //public string Actualizar(Persona personas)
        //{
        //    var msg = personaRepositorio.Guardar(personas);
        //    listapersona = personaRepositorio.ConsultarDatos();
        //    return msg;
        //}

        public string Actualizar(List<Persona> personas)
        {
            var msg = personaRepositorio.Guardado(personas);
            listapersona = personaRepositorio.ConsultarDatos();
            return msg;
        }
    }
}
