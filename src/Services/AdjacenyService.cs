using System.Collections.Generic;
using System.Linq;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public class AdjacenyService : IAdjacencyService
    {
        private readonly IRectangleDecomposer _decomposer;
        private readonly IRectangleIntersectionService _intersectionService;

        public AdjacenyService(IRectangleDecomposer decomposer, IRectangleIntersectionService intersectionService)
        {
            _decomposer = decomposer;
            _intersectionService = intersectionService;
        }

        public bool AreAdjacent(IRectangle rectangle, IRectangle anotherRectangle)
        {
            //If any lines are inside another rectangle it can't be adjacent
            if(_decomposer.GetLines(anotherRectangle).Any(line => rectangle.Contains(line.StartingPoint) && rectangle.Contains(line.EndingPoint)))
                return false;

            if (_decomposer.GetLines(rectangle).Any(line => anotherRectangle.Contains(line.StartingPoint) && anotherRectangle.Contains(line.EndingPoint)))
                return false;

            //If rectangles intersect they are not adjacent
            if (_intersectionService.Solve(rectangle, anotherRectangle).HasIntersection)
                return false;

            //For two rectangles to be adjacent the must share exactly 1 one or have 1 line exist in another
            var matchingLines = new List<ILine>();
            foreach (var line in _decomposer.GetLines(rectangle))
            {
                foreach (var anotherLine in _decomposer.GetLines(anotherRectangle))
                {
                    if (line.Contains(anotherLine) || anotherLine.Contains(line))
                    {
                        if(line.Contains(anotherLine) && !matchingLines.Contains(anotherLine))
                            matchingLines.Add(anotherLine);

                        if(anotherLine.Contains(line) && !matchingLines.Contains(line))
                            matchingLines.Add(line);
                    }
                }
            }

            return matchingLines.Count == 1;
        }
    }
}
