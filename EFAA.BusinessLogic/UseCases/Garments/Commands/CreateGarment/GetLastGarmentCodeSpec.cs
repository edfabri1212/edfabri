using Ardalis.Specification;
using EFAA.Entities;

namespace EFAA.BusinessLogic.UseCases.Garments.Commands.CreateGarment
{
    internal class GetLastGarmentCodeSpec : ISpecification<Garment>
    {
        public GetLastGarmentCodeSpec(string prefix)
        {
            Prefix = prefix;
        }

        public string Prefix { get; }
    }
}