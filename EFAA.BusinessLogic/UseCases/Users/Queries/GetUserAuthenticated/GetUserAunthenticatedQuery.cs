using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Users.Queries.GetUserAuthenticated;

public record GetUserAuthenticatedQuery(string userName, string password)
    : IRequest<UserResponse>
{
    internal string passaword;
}