using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;

namespace Specifications.Services
{
    public class RectangleDecomposerSpecs 
    {
        public class When_passed_a_rectangle : BaseTestFixture<RectangleDecomposer>
        {
            private Rectangle _testRectangle;
            private List<ILine> _result;

            protected override void Given()
            {
                _testRectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
                base.Given();
            }

            protected override void When()
            {
                _result = SubjectUnderTest.GetLines(_testRectangle).ToList();
            }
            
            [Then]
            public void Should_decompose_rectangle_into_a_set_of_lines()
            {
                Assert.AreEqual(4, _result.Count);

                foreach (var line in _result)
                {
                    Assert.IsInstanceOf<ILine>(line);
                }
            }
        }
    }
}
