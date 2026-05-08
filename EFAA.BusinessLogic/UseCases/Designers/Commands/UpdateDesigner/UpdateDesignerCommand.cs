using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.UpdateDesingner;

public record UpdateDesignerCommand(UpdateDesignerRequest Request) : IRequest<int>;