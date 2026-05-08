using EFAA.BusinessLogic.UseCases.Designers.Commands.UpdateDesingner;
using EFAA.DataAccess.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.DeleteDesingner;

internal sealed class DeleteDesignersHandler(IEfRepository<Desingner> _repository)
    : IRequestHandler<DeleteDesignerCommand, int>
{
    public async Task<int> Handle(DeleteDesignerCommand command, CancellationToken cancellationToken)
    {
        var existingDesingner = await _repository.GetByIdAsync(command.DesingnerId);

        if (existingDesingner is null) return 0;

        await _repository.DeleteAsync(existingDesingner, cancellationToken);

        return existingDesingner.DesignerId;
    }
}
