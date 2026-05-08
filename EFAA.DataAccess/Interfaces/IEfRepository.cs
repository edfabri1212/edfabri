using Ardalis.Specification;
using EFAA.Entities;

namespace EFAA.DataAccess.Interfaces
{
    public interface IEfRepository<T> : IRepositoryBase<T>
        where T : class
    {
        Task BeginTransactionAsync();

        Task CommitAsync();

        Task<T?> FirstOrDefaultAsync(
            BusinessLogic.UseCases.Garments.Commands.CreateGarment.GetLastGarmentCodeSpec getLastGarmentCodeSpec);

        Task<T?> FirstOrDefaultAsync(
            BusinessLogic.UseCases.Garments.Specifications.GetGarmentWithDesignerSpec getGarmentWithDesignerSpec,
            CancellationToken cancellationToken);

        Task<T?> GetByIdAsync();

        Task<Garment> GetByIdAsync(
            object garmentId,
            CancellationToken cancellationToken);

        Task<List<T>> ListAsync(
            BusinessLogic.UseCases.Garments.Specifications.GetGarmentWithDesignerSpec getGarmentWithDesignerSpec,
            CancellationToken cancellationToken);

        Task RollbackAsync();
    }
}
