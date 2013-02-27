namespace vanBrackel.Rectangles.Domain.Shapes
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
        
        public bool Contains(IPoint point)
        {
            var topLeft = GetTopLeftCorner();
            var bottomRight = GetLowerRightCorner();

            return point.YCoordinate < topLeft.YCoordinate && 
                   point.XCoordinate > topLeft.XCoordinate &&
                   point.YCoordinate > bottomRight.YCoordinate && 
                   point.XCoordinate < bottomRight.XCoordinate;
        }

        private IPoint GetLowerRightCorner()
        {
            return new Point(
                StartingPoint.XCoordinate > EndingPoint.XCoordinate
                    ? StartingPoint.XCoordinate
                    : EndingPoint.XCoordinate,
                StartingPoint.YCoordinate < EndingPoint.YCoordinate
                    ? StartingPoint.YCoordinate
                    : EndingPoint.YCoordinate
                );
        }

        private IPoint GetTopLeftCorner()
        {
            return new Point(
                StartingPoint.XCoordinate < EndingPoint.XCoordinate
                    ? StartingPoint.XCoordinate
                    : EndingPoint.XCoordinate,
                StartingPoint.YCoordinate > EndingPoint.YCoordinate
                    ? StartingPoint.YCoordinate
                    : EndingPoint.YCoordinate
                );
        }

        protected bool Equals(Rectangle other)
        {
            return Equals(StartingPoint, other.StartingPoint) && Equals(EndingPoint, other.EndingPoint) || Equals(StartingPoint, other.EndingPoint) && Equals(EndingPoint, other.StartingPoint);
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