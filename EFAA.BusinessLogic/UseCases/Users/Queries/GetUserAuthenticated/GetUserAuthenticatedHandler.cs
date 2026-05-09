using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Users.Specifications;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Users.Queries.GetUserAuthenticated;

internal sealed class GetUserAuthenticatedHandler(IEfRepository<User> _repository)
    : IRequestHandler<GetUserAuthenticatedQuery, UserResponse>
{
    public async Task<UserResponse> Handle(GetUserAuthenticatedQuery query, CancellationToken cancellationToken)
    {
        var user = await _repository
            .FirstOrDefaultAsync(
            new GetUserAuthenticatedSpec(query.userName,query.passaword),
            cancellationToken
            );
        if (user is null)
        {
            return new UserResponse();
        }

        return user.Adapt<UserResponse>();
    }
}