using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public class Side
    {
        public static Direction Up = new Direction("U", 0, 0, 1);
        public static Direction Down = new Direction("D", 0, 0, -1);
        public static Direction Left = new Direction("L", 0, -1, 0);
        public static Direction Right = new Direction("R", 0, 1, 0);
        public static Direction Front = new Direction("F", 1, 0, 0);
        public static Direction Back = new Direction("B", -1, 0, 0);

        public Direction Direction { get; }

        public IEnumerable<PiecePosition> Pieces { get; }

        public PiecePosition GetPiece(Position position)
        {
            return Pieces.SingleOrDefault(x => x.Position.Equals(position));
        }

        public Side(Direction direction, IEnumerable<PiecePosition> pieces)
        {

            Direction = direction;
            Pieces = pieces;
        }
    }
}