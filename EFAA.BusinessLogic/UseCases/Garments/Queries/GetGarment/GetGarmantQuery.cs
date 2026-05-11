using EFAA.BusinessLogic.DTOs;
using EFAA.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Garments.Queries.GetGarment;

public class GetGarmentQuery(long garmentId) : IRequest<GarmentResponse>
{
    internal object garmentId;

    public object GarmentId { get; internal set; }
}