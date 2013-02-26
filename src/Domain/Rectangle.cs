namespace vanBrackel.Rectangles.Domain
{
    public class Rectangle : IRectangle
    {
        public Rectangle(IPoint startingPoint, IPoint endingPoint)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
        }

        public IPoint StartingPoint { get; private set; }
        public IPoint EndingPoint { get; private set; }

        protected bool Equals(Rectangle other)
        {
            return Equals(StartingPoint, other.StartingPoint) && Equals(EndingPoint, other.EndingPoint);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rectangle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((StartingPoint != null ? StartingPoint.GetHashCode() : 0)*397) ^ (EndingPoint != null ? EndingPoint.GetHashCode() : 0);
            }
        }
    }
}