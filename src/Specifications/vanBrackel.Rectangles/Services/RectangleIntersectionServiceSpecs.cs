using System;
using System.Collections.Generic;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;

namespace Specifications.Services
{
    public class RectangleIntersectionServiceSpecs
    {

        [Test]
        public void Should_return_an_IIntersectionResult()
        {
            var sut = new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory());
            var result = sut.Solve(new Rectangle(new Point(1, 1), new Point(4, 4)), new Rectangle(new Point(5, 1), new Point(1, 4)));
            Assert.IsInstanceOf<IIntersectionResult>(result);
        }
        public class When_given_two_equal_rectangles : BaseTestFixture<RectangleIntersectionService>
        {
            private Rectangle _aRectangle;
            private Rectangle _anEqualRectangle;

            protected override void Given()
            {
                var aStartingPoint = new Point(1, 1);
                var anEndingPoint = new Point(4, 4);
                _aRectangle = new Rectangle(aStartingPoint, anEndingPoint);
                _anEqualRectangle = new Rectangle(aStartingPoint, anEndingPoint);
                base.Given();
            }

            protected override void When()
            {
                SubjectUnderTest.Solve(_aRectangle, _anEqualRectangle);
            }

            [Then]
            public void Should_throw_an_argument_exception()
            {
                Assert.IsInstanceOf<ArgumentException>(CaughtException);   
            }

            [Then]
            public void Should_return_a_message_that_the_rectangles_are_equal()
            {
                Assert.AreEqual(vanBrackel_Rectangles_Resources.SameRectanglesErrorMessage, CaughtException.Message);
            }
        }

        public class When_given_two_rectangles_that_dont_intersect : BaseTestFixture<RectangleIntersectionService>
        {
            private Rectangle _aRectangle;
            private Rectangle _aDifferentRectangle;
            private IIntersectionResult _result;

            public When_given_two_rectangles_that_dont_intersect()
            {
                DoNotMock = new Dictionary<Type, object>
                    {
                        {typeof (ILineIntersectionService), new LineIntersectionService()}
                    };
            }

            protected override void Given()
            {
 	            var aStartingPoint = new Point(1, 1);
                var anEndingPoint = new Point(4, 4);
                var anotherStartingPoint = new Point(10, 10);
                var anotherEndingPoint = new Point(12, 12);
                _aRectangle = new Rectangle(aStartingPoint, anEndingPoint);
                _aDifferentRectangle = new Rectangle(anotherStartingPoint, anotherEndingPoint);
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Solve(_aRectangle, _aDifferentRectangle);
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

        public class When_given_two_rectangles_that_intersect : BaseTestFixture<RectangleIntersectionService>
        {
            private Rectangle _aRectangle;
            private Rectangle _aDifferentRectangle;
            private IIntersectionResult _result;

            public When_given_two_rectangles_that_intersect()
            {
                DoNotMock = new Dictionary<Type, object>
                    {
                        {typeof (ILineIntersectionService), new LineIntersectionService()}
                    };
                DoNotMock.Add(typeof(IRectangleDecomposer), new RectangleDecomposer(new ShapeFactory()));
            }

            protected override void Given()
            {
                var aStartingPoint = new Point(0, 0);
                var anEndingPoint = new Point(10, 10);
                var anotherStartingPoint = new Point(1, 1);
                var anotherEndingPoint = new Point(12, 12);
                _aRectangle = new Rectangle(aStartingPoint, anEndingPoint);
                _aDifferentRectangle = new Rectangle(anotherStartingPoint, anotherEndingPoint);
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Solve(_aRectangle, _aDifferentRectangle);
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