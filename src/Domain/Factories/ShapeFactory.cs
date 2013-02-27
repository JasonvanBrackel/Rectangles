using System;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Domain.Factories
{
    public class ShapeFactory : IShapeFactory
    {
        public IRectangle CreateRectangle(double startingXCoordinate, double startingYCoordinate, double endingXCoordinate, double endingYCoordinate)
        {
            var topmostY = Math.Round(startingYCoordinate > endingYCoordinate ? startingYCoordinate : endingYCoordinate, 2);
            var bottommostY = Math.Round(startingYCoordinate < endingYCoordinate ? startingYCoordinate : endingYCoordinate, 2);
            var leftmostX = Math.Round(startingXCoordinate < endingXCoordinate ? startingXCoordinate : endingXCoordinate, 2);
            var rightmostX = Math.Round(startingXCoordinate > endingXCoordinate ? startingXCoordinate : endingXCoordinate, 2);

            if(topmostY.Equals(bottommostY) || rightmostX.Equals(leftmostX))
                throw new ArgumentException(vanBrackel_Rectangles_Resources.BadShapeError);

            return new Rectangle(CreatePoint(leftmostX, topmostY), CreatePoint(rightmostX, bottommostY));
        }

        public ILine CreateLine(double startingXCoordinate, double startingYCoordinate, double endingXCoordinate, double endingYCoordinate)
        {
            if(startingXCoordinate.Equals(endingXCoordinate) && startingYCoordinate.Equals(endingYCoordinate))
                throw new ArgumentException(vanBrackel_Rectangles_Resources.BadShapeError);

            if(startingXCoordinate < endingXCoordinate)
                return new Line(CreatePoint(Math.Round(startingXCoordinate, 2), Math.Round(startingYCoordinate, 2)), CreatePoint(Math.Round(endingXCoordinate, 2), Math.Round(endingYCoordinate, 2)));

            return new Line(CreatePoint(Math.Round(endingXCoordinate, 2), Math.Round(endingYCoordinate, 2)), CreatePoint(Math.Round(startingXCoordinate, 2), Math.Round(startingYCoordinate,2)));
        }

        public IPoint CreatePoint(double xCoordinate, double yCoordinate)
        {
            return new Point(Math.Round(xCoordinate, 2), Math.Round(yCoordinate, 2));
        }

    }
}
