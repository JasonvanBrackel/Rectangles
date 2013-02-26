using NUnit.Framework;
using vanBrackel.Rectangles.Domain;

namespace vanBrackel.Rectangles.Specifications.vanBrackel.Rectangles.Domain
{
    public class RectangleSpecs
    {
        private Rectangle _sut = new Rectangle(new Point(1,1), new Point(4,4));
        [Test]
        public void Should_set_startingPoint_and_endingPoint_in_constructor()
        {
            var startingPoint = new Point(2, 2);
            var endingPoint = new Point(5, 5);
            var sut = new Rectangle(startingPoint, endingPoint);

            Assert.AreEqual(startingPoint, sut.StartingPoint);
            Assert.AreEqual(endingPoint, sut.EndingPoint);
        }

        [Test]
        public void Should_implement_equals()
        {
            _sut.Equals(new Rectangle(new Point(1,1), new Point(2,2)));

        }

        [Test]
        public void Should_be_equal_if_startingPoint_and_endingPoint_are_equal()
        {
            var anEqualRectangle = new Rectangle(new Point(1, 1), new Point(4, 4));
            Assert.AreEqual(anEqualRectangle, _sut);
        }

        [Test]
        public void Should_not_be_equal_if_startingPoints_are_different()
        {
            var anNotEqualRectangle = new Rectangle(new Point(1, 2), new Point(4, 4));
            Assert.AreNotEqual(anNotEqualRectangle, _sut);
        }

        [Test]
        public void Should_not_be_equal_if_endingPoints_are_different()
        {
            var anNotEqualRectangle = new Rectangle(new Point(1, 1), new Point(4, 5));
            Assert.AreNotEqual(anNotEqualRectangle, _sut);
        }

    }
}