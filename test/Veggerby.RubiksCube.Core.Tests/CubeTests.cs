using System;
using Shouldly;
using Xunit;

namespace Veggerby.RubiksCube.Core.Tests
{
    public class CubeTests
    {
        [Fact]
        public void Should_rotate_R()
        {
            // arrange
            var cube = Cube.Initialize();

            // act
            var actual = cube.Rotate(Rotation.Right);

            // assert
            var corner = actual.GetPiece(new Position(-1, 1, 1));
            corner.GetFace(Side.Up).ShouldBe(Color.Green);
            corner.GetFace(Side.Right).ShouldBe(Color.Red);
            corner.GetFace(Side.Back).ShouldBe(Color.White);
            corner.GetFace(Side.Front).ShouldBe(Color.None);
            corner.GetFace(Side.Left).ShouldBe(Color.None);
            corner.GetFace(Side.Down).ShouldBe(Color.None);
        }

        [Fact]
        public void Should_rotate_R_and_U()
        {
            // arrange
            var cube = Cube.Initialize();

            // act
            var actual = cube.Rotate(Rotation.Right).Rotate(Rotation.Up);

            // assert
            var corner = actual.GetPiece(new Position(1, 1, 1));
            corner.GetFace(Side.Up).ShouldBe(Color.Green);
            corner.GetFace(Side.Right).ShouldBe(Color.White);
            corner.GetFace(Side.Back).ShouldBe(Color.None);
            corner.GetFace(Side.Front).ShouldBe(Color.Red);
            corner.GetFace(Side.Left).ShouldBe(Color.None);
            corner.GetFace(Side.Down).ShouldBe(Color.None);

            var center = actual.GetPiece(new Position(0, 1, 0));
            center.GetFace(Side.Up).ShouldBe(Color.None);
            center.GetFace(Side.Right).ShouldBe(Color.Red);
            center.GetFace(Side.Back).ShouldBe(Color.None);
            center.GetFace(Side.Front).ShouldBe(Color.None);
            center.GetFace(Side.Left).ShouldBe(Color.None);
            center.GetFace(Side.Down).ShouldBe(Color.None);

            var edge1 = actual.GetPiece(new Position(1, 0, 1));
            edge1.GetFace(Side.Up).ShouldBe(Color.Green);
            edge1.GetFace(Side.Right).ShouldBe(Color.None);
            edge1.GetFace(Side.Back).ShouldBe(Color.None);
            edge1.GetFace(Side.Front).ShouldBe(Color.Red);
            edge1.GetFace(Side.Left).ShouldBe(Color.None);
            edge1.GetFace(Side.Down).ShouldBe(Color.None);

            var edge2 = actual.GetPiece(new Position(1, 1, 0));
            edge2.GetFace(Side.Up).ShouldBe(Color.None);
            edge2.GetFace(Side.Right).ShouldBe(Color.Red);
            edge2.GetFace(Side.Back).ShouldBe(Color.None);
            edge2.GetFace(Side.Front).ShouldBe(Color.Yellow);
            edge2.GetFace(Side.Left).ShouldBe(Color.None);
            edge2.GetFace(Side.Down).ShouldBe(Color.None);
        }
    }
}
