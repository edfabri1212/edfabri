using Ardalis.Specification.EntityFrameworkCore;
using EFAA.DataAccess.Interfaces;
using EFAA.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.DataAccess.Repositories
{
    public class EfRepository<T> : RepositoryBase<T>, IEfRepository<T> where T : class
    {
        private readonly QuotationContext _context;
        private IDbContextTransaction? _transaction;

        public EfRepository(QuotationContext context) : base(context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return;
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                return;
            }
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public Task<T?> FirstOrDefaultAsync(BusinessLogic.UseCases.Garments.Commands.CreateGarment.GetLastGarmentCodeSpec getLastGarmentCodeSpec)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FirstOrDefaultAsync(BusinessLogic.UseCases.Garments.Specifications.GetGarmentWithDesignerSpec getGarmentWithDesignerSpec, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Garment> GetByIdAsync(object garmentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAsync(BusinessLogic.UseCases.Garments.Specifications.GetGarmentWithDesignerSpec getGarmentWithDesignerSpec, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                return;
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}