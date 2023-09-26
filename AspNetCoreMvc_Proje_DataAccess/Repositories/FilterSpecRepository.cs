using AspNetCoreMvc_Proje_DataAccess.Context;
using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_DataAccess.Repositories
{
    public class FilterSpecRepository : GenericRepository<FilterSpecs>, IFilterSpecDal
    {
        public FilterSpecRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
