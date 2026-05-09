using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigner;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Users.Queries.GetRoles
{
    internal sealed class GetRolesHandler(IEfRepository<Role> repository)
        : IRequestHandler<GetRolesQuery, List<RoleResponse>>
    {
        public async Task<List<RoleResponse>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
        {
            var roles = await _repository.ListAsync(cancellationToken);

            if (roles == null || !roles.Any())
            {
                return new List<RoleResponse>();
            }

            return roles.Adapt<List<RoleResponse>>();
        }
    }
}
