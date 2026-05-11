using EFAA.BusinessLogic.DTOs;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Garments.Queries.GetGarment
{
    internal sealed class GetGarmentHandler(IEfRepository<Garment> _repository) : IRequestHandler<GetGarmentQuery, GarmentResponse>
    {
        public async Task<GarmentResponse> Handle(GetGarmentQuery query, CancellationToken cancellationToken)
        {
            var garment = await _repository.GetByIdAsync(query.garmentId, cancellationToken);

            if (garment is null)
            {
                return new GarmentResponse();
            }

            return garment.Adapt<GarmentResponse>();
        }
    }
}