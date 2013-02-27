using System;
using System.Collections.Generic;
using System.Linq;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public class RectangleIntersectionService : IRectangleIntersectionService
    {
        private readonly ILineIntersectionService _lineIntersectionService;
        private readonly IRectangleDecomposer _rectangleDecomposer;
        private readonly IShapeFactory _shapeFactory;

        public RectangleIntersectionService(ILineIntersectionService lineIntersectionService, IRectangleDecomposer rectangleDecomposer, IShapeFactory shapeFactory)
        {
            _lineIntersectionService = lineIntersectionService;
            _rectangleDecomposer = rectangleDecomposer;
            _shapeFactory = shapeFactory;
        }

        private ILine[] _aRectanglesLines;
        private ILine[] _aDifferentRectanglesLines;
        public IIntersectionResult Solve(IRectangle aRectangle, IRectangle aDifferentRectangle)
        {
            var intersectionPoints = new List<IPoint>();
            if(aRectangle.Equals(aDifferentRectangle))
                throw new ArgumentException(vanBrackel_Rectangles_Resources.SameRectanglesErrorMessage);

            _aRectanglesLines = _rectangleDecomposer.GetLines(aRectangle);
            _aDifferentRectanglesLines = _rectangleDecomposer.GetLines(aDifferentRectangle);

            //TODO: Make more efficient
            foreach (var aRectanglesLine in _aRectanglesLines)
            {
                foreach (var aDifferentRectanglesLine in _aDifferentRectanglesLines)
                {
                    var result = _lineIntersectionService.Solve(aRectanglesLine, aDifferentRectanglesLine);

                    if(result.HasIntersection)
                        foreach (var intersectionPoint in result.IntersectionPoints)
                        {
                            if(!intersectionPoints.Contains(intersectionPoint))
                                intersectionPoints.Add(intersectionPoint);
                        }
                }
            }

            //If there are at least two intersection points that create a line, and that line is in both rectangles it's adjacent not an intersection
            if (intersectionPoints.Count >= 2)
            {
                var testLines = new ILine[intersectionPoints.Count - 1];
                if (testLines.Length >= 1)
                    testLines[0] = _shapeFactory.CreateLine(intersectionPoints[0].XCoordinate,
                                                            intersectionPoints[0].YCoordinate,
                                                            intersectionPoints[1].XCoordinate,
                                                            intersectionPoints[1].YCoordinate);
                if (testLines.Length >= 2)
                    testLines[1] = _shapeFactory.CreateLine(intersectionPoints[1].XCoordinate,
                                                            intersectionPoints[1].YCoordinate,
                                                            intersectionPoints[2].XCoordinate,
                                                            intersectionPoints[2].YCoordinate);
                
                foreach (var testLine in testLines)
                {
                    if (_aRectanglesLines.Any(line => line.Contains(testLine)) && _aDifferentRectanglesLines.Any(line => line.Contains(testLine)))
                        return new IntersectionResult(false, new IPoint[0]);
                }
                
            }

            return new IntersectionResult(intersectionPoints.Any(), intersectionPoints.ToArray());
        }
    }
}