using Microsoft.Practices.Unity;
using vanBrackel.Rectangles.Domain.Factories;
using vanBrackel.Rectangles.Services;
using vanBrackel.Rectangles.UI.IoC;
using vanBrackel.Rectangles.UI.Services;

namespace vanBrackel.Rectangles.UI.Setup
{
    public class UnityBootstrapper
    {
         public static void Setup(IUnityContainer container)
         {
             container
                 .RegisterType<IAdjacencyService, AdjacenyService>()
                 .RegisterType<IContainmentService, ContainmentService>()
                 .RegisterType<ILineIntersectionService, LineIntersectionService>()
                 .RegisterType<IRectangleIntersectionService, RectangleIntersectionService>()
                 .RegisterType<IRectangleDecomposer, RectangleDecomposer>()
                 .RegisterType<IShapeFactory, ShapeFactory>()
                 .RegisterType<IComparisonService, ComparisonService>()
                 .RegisterInstance(typeof (IDependencyResolver), DependencyResolver.GetInstance());
         }

    }
}