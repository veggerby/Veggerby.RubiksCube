using System.Collections.Generic;

namespace Veggerby.RubiksCube.Core
{
    public class CubeBuilder
    {
        public Cube Build()
        {
            var whiteUp = new Face(Side.Up, Color.White);
            var yellowDown = new Face(Side.Down, Color.Yellow);
            var orangeLeft = new Face(Side.Left, Color.Orange);
            var redRight = new Face(Side.Right, Color.Red);
            var greenFront = new Face(Side.Front, Color.Green);
            var blueBack = new Face(Side.Back, Color.Blue);

            // create center pieces
            var white = new CenterPiece(0x1, whiteUp);
            var yellow = new CenterPiece(0x2, yellowDown);
            var orange = new CenterPiece(0x3, orangeLeft);
            var red = new CenterPiece(0x4, redRight);
            var green = new CenterPiece(0x5, greenFront);
            var blue = new CenterPiece(0x6, blueBack);

            // create corner pieces (x/y/z side)
            var greenOrangeWhite = new CornerPiece(0x10, greenFront, orangeLeft, whiteUp);
            var blueOrangeWhite = new CornerPiece(0x11, blueBack, orangeLeft, whiteUp);
            var greenRedWhite = new CornerPiece(0x12, greenFront, redRight, whiteUp);
            var blueRedWhite = new CornerPiece(0x13, blueBack, redRight, whiteUp);
            var greenOrangeYellow = new CornerPiece(0x14, greenFront, orangeLeft, yellowDown);
            var blueOrangeYellow = new CornerPiece(0x15, blueBack, orangeLeft, yellowDown);
            var greenRedYellow = new CornerPiece(0x16, greenFront, redRight, yellowDown);
            var blueRedYellow = new CornerPiece(0x17, blueBack, redRight, yellowDown);

            // create edge pieces (top layer)
            var orangeWhite = new EdgePiece(0x20, orangeLeft, whiteUp);
            var greenWhite = new EdgePiece(0x21, greenFront, whiteUp);
            var redWhite = new EdgePiece(0x22, redRight, whiteUp);
            var blueWhite = new EdgePiece(0x23, blueBack, whiteUp);

            // create edge pieces (middle layer)
            var orangeGreen = new EdgePiece(0x24, orangeLeft, greenFront);
            var greenRed = new EdgePiece(0x25, greenFront, redRight);
            var redBlue = new EdgePiece(0x26, redRight, blueBack);
            var blueOrange = new EdgePiece(0x27, blueBack, orangeLeft);

            // create edge pieces (bottom layer)
            var orangeYellow = new EdgePiece(0x28, orangeLeft, yellowDown);
            var greenYellow = new EdgePiece(0x29, greenFront, yellowDown);
            var redYellow = new EdgePiece(0x2A, redRight, yellowDown);
            var blueYellow = new EdgePiece(0x2B, blueBack, yellowDown);

            var positions = new List<PiecePosition>
            {
                // top layer
                new PiecePosition(new Position(1, -1, 1), greenOrangeWhite),
                new PiecePosition(new Position(1, 0, 1), greenWhite),
                new PiecePosition(new Position(1, 1, 1), greenRedWhite),

                new PiecePosition(new Position(0, -1, 1), orangeWhite),
                new PiecePosition(new Position(0, 0, 1), white),
                new PiecePosition(new Position(0, 1, 1), redWhite),

                new PiecePosition(new Position(-1, -1, 1), blueOrangeWhite),
                new PiecePosition(new Position(-1, 0, 1), blueWhite),
                new PiecePosition(new Position(-1, 1, 1), blueRedWhite),

                // middle layernew Position(
                new PiecePosition(new Position(1, -1, 0), orangeGreen),
                new PiecePosition(new Position(1, 0, 0), green),
                new PiecePosition(new Position(1, 1, 0), greenRed),

                new PiecePosition(new Position(0, -1, 0), orange),
                // inner piecenew Position(
                new PiecePosition(new Position(0, 1, 0), red),

                new PiecePosition(new Position(-1, -1, 0), blueOrange),
                new PiecePosition(new Position(-1, 0, 0), blue),
                new PiecePosition(new Position(-1, 1, 0), redBlue),

                // bottom layernew Position(
                new PiecePosition(new Position(1, -1, -1), greenOrangeYellow),
                new PiecePosition(new Position(1, 0, -1), greenYellow),
                new PiecePosition(new Position(1, 1, -1), greenRedYellow),

                new PiecePosition(new Position(0, -1, -1), orangeYellow),
                new PiecePosition(new Position(0, 0, -1), yellow),
                new PiecePosition(new Position(0, 1, -1), redYellow),

                new PiecePosition(new Position(-1, -1, -1), blueOrangeYellow),
                new PiecePosition(new Position(-1, 0, -1), blueYellow),
                new PiecePosition(new Position(-1, 1, -1), blueRedYellow),
            };

            return new Cube(positions);
        }
    }
}