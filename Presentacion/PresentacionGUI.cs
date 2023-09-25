using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Logica;

namespace Presentacion
{
    internal class PresentacionGUI
    {
        PersonaService personaService = new PersonaService();
        public void menu()
        {
            
            int op = 0;
            do 
            { 
                Console.Clear();
                Console.WriteLine("Medu");
                Console.WriteLine("1:Registrar datos");
                Console.WriteLine("2:Consultar datos por identificacion");
                Console.WriteLine("3:Informe general de pulsaciones");
                Console.WriteLine("4:Elimiar");
                Console.WriteLine("5:Actualizar datos");
                Console.WriteLine("6:Salir");
                Console.WriteLine("");
                Console.WriteLine("Digite una opcion");
                op=int.Parse(Console.ReadLine());
                switch(op)
                {
                    case 1:

                        personaService.Agregar();
                         break;
                    case 2:
                        personaService.Mostrar();
                         break;
                    case 3:
                        MostrarId();
                         break;
                    case 4:
                        Eliminar();
                         break;
                    case 5:

                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

            } while (op != 6);


            
        }
        public void MostrarId()
        {
            Console.Clear();
            Console.WriteLine("Buscar por ID");
            Console.WriteLine("Ingrese la identificacion:    ");
            string Id = Console.ReadLine();
            Console.WriteLine(personaService.BuscarId(Id));
            Console.ReadKey();
        }

        public void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("Buscar usuario a eliminar");
            Console.WriteLine("Ingrese la identificacion:    ");
            string Id = Console.ReadLine();
            Persona persona = new Persona(Id);
            Console.WriteLine(personaService.Eliminar(persona));
            Console.ReadKey();
        }


    }
}
