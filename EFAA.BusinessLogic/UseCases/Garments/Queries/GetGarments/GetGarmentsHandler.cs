using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Garments.Specifications;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;
using static BusinessLogic.UseCases.Garments.Specifications;

namespace EFAA.BusinessLogic.UseCases.Garments.Queries.GetGarments
{
    internal sealed class GetGarmentsHandler(IEfRepository<Garment> _repository)
        : IRequestHandler<GetGarmentsQuery, List<GarmentsResponse>>
    {
        public async Task<List<GarmentsResponse>> Handle(GetGarmentsQuery request, CancellationToken cancellationToken)
        {
            var garments = await _repository.ListAsync(
                new GetGarmentWithDesignersSpec(),
                cancellationToken);

            if (garments == null || !garments.Any())
            {
                return new List<GarmentsResponse>();
            }

            return garments.Adapt<List<GarmentsResponse>>();
        }
    }
}