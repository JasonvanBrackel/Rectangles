using NUnit.Framework;
using vanBrackel.Rectangles.Domain;

namespace vanBrackel.Rectangles.Specifications.vanBrackel.Rectangles.Domain
{
    public class PointSpecs
    {
        private IPoint _sut = new Point(1, 2);

        [Test]
        public void Should_set_x_and_y_coordinates_via_constructors()
        {
            var xCoordinate = 3L;
            var yCoordinate = 5L;
            var sut = new Point(xCoordinate, yCoordinate);
            Assert.AreEqual(xCoordinate, sut.XCoordinate);
            Assert.AreEqual(yCoordinate, sut.YCoordinate);
        }

        [Test]
        public void Should_implement_equals()
        {
            var anotherPoint = new Point(1, 2);
            _sut.Equals(anotherPoint);
        }

        [Test]
        public void Should_be_equal_if_x_and_y_coordiates_are_the_same()
        {
            var anEqualPoint = new Point(1, 2);
            Assert.AreEqual(anEqualPoint, _sut);
        }

        [Test]
        public void Should_not_be_equal_if_x_coordinate_are_different()
        {
            var aDifferentPoint = new Point(2, 2);
            Assert.AreNotEqual(aDifferentPoint, _sut);
        }

        [Test]
        public void Should_not_be_equal_if_y_coordinate_are_different()
        {
            var aDifferentPoint = new Point(1, 1);
            Assert.AreNotEqual(aDifferentPoint, _sut);
        }
    }
}