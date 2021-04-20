using Avanade.Models;
using System;
using System.Collections.Generic;

namespace Avanade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Martian robots!");
            menuPrincipal();
            //int option = int.Parse(Console.ReadLine());


            //string line = Console.ReadLine();
            //List<Robot> Robots = new List<Robot>();

            ////Console.WriteLine("Escribio : " + line);
            //Robot robot = new Robot();
        }

        //public static void menuPrincipal()
        //{
        //    Console.WriteLine("Elija una opción");
        //    Console.WriteLine("\t1 - Ver instrucciones");
        //    Console.WriteLine("\t2 - Menú robots");
        //    Console.WriteLine("\t3 - Comenzar secuencias");
        //    Console.WriteLine("\t0 - Salir");

        //    switch (Console.ReadLine())
        //    {
        //        case "0":
        //            Console.Clear();
        //            break;
        //        case "1":
        //            Console.Clear();
        //            leerInstruccionesGenerales();
        //            break;
        //        case "2":
        //            Console.Clear();
        //            menuRobots();
        //            break;
        //        default:
        //            Console.Clear();
        //            Console.WriteLine("La opción no es valida, elija una opción");
        //            menuPrincipal();
        //            break;
        //    }
        //}

        public static void menuRobots()
        {
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\t1 - Instrucciones");
            Console.WriteLine("\t2 - Crear robot");
            Console.WriteLine("\t3 - Eliminar robot");
            Console.WriteLine("\t4 - Editar robot");
            Console.WriteLine("\t5 - Editar robot");
            Console.WriteLine("\t0 - Volver al menú principal");

            switch (Console.ReadLine())
            {
                case "0":
                    Console.Clear();
                    menuPrincipal();
                    break;
                case "1":
                    Console.Clear();
                    menuRobots();
                    break;
                case "2":
                    Console.Clear();
                    menuRobots();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("La opción no es válida, elija una opción");
                    menuRobots();
                    break;
            }
        }

        public static void leerInstruccionesGenerales()
        {
            Console.WriteLine("Welcome to Martian robots!\n");

            Console.WriteLine("Estas son las instrucciones generales de la aplicación:");

            Console.WriteLine("Los menús, constaran de varias opciones, para elegir una opción " +
                "se debe escribir el número de la opción y pulsar la tecla de \"Enter\".");

            Console.WriteLine("Si selecciona la opción \"Menú Robots\" podrá acceder a otro menú" +
                " donde gestionar a los robots.");

            Console.WriteLine("Si selecciona la opción \"Comenzar secuencias\" los robots " +
                "comenzaran a moverse, en función de los movimientos establecidos para cada robot." +
                " Para mas información sobre las secuencias acceda a las instrucciones de la" +
                " opción \"Menú robot\".");

            Console.WriteLine("Si selecciona la opción \"Salir\" saldrá de la aplicación y perderá todos los datos introducidos.");

            Console.WriteLine("\nPulse cualquier carácter para volver al menú principal.");
            Console.ReadKey();
            Console.Clear();
            menuPrincipal();
        }
    }
}