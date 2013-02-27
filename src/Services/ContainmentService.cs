using System;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public class ContainmentService : IContainmentService
    {
        private readonly IRectangle _outerRectangle;
        private readonly IRectangleIntersectionService _rectangleIntersectionService;

        public ContainmentService(IRectangle outerRectangle, IRectangleIntersectionService rectangleIntersectionService)
        {
            _outerRectangle = outerRectangle;
            _rectangleIntersectionService = rectangleIntersectionService;
        }

        public bool Contains(IRectangle rectangle)
        {
            if(_outerRectangle == null)
                throw new NullReferenceException(vanBrackel_Rectangles_Resources.ContainmentServiceNotInitializedMessage);

            if (_rectangleIntersectionService.Solve(_outerRectangle, rectangle).HasIntersection)
                return false;

            return CalculateContainment(_outerRectangle, rectangle);

        }

        private bool CalculateContainment(IRectangle outerRectangle, IRectangle rectangle)
        {
            var outerTopLeftCorner = GetTopLeftCorner(outerRectangle);
            var outerLowerRightCorner = GetLowerRightCorner(outerRectangle);

            var innerTopLeftCorner = GetTopLeftCorner(rectangle);
            var innerLowerRightCorner = GetLowerRightCorner(rectangle);

            if (outerTopLeftCorner.YCoordinate < innerTopLeftCorner.YCoordinate)
                return false;

            if (outerTopLeftCorner.XCoordinate > innerTopLeftCorner.XCoordinate)
                return false;

            if (outerLowerRightCorner.XCoordinate < innerLowerRightCorner.XCoordinate)
                return false;

            if (outerLowerRightCorner.YCoordinate > innerLowerRightCorner.YCoordinate)
                return false;

            return true;
        }

        private static Point GetLowerRightCorner(IRectangle rectangle)
        {
            return new Point(
                rectangle.StartingPoint.XCoordinate > rectangle.EndingPoint.XCoordinate
                    ? rectangle.StartingPoint.XCoordinate
                    : rectangle.EndingPoint.XCoordinate,
                rectangle.StartingPoint.YCoordinate < rectangle.EndingPoint.YCoordinate
                    ? rectangle.StartingPoint.YCoordinate
                    : rectangle.EndingPoint.YCoordinate
                );
        }

        private Point GetTopLeftCorner(IRectangle rectangle)
        {
            return new Point(
                rectangle.StartingPoint.XCoordinate < rectangle.EndingPoint.XCoordinate
                    ? rectangle.StartingPoint.XCoordinate
                    : rectangle.EndingPoint.XCoordinate,
                rectangle.StartingPoint.YCoordinate > rectangle.EndingPoint.YCoordinate
                    ? rectangle.StartingPoint.YCoordinate
                    : rectangle.EndingPoint.YCoordinate
                );
        }
    }
}