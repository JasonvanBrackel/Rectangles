using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public class IntersectionResult : IIntersectionResult
    {
        public IntersectionResult(bool hasIntersection, IPoint[] intersectionPoints)
        {
            HasIntersection = hasIntersection;
            IntersectionPoints = intersectionPoints;
        }

        public bool HasIntersection { get; private set; }
        public IPoint[] IntersectionPoints { get; private set; }
    }
}