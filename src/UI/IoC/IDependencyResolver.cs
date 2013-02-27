using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vanBrackel.Rectangles.UI.IoC
{
    public interface IDependencyResolver
    {
        T Resolve<T>(params KeyValuePair<string, object>[] parameters);
    }
}
