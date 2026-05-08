using EFAA.BusinessLogic.DTOs;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Garments.Commands.UpdateGarment
{
    public record UpdateGarmentCommand(UpdateGarmentRequest Request) : IRequest<long>;

}
