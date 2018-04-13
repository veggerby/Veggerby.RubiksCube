using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public class Cube
    {
        public IEnumerable<PiecePosition> Positions { get; }

        public Side GetSide(Direction direction)
        {
            if (direction.X != 0)
            {
                return new Side(direction, Positions.Where(x => x.Position.X == direction.X).ToList());
            }

            if (direction.Y != 0)
            {
                return new Side(direction, Positions.Where(x => x.Position.Y == direction.Y).ToList());
            }

            return new Side(direction, Positions.Where(x => x.Position.Z == direction.Z).ToList());
        }

        internal Cube(IEnumerable<PiecePosition> positions)
        {
            if (positions == null || !positions.Any())
            {
                throw new ArgumentException(nameof(positions));
            }

            Positions = positions.ToList();            
        }

        public PiecePosition GetPiece(Position position)
        {
            return Positions.SingleOrDefault(x => x.Position.Equals(position));
        }

        public Cube Rotate(UnitRotation rotation)
        {
            var side = GetSide(rotation.Direction);
            var pieces = side.Pieces;
            var others = Positions.Except(pieces);
            var rotated = pieces.Select(x => x.Rotate(rotation));
            return new Cube(rotated.Concat(others));
        }

        public static Cube Initialize()
        {
            var builder = new CubeBuilder();
            return builder.Build();
        }

        public Cube Scramble(int iterations = 200)
        {
            var cube = this;

            var rotations = new[] 
            {
                Rotation.Back,
                Rotation.BackInverse,
                Rotation.Down,
                Rotation.DownInverse,
                Rotation.Front,
                Rotation.FrontInverse,
                Rotation.Left,
                Rotation.LeftInverse,
                Rotation.Right,
                Rotation.RightInverse,
                Rotation.Up,
                Rotation.UpInverse,
            };

            var rnd = new Random();

            while (iterations > 0)
            {
                var rotation = rotations[rnd.Next(12)];
                cube = cube.Rotate(rotation);
                iterations--;
            }

            return cube;
        }
    }
}