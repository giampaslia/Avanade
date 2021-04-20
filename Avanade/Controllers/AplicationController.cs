using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Controllers
{
    class AplicationController : IAplicationController
    {
        public void menuPrincipal()
        {
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\t1 - Ver instrucciones");
            Console.WriteLine("\t2 - Menú robots");
            Console.WriteLine("\t3 - Comenzar secuencias");
            Console.WriteLine("\t0 - Salir");

            switch (Console.ReadLine())
            {
                case "0":
                    Console.Clear();
                    break;
                case "1":
                    Console.Clear();
                    leerInstruccionesGenerales();
                    break;
                case "2":
                    Console.Clear();
                    menuRobots();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("La opción no es valida, elija una opción");
                    menuPrincipal();
                    break;
            }
        }
    }
}