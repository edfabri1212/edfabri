using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.UpdateDesingner;

internal sealed class UpdateDesignerHandler(IEfRepository<Designer> _repository)
    : IRequestHandler<UpdateDesignerCommand, int>
{
    public async Task<int> Handle(UpdateDesignerCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingDesingner = await _repository.GetByIdAsync(command.Request.DesignerId);

            if (existingDesingner is null) return 0;

            existingDesingner = command.Request.Adapt(existingDesingner);

            await _repository.UpdateAsync(existingDesingner, cancellationToken);

            return existingDesingner.DesingnerId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
