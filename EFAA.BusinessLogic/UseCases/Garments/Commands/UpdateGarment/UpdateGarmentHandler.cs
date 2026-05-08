using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Garments.Commands.UpdateGarment
{
    internal sealed class UpdateGarmentHandler(IEfRepository<Garment> _repository) : IRequestHandler<UpdateGarmentCommand, long>
    {
        public async Task<long> Handle(UpdateGarmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingGarment = await _repository.GetByIdAsync(command.Request.GarmentId, cancellationToken);
                if (existingGarment is null) return 0;

                existingGarment = command.Request.Adapt(existingGarment);
                await _repository.UpdateAsync(existingGarment, cancellationToken);

                return existingGarment.GarmentId;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}

