using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Entities
{
    public class SaleDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SaleId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
