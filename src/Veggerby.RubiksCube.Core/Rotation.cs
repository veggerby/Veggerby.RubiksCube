using System;
using Veggerby.Algorithm.LinearAlgebra;

namespace Veggerby.RubiksCube.Core
{
    public class Rotation
    {

        // cos pi/2 = 0
        // sin pi/2 = 1
        // rotation https://en.wikipedia.org/wiki/Rotation_matrix#In_three_dimensions

        private static double[,] RotateX = // x rotation
        {
            {  1,  0,  0 },
            {  0,  0, -1 },
            {  0,  1,  0 }
        };

        private static double[,] RotateInverseX = // inverse x rotation
        {
            {  1,  0,  0 },
            {  0,  0,  1 },
            {  0, -1,  0 }
        };

        private static double[,] RotateY = // y rotation
        {
            {  0,  0,  1 },
            {  0,  1,  0 },
            { -1,  0,  0 }
        };

        private static double[,] RotateInverseY = // inverse y rotation
        {
            {  0,  0, -1 },
            {  0,  1,  0 },
            {  1,  0,  0 }
        };

        private static double[,] RotateZ = // z rotation
        {
            {  0, -1,  0 },
            {  1,  0,  0 },
            {  0,  0,  1 }
        };

        private static double[,] RotateInverseZ = // inverse z rotation
        {
            {  0,  1,  0 },
            { -1,  0,  0 },
            {  0,  0,  1 }
        };

        public static UnitRotation Right = new UnitRotation(Side.Right, new Matrix(RotateInverseY));
        public static UnitRotation RightInverse = new UnitRotation(Side.Right, new Matrix(RotateY));
        public static UnitRotation Left = new UnitRotation(Side.Left, new Matrix(RotateY));
        public static UnitRotation LeftInverse = new UnitRotation(Side.Left, new Matrix(RotateInverseY));
        public static UnitRotation Back = new UnitRotation(Side.Back, new Matrix(RotateX));
        public static UnitRotation BackInverse = new UnitRotation(Side.Back, new Matrix(RotateInverseX));
        public static UnitRotation Down = new UnitRotation(Side.Down, new Matrix(RotateZ));
        public static UnitRotation DownInverse = new UnitRotation(Side.Down, new Matrix(RotateInverseZ));
        public static UnitRotation Front = new UnitRotation(Side.Front, new Matrix(RotateInverseX));
        public static UnitRotation FrontInverse = new UnitRotation(Side.Front, new Matrix(RotateX));
        public static UnitRotation Up = new UnitRotation(Side.Up, new Matrix(RotateInverseZ));
        public static UnitRotation UpInverse = new UnitRotation(Side.Up, new Matrix(RotateZ));

        public static Rotation Empty = new Rotation(Matrix.Identity(3));

        private Matrix _rotation { get; }

        protected Rotation(Matrix rotation)
        {
            if (rotation.RowCount != 3 || rotation.ColCount != 3)
            {
                throw new ArgumentException(nameof(rotation));
            }

            _rotation = rotation;
        }

        public Rotation Rotate(Rotation rotation)
        {
            return new Rotation(_rotation * rotation._rotation);
        }

        public Position Rotate(Position position)
        {
            var vector = new Vector(position.X, position.Y, position.Z);
            var rotated = _rotation * vector;
            return new Position((int)rotated[0], (int)rotated[1], (int)rotated[2]);
        }
    }
}