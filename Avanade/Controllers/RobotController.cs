using Avanade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.Controllers
{
    class RobotController
    {
        #region const

        private readonly int MaxSecuencyLenght = 100;
        private readonly List<string> ValidOrientationList = new() { "n", "s", "w", "e" };
        private readonly List<char> ValidSecuencyList = new() { 'l', 'r', 'f' };
        private readonly List<string> YesOrNoList = new() { "y", "n" };
        private readonly List<char> numberList = new() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        #endregion

        #region CRUD

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

        public void Remove(List<Robot> robots)
        {
            Console.Clear();
            Console.WriteLine("Introduzca el id del robot a eliminar");
            Robot robot = FindRobot(robots);

            if (robot != null)
            {
                Console.WriteLine("Se ha eliminado el robot con éxito");
            }
        }

        public void Edit(List<Robot> robots)
        {
            Robot robot = FindRobot(robots);
            if (robot != null)
            {
                Console.WriteLine("¿Desea ver los datos del robot antes de editarlos? (escriba \"Y\" or \"N\" )");
                string res = Console.ReadLine().ToLower();
                while (!YesOrNoList.Contains(res))
                {
                    Console.Clear();
                    Console.WriteLine("¿Desea ver los datos del robot antes de editarlos? (escriba \"Y\" or \"N\" )");
                    res = Console.ReadLine().ToLower();
                }

                if (res.Equals("y"))
                {
                    RobotsList(new List<Robot>() { robot });
                    Console.WriteLine("Pulse cualquier carácter para continuar la edición del robot");
                    Console.ReadKey();
                }

                if (!robot.Lost)
                {
                    WriteCoordinates(robot);
                    WriteSecuency(robot);
                    WriteOrientation(robot);
                }
                else
                {
                    Console.WriteLine("No se pueden editar los datos de un robot perdido");
                }
            }

        }

        #endregion

        #region suport methods
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
                     ", sus coordenadas son desconocidas, el robot se ha perdido, " +
                     "sus ultimas coordenadas conocidas fueron: (" + robot.Coordinate.X
                     + "," + robot.Coordinate.Y + "), " + orientacion);
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
            WriteCoordinateX(robot);
            WriteCoordinateY(robot);
        }

        public void WriteCoordinateX(Robot robot)
        {
            Console.Clear();
            Console.WriteLine("Introduzca coordenada X (deben ser un números entre 0 y 50)");
            string x = Console.ReadLine();

            while (!CoordinateValidate(x))
            {
                Console.Clear();
                Console.WriteLine("Introduzca coordenada X (deben ser un números entre 0 y 50)");
                x = Console.ReadLine();
            }

            robot.Coordinate.X = int.Parse(x);
        }

        public void WriteCoordinateY(Robot robot)
        {
            Console.Clear();
            Console.WriteLine("Introduzca coordenada Y (deben ser un números entre 0 y 50)");
            string y = Console.ReadLine();

            while (!CoordinateValidate(y))
            {
                Console.Clear();
                Console.WriteLine("Introduzca coordenada Y (deben ser un números entre 0 y 50)");
                y = Console.ReadLine();
            }

            robot.Coordinate.Y = int.Parse(y);
        }

        public void WriteSecuency(Robot robot)
        {
            Console.Clear();

            Console.WriteLine("Introduzca la secuencia " +
                "(la secuencia es un string formado unicamente por" +
                " las letras \"L \"  \"R \"  \"F \", debe ser menor a 100 caracteres");

            string secuency = Console.ReadLine().ToLower();

            while (!ValidSecuency(secuency))
            {
                Console.Clear();
                Console.WriteLine("Introduzca la secuencia " +
                "(la secuencia es un string formado unicamente por" +
                " las letras \"L \"  \"R \"  \"F \", debe ser menor a 100 caracteres");

                secuency = Console.ReadLine().ToLower();
            }

            robot.Secuency = secuency;
        }

        public void WriteOrientation(Robot robot)
        {
            Console.Clear();
            Console.WriteLine("Introduzca la Orientación " +
                "(La orientación esta formada por 1 carácter \"N\"  \"S\"  \"E\"  \"W\" )");

            string orientation = Console.ReadLine().ToLower();
            while (!ValidOrientation(orientation))
            {
                Console.Clear();
                Console.WriteLine("Introduzca la Orientación " +
                "(La orientación esta formada por 1 carácter \"N\"  \"S\"  \"E\"  \"W\" )");
                orientation = Console.ReadLine().ToLower();
            }

            robot.Orientation = orientation;
        }

        public Robot FindRobot(List<Robot> robots)
        {
            Console.Clear();

            Console.WriteLine("Introduzca el id del robot");
            string idString = Console.ReadLine();
            while (!IsNumber(idString))
            {
                Console.Clear();
                Console.WriteLine("Introduzca el id del robot (debe ser un número)");
                idString = Console.ReadLine();
            }

            int id = int.Parse(idString);

            Robot robot = robots.Find(x => x.Id == id);
            if (robot == null)
            {
                Console.WriteLine("No existe ningún robot con ese id, " +
                    "para ver los id de los robots existentes vaya a listado de robots");
            }

            return robot;
        }

        #endregion

        #region methods to validations

        public bool CoordinateValidate(string number)
        {
            bool isValidCoordinate = true;

            if (!IsNumber(number))
            {
                isValidCoordinate = false;
            }

            if (isValidCoordinate && int.Parse(number) < 0)
            {
                isValidCoordinate = false;
            }

            if (isValidCoordinate && int.Parse(number) > 50)
            {
                isValidCoordinate = false;

            }

            return isValidCoordinate;
        }

        public bool IsNumber(string number)
        {
            bool isNumber = true;

            try
            {
                int.Parse(number);
            }
            catch (Exception)
            {
                isNumber = false;
            }

            return isNumber;
        }

        public bool ValidOrientation(string orientation)
        {
            bool isValidOrientation = true;

            if (!ValidOrientationList.Contains(orientation))
            {
                isValidOrientation = false;
            }

            return isValidOrientation;
        }

        public bool ValidSecuency(string secuency)
        {
            bool isValidSecuency = true;

            if (secuency.Length > MaxSecuencyLenght)
            {
                isValidSecuency = false;
            }

            foreach (Char character in secuency)
            {
                if (!ValidSecuencyList.Contains(character))
                {
                    isValidSecuency = false;
                }
            }

            return isValidSecuency;
        }
        #endregion

    }
}