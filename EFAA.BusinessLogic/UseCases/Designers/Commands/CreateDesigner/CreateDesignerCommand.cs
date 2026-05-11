using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.CreateDesigner;

public record CreateDesignerCommand(CreateDesignerRequest Request) : IRequest<int>;
