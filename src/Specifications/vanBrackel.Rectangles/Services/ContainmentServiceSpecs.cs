using System;
using System.Collections.Generic;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;

namespace Specifications.Services
{
    public class ContainmentServiceSpecs
    {
        [Test]
        public void Should_accept_the_outer_rectangle_in_the_constructor()
        {
            var startingPoint = new Point(1, 1);
            var endingPoint = new Point(4, 4);
            IRectangle outerRectangle = new Rectangle(startingPoint, endingPoint);
            var sut = new ContainmentService(outerRectangle, new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory()));
        }

        public class When_null_is_passed_into_the_ContainmentService : BaseTestFixture<ContainmentService>
        {
            public When_null_is_passed_into_the_ContainmentService()
            {
                DoNotMock = new Dictionary<Type, object>();
                DoNotMock.Add(typeof(IRectangle), null);
            }

            protected override void When()
            {
                SubjectUnderTest.Contains(new Rectangle(new Point(1, 1), new Point(4, 4)));
            }

            [Then]
            public void Should_throw_NullReferenceException()
            {
                Assert.IsInstanceOf<NullReferenceException>(CaughtException); 
            }

            [Then]
            public void Should_have_an_let_the_user_know_the_ContainerService_was_not_initialized_in_the_exception()
            {
                Assert.AreEqual(vanBrackel_Rectangles_Resources.ContainmentServiceNotInitializedMessage, CaughtException.Message);
            }
        }

        public class When_a_rectangle_is_provided_that_is_contained_in_the_outer_rectangle : BaseTestFixture<ContainmentService>
        {
            private bool _result;

            public When_a_rectangle_is_provided_that_is_contained_in_the_outer_rectangle()
            {
                DoNotMock = new Dictionary<Type, object>();
                DoNotMock.Add(typeof(IRectangleIntersectionService), new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory()));
                DoNotMock.Add(typeof(IRectangle), new Rectangle(new Point(0, 10), new Point(10, 0)));
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Contains(new Rectangle(new Point(4, 4), new Point(6, 6)));
            }

            [Then]
            public void Should_return_true()
            {
                Assert.IsTrue(_result);
            }
        }

        public class When_a_rectangle_is_provided_that_contains_the_initizing_rectangle : BaseTestFixture<ContainmentService>
        {
            private bool _result;

            public When_a_rectangle_is_provided_that_contains_the_initizing_rectangle()
            {
                DoNotMock = new Dictionary<Type, object>();
                DoNotMock.Add(typeof(IRectangleIntersectionService), new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory()));
                DoNotMock.Add(typeof(IRectangle), new Rectangle(new Point(1, 8), new Point(8, 1)));
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Contains(new Rectangle(new Point(0, 10), new Point(10, 0)));
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_a_rectangle_is_provided_that_intersects_initizing_rectangle : BaseTestFixture<ContainmentService>
        {
            private bool _result;

            public When_a_rectangle_is_provided_that_intersects_initizing_rectangle()
            {
                DoNotMock = new Dictionary<Type, object>();
                DoNotMock.Add(typeof(IRectangleIntersectionService), new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory()));
                DoNotMock.Add(typeof(IRectangle), new Rectangle(new Point(0, 10), new Point(10, 0)));
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Contains(new Rectangle(new Point(8, 12), new Point(11, 0)));
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_a_rectangle_is_provided_that_is_not_contained_initizing_rectangle : BaseTestFixture<ContainmentService>
        {
            private bool _result;

            public When_a_rectangle_is_provided_that_is_not_contained_initizing_rectangle()
            {
                DoNotMock = new Dictionary<Type, object>();
                DoNotMock.Add(typeof(IRectangleIntersectionService), new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory()));
                DoNotMock.Add(typeof(IRectangle), new Rectangle(new Point(2, 2), new Point(4, 4)));
            }

            protected override void When()
            {
                _result = SubjectUnderTest.Contains(new Rectangle(new Point(6, 6), new Point(8, 8)));
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }
    }


}