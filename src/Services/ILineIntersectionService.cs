using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public interface ILineIntersectionService
    {
        IIntersectionResult Solve(ILine line, ILine anotherLine);
    }
}