using EFAA.BusinessLogic.DTOs;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Users.Queries.GetUsers;

internal sealed class GetUsersHandler(IEfRepository<User> _repository)
    : IRequestHandler<GetUsersQuery, List<UserResponse>>
{
    public async Task<List<UserResponse>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _repository.ListAsync(cancellationToken);

        if (users == null || !users.Any())
        {
            return new List<UserResponse>();
        }
        return users.Adapt<List<UserResponse>>();
    }
}