using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual List<SaleDetails> SaleDetails { get; set; }
    }
}
