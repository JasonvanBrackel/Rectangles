namespace vanBrackel.Rectangles.Domain.Shapes
{
    public interface IRectangle
    {
        IPoint StartingPoint { get; }
        IPoint EndingPoint { get; }
        bool Contains(IPoint point);
    }
}