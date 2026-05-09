using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserRequest Request) : IRequest<int>;

