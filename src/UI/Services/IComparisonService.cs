using vanBrackel.Rectangles.UI.Model;

namespace vanBrackel.Rectangles.UI.Services
{
    public interface IComparisonService
    {
        IComparisonResult[] ConductComparison(RectangleViewModel rectangle1, RectangleViewModel rectangle2);
    }
}