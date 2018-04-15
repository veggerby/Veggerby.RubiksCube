using System;
using System.Collections.Generic;
using System.Linq;

namespace Veggerby.RubiksCube.Core
{
    public abstract class Piece
    {
        public int Id { get; }

        public IEnumerable<Face> Faces { get; }

        protected Piece(int id, params Face[] faces)
        {
            if (faces.Distinct().Count() <= 0 || faces.Distinct().Count() > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(faces));
            }

            if (faces.Any(x => x.Color == Color.White) && faces.Any(x => x.Color == Color.Yellow))
            {
                throw new ArgumentOutOfRangeException(nameof(faces), "No side can have White and Yellow at the same time");
            }

            if (faces.Any(x => x.Color == Color.Orange) && faces.Any(x => x.Color == Color.Red))
            {
                throw new ArgumentOutOfRangeException(nameof(faces), "No side can have Orange and Red at the same time");
            }

            if (faces.Any(x => x.Color == Color.Green) && faces.Any(x => x.Color == Color.Blue))
            {
                throw new ArgumentOutOfRangeException(nameof(faces), "No side can have Green and Blue at the same time");
            }

            Id = id;
            Faces = faces;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Piece);
        }

        public bool Equals(Piece other)
        {
            if (other == null)
            {
                return false;
            }

            return Id.Equals(other.Id) && Faces.SequenceEqual(other.Faces);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Faces.Aggregate(Id.GetHashCode(), (seed, face) => (seed * 397) ^ face.GetHashCode());
            }
        }

        public override string ToString()
        {
            return $"#{Id}";
        }
    }
}