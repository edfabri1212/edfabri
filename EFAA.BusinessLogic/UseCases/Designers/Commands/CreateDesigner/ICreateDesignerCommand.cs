using EFAA.BusinessLogic.DTOs;

namespace EFAA.BusinessLogic.UseCases.Designers.Commands.CreateDesigner
{
    public interface ICreateDesignerCommand
    {
        CreateDesignerRequest Request { get; init; }

        void Deconstruct(out CreateDesignerRequest Request);
        bool Equals(CreateDesignerCommand? other);
        bool Equals(object? obj);
        int GetHashCode();
        string ToString();
    }
}