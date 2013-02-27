using System;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Domain.Shapes;
using vanBrackel.Rectangles.Services;
using vanBrackel.Rectangles.UI.IoC;
using vanBrackel.Rectangles.UI.Services;
using vanBrackel.Rectangles.UI.Setup;

namespace Specifications.UI.Setup
{
    public class UnityBootstrapperSpecs
    {
        public class When_setting_up_a_UnityContainer : BaseTestFixture
        {
            private IUnityContainer _container;

            protected override void Given()
            {
                _container = new UnityContainer();
                base.Given();
            }

            protected override void When()
            {
                UnityBootstrapper.Setup(_container);
            }

            [Then]
            public void Should_have_registered_AdjacenyService()
            {
                Assert.IsInstanceOf<AdjacenyService>(_container.Resolve<IAdjacencyService>());
            }

            [Then]
            public void Should_have_registered_ContainmentService()
            {
                Assert.IsInstanceOf<ContainmentService>(_container.Resolve<IContainmentService>(new ParameterOverride("outerRectangle", new Rectangle(new Point(1,1), new Point(2,2)))));
            }

            [Then]
            public void Should_have_registered_LineIntersectionService()
            {
                Assert.IsInstanceOf<ILineIntersectionService>(_container.Resolve<LineIntersectionService>());
            }

            [Then]
            public void Should_have_registered_RectangleIntersectionService()
            {
                Assert.IsInstanceOf<RectangleIntersectionService>(_container.Resolve<IRectangleIntersectionService>());
            }

            [Then]
            public void Should_have_registered_RectangleDecomposer()
            {
                Assert.IsInstanceOf<RectangleDecomposer>(_container.Resolve<IRectangleDecomposer>());
            }

            [Then]
            public void Should_have_registered_ShapeFactory()
            {
                Assert.IsInstanceOf<ShapeFactory>(_container.Resolve<IShapeFactory>() );
            }

            [Then]
            public void Should_have_registered_ComparisonService()
            {
                Assert.IsInstanceOf<ComparisonService>(_container.Resolve<IComparisonService>());
            }

            [Then]
            public void Should_have_registered_DependencyResolver()
            {
                Assert.IsInstanceOf<DependencyResolver>(_container.Resolve<IDependencyResolver>());
            }
        }
    }
}
