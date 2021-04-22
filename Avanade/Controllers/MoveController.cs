﻿using Avanade.Models;
using System;
using System.Collections.Generic;

namespace Avanade.Controllers
{
    class MoveController
    {
        public void Start(List<Robot> robots, List<Coordinates> lostRobots)
        {
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
                    EjecuteOrder(order, robot, lostRobots);
                    RobotPosition(robot);
                }
            }
            RobotPosition(robot);
        }

        private void RobotPosition(Robot robot)
        {
            string orientation = string.Empty;
            string text = string.Empty;

            switch (robot.Orientation)
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
                text += "El robot se encuentra en las coordenadas (";
                text += robot.Coordinate.X;
                text += ",";
                text += robot.Coordinate.Y;
                text += "), esta orientado hacia el ";
                text += orientation;
            }
            else
            {
                text += "El robot esta perdido, sus ultimas coordenadas fueron (";
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
                    break;
                default:
                    Console.WriteLine("Ups algo fue mal");
                    break;
            }
        }

        private void AvanceToFront(Robot robot, List<Coordinates> lostRobots)
        {
            switch (robot.Orientation)
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
                switch (robot.Orientation)
                {
                    case "n":
                        robot.Orientation = "e";
                        break;
                    case "e":
                        robot.Orientation = "s";
                        break;
                    case "s":
                        robot.Orientation = "w";
                        break;
                    case "w":
                        robot.Orientation = "n";
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
                switch (robot.Orientation)
                {
                    case "n":
                        robot.Orientation = "w";
                        break;
                    case "e":
                        robot.Orientation = "n";
                        break;
                    case "s":
                        robot.Orientation = "e";
                        break;
                    case "w":
                        robot.Orientation = "s";
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
                if (coordinate.X == c.X && coordinate.Y == c.Y)
                {
                    equalsCoordinates = true;
                }
            }

            return equalsCoordinates;
        }
    }
}