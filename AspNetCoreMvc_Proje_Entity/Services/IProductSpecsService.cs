using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Services
{
    public interface IProductSpecsService : IGenericService<ProductSpecs>
    {
        public List<ProductSpecsViewModel> GetAll();
        public ProductSpecsViewModel GetById(int id);
        public IEnumerable<ProductSpecsViewModel> GetListAllByFilter(Expression<Func<ProductSpecs, bool>> filter, params Expression<Func<ProductSpecs, object>>[] includes);

    }
}
