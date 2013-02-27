using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public interface IAdjacencyService
    {
        bool AreAdjacent(IRectangle rectangle, IRectangle anotherRectangle);
    }
}