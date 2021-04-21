using Avanade.Controllers;
using System;

namespace Avanade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido a Robots Marcianos!");
            AplicationController aplication = new();
            aplication.MenuPrincipal();
        }
    }
}