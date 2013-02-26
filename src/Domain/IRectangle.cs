namespace vanBrackel.Rectangles.Domain
{
    public interface IRectangle
    {
        IPoint StartingPoint { get; }
        IPoint EndingPoint { get; }
    }
}