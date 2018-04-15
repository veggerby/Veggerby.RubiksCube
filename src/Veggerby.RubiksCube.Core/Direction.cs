using System;

namespace Veggerby.RubiksCube.Core
{
    public class Direction : Position
    {
        public string Id { get; }

        internal Direction(string id, int x, int y, int z) : base(x, y, z)
        {
            if (Math.Abs(x) + Math.Abs(y) + Math.Abs(z) != 1)
            {
                throw new Exception("Direction must be a unit vector");
            }

            Id = id;
        }
    }
}