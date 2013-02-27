using NUnit.Framework;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;

namespace Specifications.Services
{
    public class IntersectionResultSpecs
    {
        [Test]
        public void Should_set_HasIntersection_and_IntersectionPoints_from_Constructor()
        {
            var points = new Point[2];
            var hasIntersection = true;

            var sut = new IntersectionResult(hasIntersection, points);

            Assert.AreEqual(hasIntersection, sut.HasIntersection);
            for (var i = 0; i < points.Length; i++)
            {
                Assert.AreEqual(points[i], sut.IntersectionPoints[i]);
            }
        }
    }
}