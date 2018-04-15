using Veggerby.Algorithm.LinearAlgebra;

namespace Veggerby.RubiksCube.Core
{
    public class UnitRotation : Rotation
    {
        public string Id { get; }
        public Direction Direction { get; }

        private string ReverseId
        {
            get
            {
                if (Id.EndsWith("I"))
                {
                    return Id.TrimEnd('I');
                }

                return $"{Id}I";
            }
        }

        public UnitRotation Reverse => Rotation.AllRotations[ReverseId];

        internal UnitRotation(string id, Direction direction, Matrix rotation) : base(rotation)
        {
            Id = id;
            Direction = direction;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UnitRotation);
        }

        public bool Equals(UnitRotation other)
        {
            if (other == null)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}