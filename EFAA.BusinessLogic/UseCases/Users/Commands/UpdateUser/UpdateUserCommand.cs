using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Users.Commands.UpdateUser;

public record UpdateUserCommand(UpdateUserRequest Request) : IRequestHandler<int>;
