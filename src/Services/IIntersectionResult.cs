using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public interface IIntersectionResult
    {
        bool HasIntersection { get; }
        IPoint[] IntersectionPoints { get; }
    }
}