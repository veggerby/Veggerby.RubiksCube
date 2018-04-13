using System;
using Shouldly;
using Xunit;

namespace Veggerby.RubiksCube.Core.Tests
{
    public class RotationTests
    {
        [Theory]
        [InlineData(1, 0, 0, 0, 0, 1)]
        [InlineData(0, -1, 1, -1, -1, 0)]
        [InlineData(1, -1, 1, -1, -1, 1)]
        public void Should_rotate_direction_R(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.Right;

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, -1)]
        [InlineData(0, -1, 1, 1, -1, 0)]
        [InlineData(1, -1, 1, 1, -1, -1)]
        public void Should_rotate_direction_RI(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.RightInverse; 

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, -1)]
        [InlineData(0, -1, 1, 1, -1, 0)]
        [InlineData(1, -1, 1, 1, -1, -1)]
        public void Should_rotate_direction_L(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.Left;

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, 1)]
        [InlineData(0, -1, 1, -1, -1, 0)]
        [InlineData(1, -1, 1, -1, -1, 1)]
        public void Should_rotate_direction_LI(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.LeftInverse; 

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 0, 0)]
        [InlineData(0, -1, 1, 0, -1, -1)]
        [InlineData(1, -1, 1, 1, -1, -1)]
        public void Should_rotate_direction_B(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.Back;

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 0, 0)]
        [InlineData(0, -1, 1, 0, 1, 1)]
        [InlineData(1, -1, 1, 1, 1, 1)]
        public void Should_rotate_direction_BI(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.BackInverse; 

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }
        
        [Theory]
        [InlineData(1, 0, 0, 0, 1, 0)]
        [InlineData(0, -1, 1, 1, 0, 1)]
        [InlineData(1, -1, 1, 1, 1, 1)]
        public void Should_rotate_direction_D(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.Down;

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, -1, 0)]
        [InlineData(0, -1, 1, -1, 0, 1)]
        [InlineData(1, -1, 1, -1, -1, 1)]
        public void Should_rotate_direction_DI(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.DownInverse; 

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, -1, 0)]
        [InlineData(0, -1, 1, -1, 0, 1)]
        [InlineData(1, -1, 1, -1, -1, 1)]
        public void Should_rotate_direction_U(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.Up; // negative rotation around Z axis

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        
        [Theory]
        [InlineData(1, 0, 0, 1, 0, 0)]
        [InlineData(0, -1, 1, 0, 1, 1)]
        [InlineData(1, -1, 1, 1, 1, 1)]
        public void Should_rotate_direction_F(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.Front;

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 0, 0)]
        [InlineData(0, -1, 1, 0, -1, -1)]
        [InlineData(1, -1, 1, 1, -1, -1)]
        public void Should_rotate_direction_FI(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.FrontInverse; 

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 1, 0)]
        [InlineData(0, -1, 1, 1, 0, 1)]
        [InlineData(1, -1, 1, 1, 1, 1)]
        public void Should_rotate_direction_UI(int x, int y, int z, int expectedX, int expectedY, int expectedZ)
        {
            // arrange
            var rotation = Rotation.UpInverse; // positive rotation around Z axis

            var position = new Position(x, y, z);
            var expected = new Position(expectedX, expectedY, expectedZ);

            // act
            var actual = rotation.Rotate(position);

            // assert

            actual.ShouldBe(expected);
        }
    }
}
