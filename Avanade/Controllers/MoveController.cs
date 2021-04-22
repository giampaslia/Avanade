using Avanade.Models;
using System;
using System.Collections.Generic;

namespace Avanade.Controllers
{
    class MoveController
    {
        public void Start(List<Robot> robots, List<Coordinates> lostRobots)
        {
            Console.Clear();
            if (robots.Count == 0)
            {
                Console.WriteLine("No hay ningún robot existente," +
                    " cree algunos robots antes de comenzar las secuencias");
            }

            foreach (Robot robot in robots)
            {
                Move(robot, lostRobots);
            }

        }

        private void Move(Robot robot, List<Coordinates> lostRobots)
        {
            foreach (char order in robot.Secuency)
            {
                if (!robot.Lost)
                {
                    RobotPosition(robot);
                    EjecuteOrder(order, robot, lostRobots);
                }
            }
            RobotPosition(robot);
        }

        private void RobotPosition(Robot robot)
        {
            string orientation = string.Empty;
            string text = "El robot " + robot.Id;

            switch (robot.Coordinate.Orientation)
            {
                case "n":
                    orientation = "Norte";
                    break;
                case "s":
                    orientation = "Sur";
                    break;
                case "e":
                    orientation = "Este";
                    break;
                case "w":
                    orientation = "Oeste";
                    break;
            }

            if (!robot.Lost)
            {
                text += " se encuentra en las coordenadas (";
                text += robot.Coordinate.X;
                text += ",";
                text += robot.Coordinate.Y;
                text += "), esta orientado hacia el ";
                text += orientation;
            }
            else
            {
                text += " esta perdido, sus ultimas coordenadas fueron (";
                text += robot.Coordinate.X;
                text += ",";
                text += robot.Coordinate.Y;
                text += "), orientado hacia el ";
                text += orientation;
            }

            Console.WriteLine(text);
        }

        private void EjecuteOrder(char order, Robot robot, List<Coordinates> lostRobots)
        {
            switch (order)
            {
                case 'l':
                    RotateToLeft(robot);
                    break;
                case 'r':
                    RotateToRight(robot);
                    break;
                case 'f':
                    AvanceToFront(robot, lostRobots);
                    if (robot.Lost)
                    {
                        lostRobots.Add(robot.Coordinate);
                    }
                    break;
                default:
                    Console.WriteLine("Ups algo fue mal");
                    break;
            }
        }

        private void AvanceToFront(Robot robot, List<Coordinates> lostRobots)
        {
            switch (robot.Coordinate.Orientation)
            {
                case "n":
                    if (!CompareCoordinates(robot.Coordinate, lostRobots))
                    {
                        UpCoordinateY(robot);
                    }
                    break;
                case "e":
                    if (!CompareCoordinates(robot.Coordinate, lostRobots))
                    {
                        UpCoordinateX(robot);
                    }
                    break;
                case "s":
                    if (!CompareCoordinates(robot.Coordinate, lostRobots))
                    {
                        DownCoordinateY(robot);
                    }
                    break;
                case "w":
                    if (!CompareCoordinates(robot.Coordinate, lostRobots))
                    {
                        DownCoordinateX(robot);
                    }
                    break;
                default:
                    Console.WriteLine("Ups algo fue mal");
                    break;
            }
        }

        private void RotateToRight(Robot robot)
        {
            if (!robot.Lost)
            {
                switch (robot.Coordinate.Orientation)
                {
                    case "n":
                        robot.Coordinate.Orientation = "e";
                        break;
                    case "e":
                        robot.Coordinate.Orientation = "s";
                        break;
                    case "s":
                        robot.Coordinate.Orientation = "w";
                        break;
                    case "w":
                        robot.Coordinate.Orientation = "n";
                        break;
                    default:
                        Console.WriteLine("Ups algo fue mal");
                        break;
                }
            }
        }

        private void RotateToLeft(Robot robot)
        {
            if (!robot.Lost)
            {
                switch (robot.Coordinate.Orientation)
                {
                    case "n":
                        robot.Coordinate.Orientation = "w";
                        break;
                    case "e":
                        robot.Coordinate.Orientation = "n";
                        break;
                    case "s":
                        robot.Coordinate.Orientation = "e";
                        break;
                    case "w":
                        robot.Coordinate.Orientation = "s";
                        break;
                    default:
                        Console.WriteLine("Ups algo fue mal");
                        break;
                }
            }
        }

        private void UpCoordinateX(Robot robot)
        {
            if (robot.Coordinate.X == 50)
            {
                robot.Lost = true;
            }

            if (robot.Coordinate.X < 50)
            {
                robot.Coordinate.X++;
            }
        }

        private void DownCoordinateX(Robot robot)
        {
            if (robot.Coordinate.X == 0)
            {
                robot.Lost = true;
            }

            if (robot.Coordinate.X > 0)
            {
                robot.Coordinate.X--;
            }
        }

        private void UpCoordinateY(Robot robot)
        {
            if (robot.Coordinate.Y == 50)
            {
                robot.Lost = true;
            }

            if (robot.Coordinate.Y < 50)
            {
                robot.Coordinate.Y++;
            }
        }

        private void DownCoordinateY(Robot robot)
        {
            if (robot.Coordinate.Y == 0)
            {
                robot.Lost = true;
            }

            if (robot.Coordinate.Y > 0)
            {
                robot.Coordinate.Y--;
            }
        }

        private bool CompareCoordinates(Coordinates coordinate, List<Coordinates> lostRobots)
        {
            bool equalsCoordinates = false;

            foreach (Coordinates c in lostRobots)
            {
                if (coordinate.X == c.X
                    && coordinate.Y == c.Y
                    && coordinate.Orientation == c.Orientation)
                {
                    equalsCoordinates = true;
                }
            }

            return equalsCoordinates;
        }
    }
}