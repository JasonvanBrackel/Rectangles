namespace vanBrackel.Rectangles.Domain
{
    public class Point : IPoint
    {
        protected bool Equals(Point other)
        {
            return XCoordinate == other.XCoordinate && YCoordinate == other.YCoordinate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (XCoordinate.GetHashCode()*397) ^ YCoordinate.GetHashCode();
            }
        }

        public Point(long xCoordinate, long yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public long XCoordinate { get; private set; }
        public long YCoordinate { get; private set; }
    }
}