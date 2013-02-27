using System;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;

namespace Specifications.Services
{
    public class LineIntersectionServiceSpecs
    {
        [Test]
        public void Should_return_an_IIntersectionResult()
        {
            var sut = new LineIntersectionService();
            var result = sut.Solve(new Line(new Point(1, 1), new Point(4, 4)), new Line(new Point(4, 1), new Point(1, 4)));
            Assert.IsInstanceOf<IIntersectionResult>(result);
        }

        public class When_given_two_equal_lines : BaseTestFixture<LineIntersectionService>
        {
            private Line _aLine;
            private Line _anEqualLine;
            private IIntersectionResult _result;

            protected override void Given()
            {
                var aStartingPoint = new Point(1, 1);
                var anEndingPoint = new Point(4, 4);
                _aLine = new Line(aStartingPoint, anEndingPoint);
                _anEqualLine = new Line(aStartingPoint, anEndingPoint);
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Solve(_aLine, _anEqualLine);
            }

            [Then]
            public void Should_return_an_intersectionResult_with_hasInsersection_of_false()
            {
                Assert.IsFalse(_result.HasIntersection);
            }

            [Then]
            public void Should_return_an_intersectionResult_with_zero_intersection_points()
            {
                Assert.IsEmpty(_result.IntersectionPoints);
            }
        }

        public class When_given_two_lines_that_dont_intersect : BaseTestFixture<LineIntersectionService>
        {
            private Line _aLine;
            private Line _aDifferentRectangle;
            private IIntersectionResult _result;

            protected override void Given()
            {
                var aStartingPoint = new Point(1, 1);
                var anEndingPoint = new Point(4, 4);
                var anotherStartingPoint = new Point(10, 10);
                var anotherEndingPoint = new Point(12, 12);
                _aLine = new Line(aStartingPoint, anEndingPoint);
                _aDifferentRectangle = new Line(anotherStartingPoint, anotherEndingPoint);
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Solve(_aLine, _aDifferentRectangle);
            }

            [Then]
            public void Should_return_an_intersectionResult_with_hasInsersection_of_false()
            {
                Assert.IsFalse(_result.HasIntersection);
            }

            [Then]
            public void Should_return_an_intersectionResult_with_zero_intersection_points()
            {
                Assert.IsEmpty(_result.IntersectionPoints);
            }
        }

        public class When_given_two_lines_that_intersect : BaseTestFixture<LineIntersectionService>
        {
            private Line _aLine;
            private Line _aDifferentRectangle;
            private IIntersectionResult _result;

            protected override void Given()
            {
                var aStartingPoint = new Point(1, 1);
                var anEndingPoint = new Point(4, 4);
                var anotherStartingPoint = new Point(4, 1);
                var anotherEndingPoint = new Point(1, 4);
                _aLine = new Line(aStartingPoint, anEndingPoint);
                _aDifferentRectangle = new Line(anotherStartingPoint, anotherEndingPoint);
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Solve(_aLine, _aDifferentRectangle);
            }

            [Then]
            public void Should_return_an_intersectionResult_with_hasInsersection_of_true()
            {
                Assert.IsTrue(_result.HasIntersection);
            }

            [Then]
            public void Should_return_an_intersectionResult_with_intersection_points()
            {
                Assert.IsNotEmpty(_result.IntersectionPoints);
            }
        }
    }
}