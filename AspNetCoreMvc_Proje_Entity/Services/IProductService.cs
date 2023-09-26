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
    public interface IProductService : IGenericService<Products>
    {
        public List<ProductViewModel> GetAll();
        public ProductViewModel GetById(int id);
        public IEnumerable<ProductViewModel> GetListAllByFilter(Expression<Func<Products, bool>> filter, params Expression<Func<Products, object>>[] includes);

    }
}
