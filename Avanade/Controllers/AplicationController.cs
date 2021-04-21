﻿using Avanade.Models;
using System;
using System.Collections.Generic;

namespace Avanade.Controllers
{
    class AplicationController
    {
        #region variables
        public static List<Robot> robots = new();
        #endregion

        #region menús
        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\t1 - Ver instrucciones");
            Console.WriteLine("\t2 - Menú robots");
            Console.WriteLine("\t3 - Comenzar secuencias");
            Console.WriteLine("\t0 - Salir");

            switch (Console.ReadLine())
            {
                case "0":
                    break;
                case "1":
                    LeerInstruccionesGenerales();
                    VolverMenuPrincipal();
                    break;
                case "2":
                    MenuRobots();
                    break;
                case "3":
                    Console.WriteLine("Comenzar secuencias aun no esta implementado");
                    break;
                default:
                    Console.WriteLine("La opción no es valida, " +
                        "las opciones validas son los números \"0\" \"1\" \"2\" \"3\"" +
                        ". Pulse cualquier tecla para continuar");
                    Console.ReadKey();
                    MenuPrincipal();
                    break;
            }
        }

        public void MenuRobots()
        {
            Console.Clear();
            RobotController robot = new();
            Console.WriteLine("Elija una opción");
            Console.WriteLine("\t1 - Instrucciones");
            Console.WriteLine("\t2 - Crear robot");
            Console.WriteLine("\t3 - Eliminar robot");
            Console.WriteLine("\t4 - Editar robot");
            Console.WriteLine("\t5 - Listado de robots");
            Console.WriteLine("\t0 - Volver al menú principal");

            switch (Console.ReadLine())
            {
                case "0":
                    MenuPrincipal();
                    break;
                case "1":
                    LeerInstruccionesRobots();
                    VolverMenuRobots();
                    break;
                case "2":
                    robots.Add(robot.Create(robots.Count));
                    MenuRobots();
                    break;
                case "3":
                    Console.WriteLine("Aun no implementado");
                    break;
                case "4":
                    Console.WriteLine("Aun no implementado");
                    break;
                case "5":
                    robot.RobotsList(robots);
                    VolverMenuRobots();
                    break;
                default:
                    Console.WriteLine("La opción no es válida, " +
                        "las opciones validas son los números \"0\" \"1\" \"2\" \"3\" \"4\" \"5\". " +
                        "Pulse cualquier tecla para continuar");
                    Console.ReadKey();
                    MenuRobots();
                    break;
            }
        }

        public void VolverMenuPrincipal()
        {
            Console.WriteLine("\nPulse cualquier carácter para volver al menú principal.");
            Console.ReadKey();
            MenuPrincipal();
        }

        public void VolverMenuRobots()
        {
            Console.WriteLine("\nPulse cualquier carácter para volver al menú de los robots.");
            Console.ReadKey();
            MenuRobots();
        }

        #endregion

        #region instrucciones
        public void LeerInstruccionesGenerales()
        {
            Console.Clear();

            Console.WriteLine("Estas son las instrucciones generales de la aplicación:");

            Console.WriteLine("Los menús, constaran de varias opciones, para elegir una opción " +
                "se debe escribir el número de la opción y pulsar la tecla de \"Enter\".");

            Console.WriteLine("Si selecciona la opción \"Menú Robots\" podrá acceder a otro menú" +
                " donde gestionar a los robots.");

            Console.WriteLine("Si selecciona la opción \"Comenzar secuencias\" los robots " +
                "comenzaran a moverse, en función de los movimientos establecidos para cada robot." +
                " Para mas información sobre las secuencias acceda a las instrucciones de la" +
                " opción \"Menú robot\".");

            Console.WriteLine("Si selecciona la opción \"Salir\" saldrá de la aplicación y perderá" +
                " todos los datos introducidos.");
        }

        public void LeerInstruccionesRobots()
        {
            Console.Clear();

            Console.WriteLine("Estas son las instrucciones del menú de los robots");

            Console.WriteLine("Los menús, constaran de varias opciones, para elegir una opción " +
                "se debe escribir el número de la opción y pulsar la tecla de \"Enter\".");


            Console.WriteLine("Si selecciona la opción \"Salir\" saldrá de la aplicación y perderá" +
                " todos los datos introducidos.");

            Console.WriteLine("\nPulse cualquier carácter para volver al menú de los robots.");
            Console.ReadKey();
            Console.Clear();
            MenuPrincipal();
        }

        #endregion              
    }
}