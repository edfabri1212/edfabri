using EFAA.BusinessLogic.DTOs;
using MediatR;

namespace EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesingners;

public record GetDesignersQuery() : IRequest<List<DesignerResponse>>;

