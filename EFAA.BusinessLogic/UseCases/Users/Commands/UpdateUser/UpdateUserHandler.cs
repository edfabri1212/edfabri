using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFAA.BusinessLogic.UseCases.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserHandler(IEfRepository<User> _repository)
        : IRequestHandler<UpdateUserCommand, int>
    {
        private object command;

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _repository.GetByIdAsync(command.Request.UserId, cancellationToken);
                if (existingUser is null) return 0;

                existingUser = command.Request.Adapt(existingUser);

                await _repository.UpdateAsync(existingUser, cancellationToken);

                return existingUser.UserId;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}