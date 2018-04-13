using System;
using Veggerby.RubiksCube.Core;

namespace Veggerby.RubiksCube
{
    class Program
    {
        static void Main(string[] args)
        {
            var cube = Cube.Initialize();

            var printer = new CubePrinterSmall();

            var rotated = cube.Scramble();

            printer.Print(rotated);            
        }
    }
}
