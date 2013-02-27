using NUnit.Framework;
using vanBrackel.Rectangles.UI.IoC;

namespace Specifications.UI.IoC
{
    public class DependencyResolverSpecs
    {
        [Test]
        public void Should_only_have_one_instance()
        {
            var subjectUnderTest = DependencyResolver.GetInstance();
            var theSame = DependencyResolver.GetInstance();

            Assert.AreSame(theSame, subjectUnderTest);
        }
    }
}
