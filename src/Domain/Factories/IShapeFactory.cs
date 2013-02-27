using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Domain.Factories
{
    public interface IShapeFactory
    {
        IRectangle CreateRectangle(double startingXCoordinate, double startingYCoordinate, double endingXCoordinate, double endingYCoordinate);
        ILine CreateLine(double startingXCoordinate, double startingYCoordinate, double endingXCoordinate, double endingYCoordinate);
        IPoint CreatePoint(double xCoordinate, double yCoordinate);
    }
}