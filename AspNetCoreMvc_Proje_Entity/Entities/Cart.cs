using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CartDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }

        public virtual List<CartLine> CartLines { get; set; }
    }
}
