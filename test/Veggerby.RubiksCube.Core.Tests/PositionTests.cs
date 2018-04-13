using System;
using Shouldly;
using Xunit;

namespace Veggerby.RubiksCube.Core.Tests
{
    public class PositionTests
    {
        [Fact]
        public void Should_create_position()
        {
            // arrange

            // act
            var actual = new Position(0, 1, -1);

            // assert
            actual.X.ShouldBe(0);
            actual.Y.ShouldBe(1);
            actual.Z.ShouldBe(-1);
        }

        [Theory]
        [InlineData(2, 0, 0, "x")]
        [InlineData(0, 3, 0, "y")]
        [InlineData(0, 0, -2, "z")]
        [InlineData(2, 2, -2, "x")]
        public void Should_throw_argument_exception(int x, int y, int z, string param)
        {
            // arrange

            // act
            // assert
            var actual = Should.Throw<ArgumentException>(() => new Position(x, y, z));

            actual.ParamName.ShouldBe(param);
        }
    }
}
