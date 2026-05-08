using EFAA.BusinessLogic.DTOs;
using EFAA.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace EFAA.BusinessLogic.Mappings
{
    public class MappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Garment, GarmentResponse>()
                .Map(pd => pd.GarmentName, p => p.Garment.GarmentName);
        }
    }
}
