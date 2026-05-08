using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesingners;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigners;

internal sealed class GetDesignerHandler(IEfRepository<Designer> repository)
    : IRequestHandler<GetDesignersQuery, List<DesignerResponse>>
{
    private object _repository;

    public async Task<List<DesignerResponse>> Handle(GetDesignersQuery query, CancellationToken cancellationToken)
    {
        var Designer = await _repository.ListAsync(cancellationToken);

        if (Designer == null || !Designer.Any())
        {
            return new List<DesignerResponse>();
        }

        return Designer.Adapt<List<DesignerResponse>>();
    }
}