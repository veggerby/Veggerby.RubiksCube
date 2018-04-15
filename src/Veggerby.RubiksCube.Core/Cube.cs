using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public class Cube
    {
        private readonly IEnumerable<UnitRotation> _rotations = Enumerable.Empty<UnitRotation>();
        public IEnumerable<PiecePosition> Positions { get; }

        public IEnumerable<UnitRotation> Rotations => _rotations;

        public IEnumerable<UnitRotation> Reverse => _rotations.Reverse().Select(x => x.Reverse).ToList();

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

        private Cube(IEnumerable<PiecePosition> positions, IEnumerable<UnitRotation> rotations) : this(positions)
        {
            _rotations = (rotations ?? Enumerable.Empty<UnitRotation>()).ToList();
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
            return new Cube(rotated.Concat(others), Rotations.Concat(new [] { rotation }));
        }

        public static Cube Initialize()
        {
            var builder = new CubeBuilder();
            return builder.Build();
        }

        public Cube Scramble(int iterations = 200)
        {
            var cube = this;
            UnitRotation previous = null;

            while (iterations > 0)
            {
                var rotation = Rotation.AllRotations.Values.Where(x => !x.Reverse.Equals(previous)).ToList().SelectRandom();
                cube = cube.Rotate(rotation);
                previous = rotation;
                iterations--;
            }

            return cube;
        }
    }
}