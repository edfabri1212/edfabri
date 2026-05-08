using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.CreateDesigner;

internal sealed class CreateDesignerHandler(IEfRepository<Designer> repository)
    : IRequestHandler<CreateDesignerCommand, int>
{
    private object _repository;

    public async Task<int> Handle(CreateDesignerCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newDesigner = command.Request.Adapt<Designer>();

            var createdDesigner = await _repository.AddAsync(newDesigner, cancellationToken);

            return createdDesigner.DesignerId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}

