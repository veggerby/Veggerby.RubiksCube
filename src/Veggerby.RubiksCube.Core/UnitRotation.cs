using Veggerby.Algorithm.LinearAlgebra;

namespace Veggerby.RubiksCube.Core
{
    public class UnitRotation : Rotation
    {
        public string Id { get; }
        public Direction Direction { get; }

        internal UnitRotation(string id, Direction direction, Matrix rotation) : base(rotation)
        {
            Id = id;
            Direction = direction;
        }
    }
}