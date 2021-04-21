using Avanade.Models;
using System;
using System.Collections.Generic;

namespace Avanade.Controllers
{
    class RobotController
    {
        public Robot Create(int id)
        {
            Console.Clear();
            Robot robot = new();
            Coordinates coordinates = new();
            robot.Coordinate = coordinates;
            robot.Id = id;

            WriteCoordinates(robot);

            Console.WriteLine("Introduzca la secuencia");
            robot.Secuency = Console.ReadLine();

            Console.WriteLine("Introduzca la Orientación");
            robot.Orientation = Console.ReadLine();

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

        public void WriteCoordinates(Robot robot)
        {
            Console.Clear();
            Console.WriteLine("Introduzca sus coordenadas ( deben ser un números entre 0 y 50");

            Console.WriteLine("Introduzca coordenada X");
            robot.Coordinate.X = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduzca coordenada Y");
            robot.Coordinate.Y = int.Parse(Console.ReadLine());
        }
    }
}