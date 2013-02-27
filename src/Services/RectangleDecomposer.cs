using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public class RectangleDecomposer : IRectangleDecomposer
    {
        private readonly IShapeFactory _factory;

        public RectangleDecomposer(IShapeFactory factory)
        {
            _factory = factory;
        }

        public ILine[] GetLines(IRectangle rectangle)
        {
            const uint linesInARectangle = 4;
            var lines = new ILine[linesInARectangle];

            lines[0] = _factory.CreateLine(rectangle.StartingPoint.XCoordinate, 
                                           rectangle.StartingPoint.YCoordinate,
                                           rectangle.EndingPoint.XCoordinate, 
                                           rectangle.StartingPoint.YCoordinate);

            lines[1] = _factory.CreateLine(rectangle.EndingPoint.XCoordinate, 
                                           rectangle.StartingPoint.YCoordinate,
                                           rectangle.EndingPoint.XCoordinate, 
                                           rectangle.EndingPoint.YCoordinate);

            lines[2] = _factory.CreateLine(rectangle.EndingPoint.XCoordinate, 
                                           rectangle.EndingPoint.YCoordinate,
                                           rectangle.StartingPoint.XCoordinate, 
                                           rectangle.EndingPoint.YCoordinate);

            lines[3] = _factory.CreateLine(rectangle.StartingPoint.XCoordinate, 
                                           rectangle.EndingPoint.YCoordinate,
                                           rectangle.StartingPoint.XCoordinate, 
                                           rectangle.StartingPoint.YCoordinate);

            return lines;
        }
    }

    public interface IRectangleDecomposer
    {
        ILine[] GetLines(IRectangle rectangle);
    }
}