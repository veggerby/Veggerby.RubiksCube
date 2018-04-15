using System;
using System.Linq;
using Veggerby.RubiksCube.Core;

namespace Veggerby.RubiksCube
{
    class Program
    {
        static void Main(string[] args)
        {
            var cube = Cube.Initialize();

            var printer = new CubePrinterSmall();

            var rotated = cube.Scramble(10);

            System.Console.WriteLine(string.Join("-", rotated.Rotations.Select(x => x.Id)));

            printer.Print(rotated);

            System.Console.WriteLine(string.Join("-", rotated.Reverse.Select(x => x.Id)));
        }
    }
}
