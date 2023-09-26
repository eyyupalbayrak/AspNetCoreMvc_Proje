using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CartDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
