using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.DataAccess.Interfaces
{
    public interface IEfRepository<T> : IRepositoryBase<T> where T : class
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
