using System;

namespace Veggerby.RubiksCube.Core
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Position(int x, int y, int z)
        {
            if (x < -1 || x > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y < -1 || y > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            if (z < -1 || z > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(z));
            }

            if (x == 0 && y == 0 && z == 0)
            {
                throw new Exception("Inner piece position is invalid (0, 0, 0)");
            }

            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        public bool Equals(Position other)
        {
            if (other == null)
            {
                return false;
            }

            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode*397) ^ Y.GetHashCode();
                hashCode = (hashCode*397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
    }
}