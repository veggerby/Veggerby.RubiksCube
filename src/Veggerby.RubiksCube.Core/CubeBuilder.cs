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
            var white = new CenterPiece(whiteUp);
            var yellow = new CenterPiece(yellowDown);
            var orange = new CenterPiece(orangeLeft);
            var red = new CenterPiece(redRight);
            var green = new CenterPiece(greenFront);
            var blue = new CenterPiece(blueBack);

            // create corner pieces (x/y/z side)
            var greenOrangeWhite = new CornerPiece(greenFront, orangeLeft, whiteUp);
            var blueOrangeWhite = new CornerPiece(blueBack, orangeLeft, whiteUp);
            var greenRedWhite = new CornerPiece(greenFront, redRight, whiteUp);
            var blueRedWhite = new CornerPiece(blueBack, redRight, whiteUp);
            var greenOrangeYellow = new CornerPiece(greenFront, orangeLeft, yellowDown);
            var blueOrangeYellow = new CornerPiece(blueBack, orangeLeft, yellowDown);
            var greenRedYellow = new CornerPiece(greenFront, redRight, yellowDown);
            var blueRedYellow = new CornerPiece(blueBack, redRight, yellowDown);

            // create edge pieces (top layer)
            var orangeWhite = new EdgePiece(orangeLeft, whiteUp);
            var greenWhite = new EdgePiece(greenFront, whiteUp);
            var redWhite = new EdgePiece(redRight, whiteUp);
            var blueWhite = new EdgePiece(blueBack, whiteUp);

            // create edge pieces (middle layer)
            var orangeGreen = new EdgePiece(orangeLeft, greenFront);
            var greenRed = new EdgePiece(greenFront, redRight);
            var redBlue = new EdgePiece(redRight, blueBack);
            var blueOrange = new EdgePiece(blueBack, orangeLeft);

            // create edge pieces (bottom layer)
            var orangeYellow = new EdgePiece(orangeLeft, yellowDown);
            var greenYellow = new EdgePiece(greenFront, yellowDown);
            var redYellow = new EdgePiece(redRight, yellowDown);
            var blueYellow = new EdgePiece(blueBack, yellowDown);

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