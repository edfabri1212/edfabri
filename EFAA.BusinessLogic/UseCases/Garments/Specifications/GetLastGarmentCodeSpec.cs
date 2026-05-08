using Ardalis.Specification;
using EFAA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Garments.Specifications
{
    public class GetLastGarmentCodeSpec : Specification<Garment>
    {
        public GetLastGarmentCodeSpec(string preflix) {
            Query.Where(g => g.GarmentCode != null && g.GarmentCode.StartsWith(preflix))
                .OrderByDescending(g => g.GarmentCode);
        }
    }
}
