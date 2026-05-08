using EFAA.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.CreateDesigner
{

    public record CreateDesignerCommand(CreateDesignerRequest Request) : IRequest<int>; 

