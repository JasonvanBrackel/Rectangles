using System;

namespace vanBrackel.Rectangles.Domain.Shapes
{
    public class Line : ILine
    {
        public Line(IPoint startingPoint, IPoint endingPoint)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
        }

        public IPoint StartingPoint { get; private set; }
        public IPoint EndingPoint { get; private set; }

        protected bool Equals(Line other)
        {
            return Equals(StartingPoint, other.StartingPoint) && Equals(EndingPoint, other.EndingPoint) || Equals(StartingPoint, other.EndingPoint) && Equals(EndingPoint, other.StartingPoint);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((StartingPoint != null ? StartingPoint.GetHashCode() : 0)*397) ^ (EndingPoint != null ? EndingPoint.GetHashCode() : 0);
            }
        }

        public bool Contains(ILine innerLine)
        {
            //Derived from http://stackoverflow.com/questions/328107/how-can-you-determine-a-point-is-between-two-other-points-on-a-line-segment
            if (Equals(innerLine))
                return true;

            return Contains(innerLine.StartingPoint) && Contains(innerLine.EndingPoint);
        }

        public bool Contains(IPoint point)
        {
            var crossProduct = (point.YCoordinate - StartingPoint.YCoordinate)*
                               (EndingPoint.XCoordinate - StartingPoint.XCoordinate) -
                               (point.XCoordinate - StartingPoint.XCoordinate)*
                               (EndingPoint.YCoordinate - StartingPoint.YCoordinate);

            if (Math.Abs(crossProduct) > Double.Epsilon)
                return false;

            var dotProduct = (point.XCoordinate - StartingPoint.XCoordinate)*
                             (EndingPoint.XCoordinate - StartingPoint.XCoordinate) +
                             (point.YCoordinate - StartingPoint.YCoordinate)*
                             (EndingPoint.YCoordinate - StartingPoint.YCoordinate);
            if (dotProduct < 0)
                return false;

            var squaredLength = (EndingPoint.XCoordinate - StartingPoint.XCoordinate)*
                                  (EndingPoint.XCoordinate - StartingPoint.XCoordinate) +
                                  (EndingPoint.YCoordinate - StartingPoint.YCoordinate)*
                                  (EndingPoint.YCoordinate - StartingPoint.YCoordinate);
            if (dotProduct > squaredLength)
                return false;

            return true;
        }
    }
}