using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public interface IRectangleIntersectionService
    {
        IIntersectionResult Solve(IRectangle aRectangle, IRectangle aDifferentRectangle);
    }
}