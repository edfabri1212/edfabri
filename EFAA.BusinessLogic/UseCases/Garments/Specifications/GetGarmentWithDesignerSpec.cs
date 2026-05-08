using Ardalis.Specification;
using EFAA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Garments.Specifications
{
    public class GetGarmentWithDesignerSpec : Specification<Garment>
    {
        public GetGarmentWithDesignerSpec(){
            Query.Include(g => g.Garment);
        }
    }

}

