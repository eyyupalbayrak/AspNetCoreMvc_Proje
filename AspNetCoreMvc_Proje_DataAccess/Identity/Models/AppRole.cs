using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMvc_Proje_Entity.Entities.Identity.Models
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
