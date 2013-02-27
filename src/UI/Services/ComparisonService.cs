using System;
using System.Collections.Generic;
using System.Linq;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;
using vanBrackel.Rectangles.UI.IoC;
using vanBrackel.Rectangles.UI.Model;

namespace vanBrackel.Rectangles.UI.Services
{
    public class ComparisonService : IComparisonService
    {
        private readonly IRectangleIntersectionService _rectangleIntersectionService;
        private readonly IAdjacencyService _adjacencyService;
        private readonly IDependencyResolver _resolver;
        private readonly IShapeFactory _shapeFactory;

        public ComparisonService(IRectangleIntersectionService rectangleIntersectionService, IAdjacencyService adjacencyService, IDependencyResolver resolver, IShapeFactory shapeFactory)
        {
            _rectangleIntersectionService = rectangleIntersectionService;
            _adjacencyService = adjacencyService;
            _resolver = resolver;
            _shapeFactory = shapeFactory;
        }

        public IComparisonResult[] ConductComparison(RectangleViewModel rectangle1, RectangleViewModel rectangle2)
        {
            IList<IComparisonResult> results = new List<IComparisonResult>();
            try
            {
                var firstRectangle = _shapeFactory.CreateRectangle(rectangle1.StartingPoint.XCoordinate,
                                                                   rectangle1.StartingPoint.YCoordinate,
                                                                   rectangle1.EndingPoint.XCoordinate,
                                                                   rectangle1.EndingPoint.YCoordinate);

                var secondRectangle = _shapeFactory.CreateRectangle(rectangle2.StartingPoint.XCoordinate,
                                                                    rectangle2.StartingPoint.YCoordinate,
                                                                    rectangle2.EndingPoint.XCoordinate,
                                                                    rectangle2.EndingPoint.YCoordinate);

                var intersectionResult = _rectangleIntersectionService.Solve(firstRectangle, secondRectangle);

                if (intersectionResult.HasIntersection)
                {
                    var message = intersectionResult.IntersectionPoints.Aggregate("", (current, point) => current + ("x: " + point.XCoordinate.ToString() + "y: " + point.YCoordinate.ToString() + ","));
                    message = message.Remove(message.Length - 1);

                    results.Add(CreateComparisonResult(String.Format(vanBrackel_Rectangles_Resources.IsAnIntersectionMessage, message)));
                    results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsNotAdjacentMessage));
                    results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsNotContainedMessage));

                    return results.ToArray();
                }

                results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsNotAnIntersectionMessage));

                if (_adjacencyService.AreAdjacent(firstRectangle, secondRectangle))
                {
                    results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsAdjacentMessage));
                    results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsNotContainedMessage));
                    return results.ToArray();
                }

                results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsNotAdjacentMessage));

                var containmentService = _resolver.Resolve<IContainmentService>(new KeyValuePair<string, object>("outerRectangle", firstRectangle));

                if (containmentService.Contains(secondRectangle))
                {
                    results.Add(CreateComparisonResult(String.Format(vanBrackel_Rectangles_Resources.IsContainedInMessage, "2", "1")));
                    return results.ToArray();
                }

                containmentService = _resolver.Resolve<IContainmentService>(new KeyValuePair<string, object>("outerRectangle", secondRectangle));

                if (containmentService.Contains(firstRectangle))
                {
                    results.Add(CreateComparisonResult(String.Format(vanBrackel_Rectangles_Resources.IsContainedInMessage, "1", "2")));
                    return results.ToArray();
                }

                results.Add(CreateComparisonResult(vanBrackel_Rectangles_Resources.IsNotContainedMessage));

                return results.ToArray();
            }
            catch (Exception e)
            {
                return new IComparisonResult[] { new ComparisonResult() {Message = vanBrackel_Rectangles_Resources.NotComparableMessage + e.Message}};
            }
        }

        private static ComparisonResult CreateComparisonResult(string message)
        {
            return new ComparisonResult() {Message = message};
        }


    }
}
