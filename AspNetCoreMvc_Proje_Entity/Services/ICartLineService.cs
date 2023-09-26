using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Services
{
    public interface ICartLineService : IGenericService<CartLine>
    {
        public List<CartLineViewModel> AddCart(List<CartLineViewModel> cartline, int id, int quantity);
        public List<CartLineViewModel> RemoveCart(List<CartLineViewModel> cartline, int id);
        public decimal TotalPrince(List<CartLineViewModel> cartline);
    }
}
