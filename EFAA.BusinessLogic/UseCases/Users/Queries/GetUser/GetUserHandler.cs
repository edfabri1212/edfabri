using EFAA.BusinessLogic.DTOs;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace EFAA.BusinessLogic.UseCases.Users.Queries.GetUser;

internal sealed class GetUserHandler(IEfRepository<User> _repository)
    : IRequestHandler<GetUserQuery, UserByIdResponse>
{
    public async Task<UserByIdResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(Query.userId, cancellationToken);

        if (user is null)
        {
            return new UserByIdResponse();
        }
        return user.Adapt<UserByIdResponse>();
    }
}