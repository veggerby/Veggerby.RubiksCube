# Veggerby.RubiksCube

[![Build Status](https://travis-ci.org/veggerby/Veggerby.RubiksCube.svg?branch=master)](https://travis-ci.org/veggerby/Veggerby.RubiksCube)

Color:

Enum for colors... they are ordered according to the side arrangement.

* White on top U (0), opposite side D Yellow (3)
* Orange on left L (1), opposite side R Red (4)
* Green at front F (2), opposite side B Blue (5)

Position:

Holding the cube with the white side on top, orange to the left, the positions (x,y,z) are a carthesian coordinate system with origin on the inner "piece" (0,0,0), so that the x is alone green/blue, y is along orange/red, z is white/yellow:

* Up is (0,0,1)
* Down is (0,0,-1)
* Left is (0,-1,0)
* Right is (0,1,0)
* Front is (1,0,0)
* Back is (-1,0,0)

Center pieces (never change position):

* White: (0,0,1)
* Yellow: (0,0,-1)
* Orange: (0,-1,0)
* Red: (0,1,0)
* Green: (1,0,0)
* Blue: (-1,0,0)

There are a total of

* 12 edge pieces
* 8 corner pieces
* 6 center pieces


Cube Layout

Sides:

      B
    L U R D
      F

Colors:

      B
    O W R Y
      G


Detailes fold out:

                                     +----------+----------+----------+
                                     |          |          |          |
                                     | -1,-1,-1 | -1, 0,-1 | -1, 1,-1 |
                                     |     B    |     B    |     B    |
                                     +----------+----------+----------+
                                     |          |    x=-1  |          |
                                     | -1,-1, 0 | -1, 0, 0 | -1, 1, 0 | (z down)
                                     |     B    |     B    |     B    |
                                     +----------+----------+----------+
                                     |          |          |          |
                                     | -1,-1, 1 | -1, 0, 1 | -1, 1, 1 |
                                     |     B    |     B    |     B    |
    +-[ z -> ]-+----------+----------+-[ y -> ]-+----------+----------+----------+----------+-[ <- z ]-+----------+----------+-[ <- y ]-+
    |          |          |          |          |          |          |          |          |          |          |          |          |
    | -1,-1,-1 | -1,-1, 0 | -1,-1, 1 | -1,-1, 1 | -1, 0, 1 | -1, 1, 1 | -1, 1, 1 | -1, 1, 0 | -1, 1,-1 | -1, 1,-1 | -1, 0,-1 | -1,-1,-1 |
    |     O    |     O    |     O    |     W    |     W    |     W    |     R    |     R    |     R    |     Y    |     Y    |     Y    |
    +----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+
    |          |    y=-1  |          |          |    z=1   |          |          |    y=1   |          |          |    z=-1  |          |
    |  0,-1,-1 |  0,-1, 0 |  0,-1, 1 |  0,-1, 1 |  0, 0, 1 |  0, 1, 1 |  0, 1, 1 |  0, 1, 0 |  0, 1,-1 |  0, 1,-1 |  0, 0,-1 |  0,-1,-1 | (x down)
    |     O    |     O    |     O    |     W    |     W    |     W    |     R    |     R    |     R    |     Y    |     Y    |     Y    |
    +----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+
    |          |          |          |          |          |          |          |          |          |          |          |          |
    |  1,-1,-1 |  1,-1, 0 |  1,-1, 1 |  1,-1, 1 |  1, 0, 1 |  1, 1, 1 |  1, 1, 1 |  1, 1, 0 |  1, 1,-1 |  1, 1,-1 |  1, 0,-1 |  1,-1,-1 |
    |     O    |     O    |     O    |     W    |     W    |     W    |     R    |     R    |     R    |     Y    |     Y    |     Y    |
    +----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+
                                     |          |          |          |
                                     |  1,-1, 1 |  1, 0, 1 |  1, 1, 1 |
                                     |     G    |     G    |     G    |
                                     +----------+----------+----------+
                                     |          |    x=1   |          |
                                     |  1,-1, 0 |  1, 0, 0 |  1, 1, 0 | (z up)
                                     |     G    |     G    |     G    |
                                     +----------+----------+----------+
                                     |          |          |          |
                                     |  1,-1,-1 |  1, 0,-1 |  1, 1,-1 |
                                     |     G    |     G    |     G    |
                                     +----------+----------+----------+
