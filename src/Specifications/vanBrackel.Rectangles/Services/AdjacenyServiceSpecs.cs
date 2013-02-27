using System;
using System.Collections.Generic;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;

namespace Specifications.Services
{
    public class AdjacenyServiceSpecs
    {
        public class When_comparing_two_rectangles_that_intersect : AdjacenyServiceSpecification
        {
            private bool _result;
            private Rectangle _aRectangle;
            private Rectangle _anotherRectangle;

            protected override void Given()
            {
                _aRectangle = new Rectangle(new Point(0,10),  new Point(10,0));
                _anotherRectangle = new Rectangle(new Point(8, 8), new Point(12, 12));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.AreAdjacent(_aRectangle, _anotherRectangle);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_comparing_a_rectangle_outside_another_rectangle : AdjacenyServiceSpecification
        {
            private bool _result;
            private IRectangle _aRectangle;
            private IRectangle _anotherRectangle;

            protected override void Given()
            {
                _aRectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
                _anotherRectangle = new Rectangle(new Point(12, 12), new Point(14, 14));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.AreAdjacent(_aRectangle, _anotherRectangle);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_comparing_a_rectangle_inside_another_rectangle : AdjacenyServiceSpecification
        {
            private bool _result;
            private IRectangle _aRectangle;
            private IRectangle _anotherRectangle;
            
            protected override void Given()
            {
                _aRectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
                _anotherRectangle = new Rectangle(new Point(6, 6), new Point(8, 8));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.AreAdjacent(_aRectangle, _anotherRectangle);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_comparing_a_rectangle_sharing_two_sides_with_another_rectangle : AdjacenyServiceSpecification
        {
            private bool _result;
            private IRectangle _aRectangle;
            private IRectangle _anotherRectangle;

            protected override void Given()
            {
                _aRectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
                _anotherRectangle = new Rectangle(new Point(3, 10), new Point(10, 2));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.AreAdjacent(_aRectangle, _anotherRectangle);
            }

            [Then]
            public void Should_return_false()
            {
                Assert.IsFalse(_result);
            }
        }

        public class When_comparing_a_rectangle_that_is_properly_adjacent : AdjacenyServiceSpecification
        {
            private bool _result;
            private IRectangle _aRectangle;
            private IRectangle _anotherRectangle;
           
            protected override void Given()
            {
                _aRectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
                _anotherRectangle = new Rectangle(new Point(10, 10), new Point(20, 0));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.AreAdjacent(_aRectangle, _anotherRectangle);
            }

            [Then]
            public void Should_return_true()
            {
                Assert.IsTrue(_result);
            }
        }

        public class When_comparing_a_rectangle_that_is_sub_line_adjacent : AdjacenyServiceSpecification
        {
            private bool _result;
            private IRectangle _aRectangle;
            private IRectangle _anotherRectangle;

            protected override void Given()
            {
                _aRectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
                _anotherRectangle = new Rectangle(new Point(10, 8), new Point(12, 6));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.AreAdjacent(_aRectangle, _anotherRectangle);
            }

            [Then]
            public void Should_return_true()
            {
                Assert.IsTrue(_result);
            }
        }
    }

    public abstract class AdjacenyServiceSpecification : BaseTestFixture<AdjacenyService>
    {
        protected AdjacenyServiceSpecification()
        {
            DoNotMock = new Dictionary<Type, object>();
            DoNotMock.Add(typeof(IRectangleDecomposer), new RectangleDecomposer(new ShapeFactory()));
            DoNotMock.Add(typeof(IRectangleIntersectionService), new RectangleIntersectionService(new LineIntersectionService(), new RectangleDecomposer(new ShapeFactory()), new ShapeFactory()));
        }
    }
}
