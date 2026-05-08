using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Garments.Commands.CreateGarment;

internal sealed class CreateGarmentHandler(IEfRepository<Garment> _repository)
    : IRequestHandler<CreateGarmentCommand, long>
{
    public async Task<long> Handle(CreateGarmentCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var words = command.Request.GarmentCode.Split(' ');
            var prefix = string.Concat(words[0][0], words.Length > 1 ? words[1][0] : 'X').ToUpper();

            var lastGarment = await _repository.FirstOrDefaultAsync(new GetLastGarmentCodeSpec(prefix), cancellationToken);

            int newNumber = 1;

            if (lastGarment != null && !string.IsNullOrEmpty(lastGarment.GarmentCode))
            {
                var numberPart = lastGarment.GarmentCode.Substring(prefix.Length); //PD0005
                if (int.TryParse(numberPart, out int lastNumber))
                {
                    newNumber = lastNumber + 1;
                }
            }

            command.Request.GarmentCode = $"{prefix}{newNumber:D4}"; // TX0002

            var newGarment = command.Request.Adapt<Garment>();
            var createdGarment = await _repository.AddAsync(newGarment, cancellationToken);
            return createdGarment.GarmentId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}