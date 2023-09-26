using AspNetCoreMvc_Proje_Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.UnitOfWorks
{
    public interface IUnitOfWorks : IDisposable
    {
        IGenericDal<T> GetRepository<T>() where T : class, new();
        void Commit();
        Task CommitAsync();
        ICartLineDal GetCartLineRepository();
        ICartDal GetCartRepository();
        IProductDal GetProductRepository();
        IProductSpecsDal GetProductSpecsRepository();
        IFilterSpecDal GetFilterSpecsRepository();
        ICategoryDal GetCategoryRepository();
        ISaleDal GetSaleRepository();
        ISaleDetailsDal GetSaleDetailsRepository();

    }
}
