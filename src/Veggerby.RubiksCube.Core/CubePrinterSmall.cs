using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public class CubePrinterSmall
    {
        private static IDictionary<Color, Tuple<ConsoleColor, ConsoleColor>> _colorMap = new Dictionary<Color, Tuple<ConsoleColor, ConsoleColor>> 
        {
            { Color.None, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.Black, ConsoleColor.Gray) },
            { Color.White, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.White, ConsoleColor.Black) },
            { Color.Orange, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkMagenta, ConsoleColor.White) },
            { Color.Green, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkGreen, ConsoleColor.White) },
            { Color.Yellow, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.Yellow, ConsoleColor.Black) },
            { Color.Red, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkRed, ConsoleColor.White) },
            { Color.Blue, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkBlue, ConsoleColor.White) }
        };

        private static List<Tuple<Position, Direction, int, int>> _coords = new List<Tuple<Position, Direction, int, int>>
        {
            // back
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1, -1), Side.Back, 15, 0) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0, -1), Side.Back, 20, 0) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1, -1), Side.Back, 25, 0) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  0), Side.Back, 15, 3) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0,  0), Side.Back, 20, 3) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  0), Side.Back, 25, 3) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  1), Side.Back, 15, 6) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0,  1), Side.Back, 20, 6) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  1), Side.Back, 25, 6) },

            // left
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1, -1), Side.Left, 0, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  0), Side.Left, 5, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  1), Side.Left, 10, 9) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1, -1), Side.Left, 0, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1,  0), Side.Left, 5, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1,  1), Side.Left, 10, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1, -1), Side.Left, 0, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  0), Side.Left, 5, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  1), Side.Left, 10, 15) },

            // up
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  1), Side.Up, 15, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0,  1), Side.Up, 20, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  1), Side.Up, 25, 9) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1,  1), Side.Up, 15, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  0,  1), Side.Up, 20, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1,  1), Side.Up, 25, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  1), Side.Up, 15, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0,  1), Side.Up, 20, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  1), Side.Up, 25, 15) },

            // right
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  1), Side.Right, 30, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  0), Side.Right, 35, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1, -1), Side.Right, 40, 9) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1,  1), Side.Right, 30, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1,  0), Side.Right, 35, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1, -1), Side.Right, 40, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  1), Side.Right, 30, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  0), Side.Right, 35, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1, -1), Side.Right, 40, 15) },

            // down
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1, -1), Side.Down, 45, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0, -1), Side.Down, 50, 9) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1, -1), Side.Down, 55, 9) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1, -1), Side.Down, 45, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  0, -1), Side.Down, 50, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1, -1), Side.Down, 55, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1, -1), Side.Down, 45, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0, -1), Side.Down, 50, 15) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1, -1), Side.Down, 55, 15) },

            // front
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  1), Side.Front, 15, 18) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0,  1), Side.Front, 20, 18) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  1), Side.Front, 25, 18) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  0), Side.Front, 15, 21) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0,  0), Side.Front, 20, 21) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  0), Side.Front, 25, 21) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1, -1), Side.Front, 15, 24) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0, -1), Side.Front, 20, 24) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1, -1), Side.Front, 25, 24) },
        };

        private void PrintPiece(int x, int y, Position position, Color color)
        {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;

            y = top + y;

            var c = _colorMap[color];
            var bg = c.Item1;
            var fg = c.Item2;

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("+----+");

            Console.SetCursorPosition(x, y+1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
            Console.Write("    ");                
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                

            Console.SetCursorPosition(x, y+2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
            Console.Write("    ");                
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                

            Console.SetCursorPosition(x, y+3);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("+----+");

            Console.SetCursorPosition(left, top);
        }

        public void Print(Cube cube)
        {
            var max = _coords.Max(x => x.Item4) + 4;

            for (int i = 0; i < max; i ++)
            {
                Console.WriteLine();
            }

            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            
            Console.SetCursorPosition(left, top - max);

            foreach(var coord in _coords)
            {
                var piece = cube.GetPiece(coord.Item1);
                PrintPiece(coord.Item3, coord.Item4, piece.Position, piece.GetFace(coord.Item2));
            }

            Console.SetCursorPosition(left, top);
        }
    }
}