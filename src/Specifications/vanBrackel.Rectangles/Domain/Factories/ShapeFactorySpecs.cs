using System;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;

namespace Specifications.Domain.Factories
{
    public class ShapeFactorySpecs
    {
        public class When_creating_a_rectangle : BaseTestFixture<ShapeFactory>
        {
            private IRectangle _result;

            protected override void When()
            {
                _result = SubjectUnderTest.CreateRectangle(10, 0, 0, 10);
            }

            [Test]
            public void Should_create_rectangle_from_top_left_corner_to_bottom_right_corner()
            {
                Assert.AreEqual(10, _result.StartingPoint.YCoordinate);
                Assert.AreEqual(0, _result.StartingPoint.XCoordinate);
                Assert.AreEqual(0, _result.EndingPoint.YCoordinate);
                Assert.AreEqual(10, _result.EndingPoint.XCoordinate);
            }
        }

        public class When_creating_a_rectangle_with_coordinates_that_draw_a_line : BaseTestFixture<ShapeFactory>
        {
            private IRectangle _result;

            protected override void When()
            {
                _result = SubjectUnderTest.CreateRectangle(0, 0, 0, 10);
            }

            [Test]
            public void Should_throw_an_argument_exception_with_a_bad_shape_message()
            {
                Assert.IsInstanceOf<ArgumentException>(CaughtException);
                Assert.AreEqual(vanBrackel_Rectangles_Resources.BadShapeError, CaughtException.Message);
            }
        }

        public class When_creating_a_line : BaseTestFixture<ShapeFactory>
        {
            private ILine _result;

            protected override void When()
            {
                _result = SubjectUnderTest.CreateLine(10, 0, 0, 1);
            }

            [Test]
            public void Should_create_line_from_left_to_right()
            {
                Assert.AreEqual(1, _result.StartingPoint.YCoordinate);
                Assert.AreEqual(0, _result.StartingPoint.XCoordinate);
                Assert.AreEqual(0, _result.EndingPoint.YCoordinate);
                Assert.AreEqual(10, _result.EndingPoint.XCoordinate);
            }
        }

        public class When_creating_a_line_with_coordinates_that_draw_a_point : BaseTestFixture<ShapeFactory>
        {
            private ILine _result;

            protected override void When()
            {
                _result = SubjectUnderTest.CreateLine(0, 0, 0, 0);
            }

            [Test]
            public void Should_throw_an_argument_exception_with_a_bad_shape_message()
            {
                Assert.IsInstanceOf<ArgumentException>(CaughtException);
                Assert.AreEqual(vanBrackel_Rectangles_Resources.BadShapeError, CaughtException.Message);
            }
        }

    }
}
