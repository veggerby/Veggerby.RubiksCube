using Veggerby.Algorithm.LinearAlgebra;

namespace Veggerby.RubiksCube.Core
{
    public class UnitRotation : Rotation
    {
        public Direction Direction { get; }

        internal UnitRotation(Direction direction, Matrix rotation) : base(rotation)
        {
            Direction = direction;
        }
    }
}