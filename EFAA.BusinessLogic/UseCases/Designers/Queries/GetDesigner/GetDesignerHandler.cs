using EFAA.BusinessLogic.DTOs;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigner;

internal sealed class GetDesignerHandler(IEfRepository<Designer> repository)
    : IRequestHandler<GetDesignerQuery, DesignerResponse>
{
    public async Task<DesignerResponse> Handle(GetDesignerQuery request, CancellationToken cancellationToken)
    {
        var designer = await _repository.GetByIdAsync(Query.designerId, cancellationToken);

        if (designer is null)
        {
            return new DesignerResponse();
        }

        return designer.Adapt<DesignerResponse>();
    }
}