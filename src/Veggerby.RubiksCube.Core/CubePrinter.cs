using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public class CubePrinter
    {
        private static IDictionary<Color, Tuple<ConsoleColor, ConsoleColor>> _colorMap = new Dictionary<Color, Tuple<ConsoleColor, ConsoleColor>> 
        {
            { Color.None, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.Black, ConsoleColor.Gray) },
            { Color.White, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.White, ConsoleColor.Black) },
            { Color.Orange, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkMagenta, ConsoleColor.White) },
            { Color.Green, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.DarkGreen, ConsoleColor.White) },
            { Color.Yellow, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.Yellow, ConsoleColor.Black) },
            { Color.Red, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.Red, ConsoleColor.White) },
            { Color.Blue, new Tuple<ConsoleColor, ConsoleColor>(ConsoleColor.Blue, ConsoleColor.White) }
        };

        private static List<Tuple<Position, Direction, int, int>> _coords = new List<Tuple<Position, Direction, int, int>>
        {
            // back
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1, -1), Side.Back, 33, 0) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0, -1), Side.Back, 44, 0) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1, -1), Side.Back, 55, 0) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  0), Side.Back, 33, 4) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0,  0), Side.Back, 44, 4) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  0), Side.Back, 55, 4) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  1), Side.Back, 33, 8) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0,  1), Side.Back, 44, 8) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  1), Side.Back, 55, 8) },

            // left
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1, -1), Side.Left, 0, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  0), Side.Left, 11, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  1), Side.Left, 22, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1, -1), Side.Left, 0, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1,  0), Side.Left, 11, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1,  1), Side.Left, 22, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1, -1), Side.Left, 0, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  0), Side.Left, 11, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  1), Side.Left, 22, 20) },

            // up
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1,  1), Side.Up, 33, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0,  1), Side.Up, 44, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  1), Side.Up, 55, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1,  1), Side.Up, 33, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  0,  1), Side.Up, 44, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1,  1), Side.Up, 55, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  1), Side.Up, 33, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0,  1), Side.Up, 44, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  1), Side.Up, 55, 20) },

            // right
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  1), Side.Right, 66, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1,  0), Side.Right, 77, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1, -1), Side.Right, 88, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1,  1), Side.Right, 66, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1,  0), Side.Right, 77, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1, -1), Side.Right, 88, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  1), Side.Right, 66, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  0), Side.Right, 77, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1, -1), Side.Right, 88, 20) },

            // down
            { new Tuple<Position, Direction, int, int>(new Position(-1,  1, -1), Side.Down, 99, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1,  0, -1), Side.Down, 110, 12) },
            { new Tuple<Position, Direction, int, int>(new Position(-1, -1, -1), Side.Down, 121, 12) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  1, -1), Side.Down, 99, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0,  0, -1), Side.Down, 110, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 0, -1, -1), Side.Down, 121, 16) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1, -1), Side.Down, 99, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0, -1), Side.Down, 110, 20) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1, -1), Side.Down, 121, 20) },

            // front
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  1), Side.Front, 33, 24) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0,  1), Side.Front, 44, 24) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  1), Side.Front, 55, 24) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1,  0), Side.Front, 33, 28) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0,  0), Side.Front, 44, 28) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1,  0), Side.Front, 55, 28) },
            { new Tuple<Position, Direction, int, int>(new Position( 1, -1, -1), Side.Front, 33, 32) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  0, -1), Side.Front, 44, 32) },
            { new Tuple<Position, Direction, int, int>(new Position( 1,  1, -1), Side.Front, 55, 32) },
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
            Console.Write("+----------+");

            Console.SetCursorPosition(x, y+1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
            Console.Write("          ");                
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                

            Console.SetCursorPosition(x, y+2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
            Console.Write($" {position.X,2},{position.Y,2},{position.Z,2} ");                
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                

            Console.SetCursorPosition(x, y+3);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
            Console.Write("          ");                
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("|");                

            Console.SetCursorPosition(x, y+4);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("+----------+");     

            Console.SetCursorPosition(left, top);
        }

        public void Print(Cube cube)
        {
            var max = _coords.Max(x => x.Item4) + 5;

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