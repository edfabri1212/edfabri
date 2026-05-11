using Ardalis.Specification;
using EFAA.Entities;

namespace EFAA.BusinessLogic.UseCases.Garments.Commands.CreateGarment
{
    internal class GetLastGarmentCodeSpec : Specification<Garment>
    {
        public GetLastGarmentCodeSpec(string prefix)
        {
            Prefix = prefix;
        }

        public string Prefix { get; }

       
    }
}