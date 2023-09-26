using AspNetCoreMvc_Proje_DataAccess.Context;
using AspNetCoreMvc_Proje_DataAccess.Repositories;
using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using AspNetCoreMvc_Proje_Entity.UnitOfWorks;

namespace AspNetCoreMvc_Proje_DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly ECommerceDbContext _context;
        private bool disposed = false;
        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public IGenericDal<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
        }
        public ICartLineDal GetCartLineRepository()
        {
            return new CartLineRepository(_context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICartDal GetCartRepository()
        {
            return new CartRepository(_context);
        }

        public IProductDal GetProductRepository()
        {
            return new ProductRepository(_context);
        }

        public IProductSpecsDal GetProductSpecsRepository()
        {
            return new ProductSpecsRepository(_context);
        }

        public IFilterSpecDal GetFilterSpecsRepository()
        {
            return new FilterSpecRepository(_context);
        }

        public ICategoryDal GetCategoryRepository()
        {
            return new CategoryRepository(_context);
        }

        public ISaleDal GetSaleRepository()
        {
            return new SaleRepository(_context);
        }

        public ISaleDetailsDal GetSaleDetailsRepository()
        {
            return new SaleDetailsRepository(_context);
        }
    }
}
