using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigner;

public record GetDesignerQuery(int DesignerId) : IRequest<DesignerResponse>;


