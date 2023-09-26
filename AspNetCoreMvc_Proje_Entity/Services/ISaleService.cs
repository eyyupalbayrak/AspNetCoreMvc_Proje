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
    public interface ISaleService : IGenericService<Sale>
    {
        public List<SaleViewModel> GetAll();
        public SaleViewModel GetById(int id);
        public IEnumerable<SaleViewModel> GetListAllByFilter(Expression<Func<Sale, bool>> filter, params Expression<Func<Sale, object>>[] includes);
    }
}
