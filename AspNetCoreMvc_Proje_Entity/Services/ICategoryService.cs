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
    public interface ICategoryService : IGenericService<Categories>
    {
        public List<CategoryViewModel> GetAll();
        public CategoryViewModel GetById(int id);
        public IEnumerable<CategoryViewModel> GetListAllByFilter(Expression<Func<Categories, bool>> filter, params Expression<Func<Categories, object>>[] includes);
    }
}
