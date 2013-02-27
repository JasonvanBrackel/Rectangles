using NUnit.Framework;
using vanBrackel.Rectangles.Domain.Shapes;

namespace Specifications.Domain.Shapes
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

        public class When_a_point_is_inside_a_rectangle: BaseTestFixture
        {
            private Rectangle _subjectUnderTest;
            private Point _innerPoint;
            private bool _result;

            protected override void Given()
            {
                _subjectUnderTest = new Rectangle(new Point(0, 10), new Point(10, 0));
                _innerPoint = new Point(4, 4);
                base.Given();
            }
            protected override void When()
            {
                _result = _subjectUnderTest.Contains(_innerPoint);
            }

            [Then]
            public void Should_return_true()
            {
                Assert.IsTrue(_result);
            }
        }

        public class When_a_point_is_on_a_line_of_a_rectangle : BaseTestFixture
        {
            private Rectangle _subjectUnderTest;
            private Point _innerPoint;
            private bool _result;

            protected override void Given()
            {
                _subjectUnderTest = new Rectangle(new Point(0, 10), new Point(10, 0));
                _innerPoint = new Point(1, 0);
                base.Given();
            }
            protected override void When()
            {
                _result = _subjectUnderTest.Contains(_innerPoint);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_a_point_is_outside_a_rectangle : BaseTestFixture
        {
            private Rectangle _subjectUnderTest;
            private Point _outerPoint;
            private bool _result;

            protected override void Given()
            {
                _subjectUnderTest = new Rectangle(new Point(0, 10), new Point(10, 0));
                _outerPoint = new Point(11, 11);
                base.Given();
            }
            protected override void When()
            {
                _result = _subjectUnderTest.Contains(_outerPoint);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }
    }
}