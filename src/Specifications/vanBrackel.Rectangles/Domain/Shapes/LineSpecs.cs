using NUnit.Framework;
using vanBrackel.Rectangles.Domain.Shapes;

namespace Specifications.Domain.Shapes
{
    public class LineSpecs
    {
        private Line _sut = new Line(new Point(1,1), new Point(4,4));
        [Test]
        public void Should_set_startingPoint_and_endingPoint_in_constructor()
        {
            var startingPoint = new Point(2, 2);
            var endingPoint = new Point(5, 5);
            var sut = new Line(startingPoint, endingPoint);

            Assert.AreEqual(startingPoint, sut.StartingPoint);
            Assert.AreEqual(endingPoint, sut.EndingPoint);
        }

        [Test]
        public void Should_implement_equals()
        {
            _sut.Equals(new Line(new Point(1,1), new Point(2,2)));

        }

        [Test]
        public void Should_be_equal_if_startingPoint_and_endingPoint_are_equal()
        {
            var anEqualLine = new Line(new Point(1, 1), new Point(4, 4));
            Assert.AreEqual(anEqualLine, _sut);
        }

        [Test]
        public void Should_not_be_equal_if_startingPoints_are_different()
        {
            var anNotEqualLine = new Line(new Point(1, 2), new Point(4, 4));
            Assert.AreNotEqual(anNotEqualLine, _sut);
        }

        [Test]
        public void Should_not_be_equal_if_endingPoints_are_different()
        {
            var anNotEqualLine = new Line(new Point(1, 1), new Point(4, 5));
            Assert.AreNotEqual(anNotEqualLine, _sut);
        }

        public class When_checking_if_a_line_is_contained_in_another_line_and_it_is : BaseTestFixture
        {
            private Line _subjectUnderTest;
            private Line _innerLine;
            private bool _result;

            protected override void Given()
            {
                _innerLine = new Line(new Point(1, 0), new Point(8, 0));
                _subjectUnderTest = new Line(new Point(0, 0), new Point(10, 0));
                base.Given();
            }

            protected override void When()
            {
                _result = _subjectUnderTest.Contains(_innerLine);
            }

            [Then]
            public void Should_return_true()
            {
                Assert.IsTrue(_result);
            }
        }

        public class When_checking_if_a_line_is_contained_in_another_line_and_it_is_not : BaseTestFixture
        {
            private bool _result;
            private Line _subjectUnderTest;
            private Line _notContained;

            protected override void Given()
            {
                _notContained = new Line(new Point(0, 0), new Point(8, 1));
                _subjectUnderTest = new Line(new Point(0, 0), new Point(10, 0));
                base.Given();
                base.Given();
            }

            protected override void When()
            {
                _result = _subjectUnderTest.Contains(_notContained);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_checking_if_a_line_is_contained_in_another_line_and_the_lines_are_equal : BaseTestFixture
        {
            private Line _equalLine;
            private Line _subjectUnderTest;
            private bool _result;

            protected override void Given()
            {
                _equalLine = new Line(new Point(0, 0), new Point(10, 0));
                _subjectUnderTest = new Line(new Point(0, 0), new Point(10, 0));
                base.Given();
                base.Given();
            }

            protected override void When()
            {
                _result = _subjectUnderTest.Contains(_equalLine);
            }

            [Then]
            public void Should_return_true()
            {
                Assert.IsTrue(_result);
            }
        }

    }
}