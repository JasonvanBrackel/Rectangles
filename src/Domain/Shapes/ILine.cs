namespace vanBrackel.Rectangles.Domain.Shapes
{
    public interface ILine
    {
        IPoint StartingPoint { get; }
        IPoint EndingPoint { get; }
        bool Contains(ILine line);
    }
}