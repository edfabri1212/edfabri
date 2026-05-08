using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.DeleteDesingner;

public record DeleteDesignerCommand(int DesingnerId) : IRequest<int>;