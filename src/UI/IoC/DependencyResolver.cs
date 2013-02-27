using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using vanBrackel.Rectangles.UI.Setup;

namespace vanBrackel.Rectangles.UI.IoC
{
    public class DependencyResolver : IDependencyResolver
    {
        private static IDependencyResolver _resolver;
        private static UnityContainer _container;
        private DependencyResolver()
        {
            
        }

        public static IDependencyResolver GetInstance()
        {
            return _resolver = _resolver ?? new DependencyResolver();
        }

        public T Resolve<T>(params KeyValuePair<string, object>[] parameters)
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                UnityBootstrapper.Setup(_container);
            }

            if(parameters == null)
                return _container.Resolve<T>();

            var overrides = new ResolverOverride[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                overrides[i] = new ParameterOverride(parameters[i].Key, parameters[i].Value);
            }
            return _container.Resolve<T>(overrides);
        }
    }
}