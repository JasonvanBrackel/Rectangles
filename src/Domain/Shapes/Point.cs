using System;

namespace vanBrackel.Rectangles.Domain.Shapes
{
    public class Point : IPoint
    {
        protected bool Equals(Point other)
        {
            return XCoordinate.Equals(other.XCoordinate) && YCoordinate.Equals(other.YCoordinate);
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

        public Point(double xCoordinate, double yCoordinate)
        {
            XCoordinate = Math.Round(xCoordinate, 2);
            YCoordinate = Math.Round(yCoordinate, 2);
        }

        public double XCoordinate { get; private set; }
        public double YCoordinate { get; private set; }
    }
}