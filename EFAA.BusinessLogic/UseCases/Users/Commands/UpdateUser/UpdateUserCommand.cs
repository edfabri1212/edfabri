using EFAA.BusinessLogic.DTOs;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.UpdateDesigner;

public record UpdateDesignerCommand(UpdateDesignerRequest Request) : IRequest<int>;