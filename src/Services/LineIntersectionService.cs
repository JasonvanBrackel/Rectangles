using System;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public class LineIntersectionService : ILineIntersectionService
    {
        public IIntersectionResult Solve(ILine line, ILine anotherLine)
        {
            if(line.Equals(anotherLine))
                return  new IntersectionResult(false, new IPoint[0]);

            //Calculation derived from http://devmag.org.za/2009/04/13/basic-collision-detection-in-2d-part-1/
            //and http://devmag.org.za/2009/04/17/basic-collision-detection-in-2d-part-2/

            return new IntersectionResult(CalculateHasIntersection(line, anotherLine), CalculateIntersectionPoint(line, anotherLine));
        }

        private IPoint[] CalculateIntersectionPoint(ILine line, ILine anotherLine)
        {
            double answer;
            if ((answer = GetHasIntersectionAnswer(line, anotherLine)) == 0)
                return new IPoint[0];

            var intersectionPointOnLine = (((anotherLine.EndingPoint.XCoordinate - anotherLine.StartingPoint.XCoordinate)*
                       (line.StartingPoint.YCoordinate - anotherLine.StartingPoint.YCoordinate)) -
                      ((anotherLine.EndingPoint.YCoordinate - anotherLine.StartingPoint.YCoordinate)*
                       (line.StartingPoint.XCoordinate - anotherLine.StartingPoint.XCoordinate)))/answer;

            var intersectionPointOnAnotherLine = (((line.EndingPoint.XCoordinate - line.StartingPoint.XCoordinate)*
                       (line.StartingPoint.YCoordinate - anotherLine.StartingPoint.YCoordinate)) -
                      ((line.EndingPoint.YCoordinate - line.StartingPoint.YCoordinate)*
                       (line.StartingPoint.XCoordinate - anotherLine.StartingPoint.XCoordinate)))/answer;
		

        if ((intersectionPointOnLine < 0) || (intersectionPointOnLine > 1) || (intersectionPointOnAnotherLine < 0) || (intersectionPointOnAnotherLine > 1))
			return new IPoint[0];

            return new IPoint[]
                {
                    new Point(
                        line.StartingPoint.XCoordinate +
                        intersectionPointOnLine*(line.EndingPoint.XCoordinate - line.StartingPoint.XCoordinate),
                        line.StartingPoint.YCoordinate +
                        intersectionPointOnLine*(line.EndingPoint.YCoordinate - line.StartingPoint.YCoordinate)
                        )
                };
        }

        private bool CalculateHasIntersection(ILine line, ILine anotherLine)
        {
          return  GetHasIntersectionAnswer(line, anotherLine) != 0;
        }

        private static double GetHasIntersectionAnswer(ILine line, ILine anotherLine)
        {
            return (((anotherLine.EndingPoint.YCoordinate - anotherLine.StartingPoint.YCoordinate) * (line.EndingPoint.XCoordinate - line.StartingPoint.XCoordinate)) -
                    ((anotherLine.EndingPoint.XCoordinate - anotherLine.StartingPoint.XCoordinate) * (line.EndingPoint.YCoordinate - line.StartingPoint.YCoordinate)));
        }
    }
}