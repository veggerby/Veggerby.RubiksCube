namespace Veggerby.RubiksCube.Core
{
    public class Face
    {
        public Direction Direction { get; }
        public Color Color { get; }

        public Face(Direction direction, Color color)
        {
            Direction = direction;
            Color = color;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Face);
        }

        public bool Equals(Face other)
        {
            if (other == null)
            {
                return false;
            }

            return Direction.Equals(other.Direction) && Color.Equals(other.Color);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Direction.GetHashCode();
                hashCode = (hashCode*397) ^ Color.GetHashCode();
                return hashCode;
            }
        }
    }
}