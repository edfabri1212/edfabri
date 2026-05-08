using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Garments.Commands.CreateGarment;

public record CreateGarmentCommand(CreateGarmentRequest Request) : IRequest<long>;

