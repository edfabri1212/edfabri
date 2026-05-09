using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigner;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFAA.BusinessLogic.UseCases.Users.Commands.CreateUser;

internal sealed class CreateUserHandler(IEfRepository<User> _Repository)
    : IRequestHandler<CreateUserCommand, int>
{
    private object command;

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newUser = command.Request.Adapt<User>();
            var createdUser = await _repository.AddAsync(newUser, cancellationToken);
            return createdUser.UserId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}