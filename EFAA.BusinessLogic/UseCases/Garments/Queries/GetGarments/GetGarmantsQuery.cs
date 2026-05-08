using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Garments.Queries.GetGarments;

public record GetGarmentsQuery() : IRequest<List<GarmantResponse>>;

    