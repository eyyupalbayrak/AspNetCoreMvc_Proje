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
    public interface ISaleDetailsService : IGenericService<SaleDetails>
    {
        public List<SaleDetailsViewModel> GetAll();
        public SaleDetailsViewModel GetById(int id);
        public IEnumerable<SaleDetailsViewModel> GetListAllByFilter(Expression<Func<SaleDetails, bool>> filter, params Expression<Func<SaleDetails, object>>[] includes);
    }
}
