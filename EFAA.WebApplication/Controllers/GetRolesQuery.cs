using MediatR;
using System.Collections;

namespace EFAA.WebApplication.Controllers
{
    internal class GetRolesQuery : IRequest<IEnumerable>
    {
    }
}