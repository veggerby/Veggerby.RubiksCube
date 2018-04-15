using System.Linq;
using Veggerby.Algorithm.LinearAlgebra;

namespace Veggerby.RubiksCube.Core
{
    public class PiecePosition
    {
        public Piece Piece { get; }
        private Position _initialPosition { get; }
        private Rotation _rotation { get; }

        public Position Position => _rotation.Rotate(_initialPosition);

        public PiecePosition(Position position, Piece piece)
        {
            Piece = piece;
            _initialPosition = position;
            _rotation = Rotation.Empty;
        }

        private PiecePosition(Position position, Piece piece, Rotation rotation)
        {
            Piece = piece;
            _initialPosition = position;
            _rotation = rotation;
        }

        public Color GetFace(Direction direction)
        {
            var face = Piece
                .Faces
                .Select(x => new { Color = x.Color, Direction = _rotation.Rotate(x.Direction) })
                .FirstOrDefault(x => x.Direction.Equals(direction));

            return face?.Color ?? Color.None;
        }

        public PiecePosition Rotate(Rotation rotation)
        {
            var newRotation = rotation.Rotate(_rotation);
            return new PiecePosition(_initialPosition, Piece, newRotation);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PiecePosition);
        }

        public bool Equals(PiecePosition other)
        {
            if (other == null)
            {
                return false;
            }

            return Piece.Equals(other.Piece) && Position.Equals(other.Position);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Piece.GetHashCode();
                hashCode = (hashCode*397) ^ Position.GetHashCode();
                return hashCode;
            }
        }
    }
}