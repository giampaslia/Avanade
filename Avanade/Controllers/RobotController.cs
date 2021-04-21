using Avanade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.Controllers
{
    class RobotController
    {
        private readonly int MaxSecuencyLenght = 100;
        private readonly List<char> ValidOrientationList = new() { 'n', 's', 'w', 'e' };
        private readonly List<char> ValidSecuencyList = new() { 'l', 'r', 'f' };
        public Robot Create(List<Robot> robots)
        {
            Console.Clear();
            Robot robot = new();
            WriteId(robots, robot);
            WriteCoordinates(robot);
            WriteSecuency(robot);
            WriteOrientation(robot);

            robot.Lost = false;

            return robot;
        }

        public void RobotsList(List<Robot> robots)
        {
            Console.Clear();
            Console.WriteLine("Hay " + robots.Count + " robots");

            foreach (Robot robot in robots)
            {
                string orientacion = string.Empty;
                switch (robot.Orientation)
                {
                    case "n":
                    case "N":
                        orientacion = "El robot se encuentra orientado hacia el Norte";
                        break;
                    case "s":
                    case "S":
                        orientacion = "El robot se encuentra orientado hacia el Sur";
                        break;
                    case "W":
                    case "w":
                        orientacion = "El robot se encuentra orientado hacia el Oeste";
                        break;
                    case "e":
                    case "E":
                        orientacion = "El robot se encuentra orientado hacia el Este";
                        break;
                }

                if (robot.Lost)
                {
                    Console.WriteLine("El id del robot es : " + robot.Id +
                     ", sus coordenadas son desconocidas, el robot se ha perdido");
                }
                else
                {
                    Console.WriteLine("El id del robot es : " + robot.Id +
                     ", sus coordenadas son: (" + robot.Coordinate.X + "," + robot.Coordinate.Y +
                     "), " + orientacion);
                }
            }
        }

        public void WriteId(List<Robot> robots, Robot robot)
        {
            if (robots.Count != 0)
            {
                robot.Id = robots.Last().Id + 1;
            }
            else
            {
                robot.Id = 0;
            }
        }

        public void WriteCoordinates(Robot robot)
        {
            Console.Clear();
            Coordinates coordinates = new();
            robot.Coordinate = coordinates;

            Console.WriteLine("Introduzca coordenada X (deben ser un números entre 0 y 50)");
            int x = int.Parse(Console.ReadLine());
            while (x < 0 || x > 50)
            {
                Console.Clear();
                Console.WriteLine("Introduzca coordenada X (deben ser un números entre 0 y 50)");
                x = int.Parse(Console.ReadLine());
            }

            robot.Coordinate.X = x;


            Console.WriteLine("Introduzca coordenada Y (deben ser un números entre 0 y 50)");
            int y = int.Parse(Console.ReadLine());
            while (y < 0 || y > 50)
            {
                Console.Clear();
                Console.WriteLine("Introduzca coordenada Y (deben ser un números entre 0 y 50)");
                y = int.Parse(Console.ReadLine());
            }

            robot.Coordinate.Y = y;
        }

        public void WriteSecuency(Robot robot)
        {
            Console.Clear();

            Console.WriteLine("Introduzca la secuencia " +
                "(la secuencia es un string formado unicamente por" +
                " las letras \"L \"  \"R \"  \"F \", debe ser menor a 100 caracteres");

            string secuency = Console.ReadLine().ToLower();

            if (secuency.Length > MaxSecuencyLenght)
            {
                WriteSecuency(robot);
            }

            foreach (Char character in secuency)
            {
                if (!ValidSecuencyList.Contains(character))
                {
                    WriteSecuency(robot);
                }
            }

            robot.Secuency = secuency;
        }

        public void WriteOrientation(Robot robot)
        {
            Console.Clear();
            Console.WriteLine("Introduzca la Orientación " +
                "(La orientación esta formada por 1 carácter \"N\"  \"S\"  \"E\"  \"W\" )");

            string orientation = Console.ReadLine().ToLower();

            if (orientation.Length > 1)
            {
                WriteOrientation(robot);
            }

            if (!ValidOrientationList.Contains(char.Parse(orientation)))
            {
                WriteOrientation(robot);
            }

            robot.Orientation = orientation;
        }
    }
}