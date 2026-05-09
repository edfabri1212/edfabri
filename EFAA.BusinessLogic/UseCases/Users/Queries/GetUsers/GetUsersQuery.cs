using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<List<UserResponse>>;
