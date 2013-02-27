using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vanBrackel.Rectangles.Domain;
using vanBrackel.Rectangles.Domain.Shapes;

namespace vanBrackel.Rectangles.Services
{
    public interface IContainmentService
    {
        bool Contains(IRectangle rectangle);
    }
}
