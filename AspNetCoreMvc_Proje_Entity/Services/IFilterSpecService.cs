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
    public interface IFilterSpecService : IGenericService<FilterSpecs>
    {
        public List<FilterSpecsViewModel> GetAll();
        public FilterSpecsViewModel GetById(int id);
        public IEnumerable<FilterSpecsViewModel> GetListAllByFilter(Expression<Func<FilterSpecs, bool>> filter, params Expression<Func<FilterSpecs, object>>[] includes);
    }
}
