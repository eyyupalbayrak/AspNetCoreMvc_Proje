using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Entities.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_Proje_DataAccess.Context
{
    public class ECommerceDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ECommerceDbContext(DbContextOptions options) : base(options) { }

        DbSet<Products> Products { get; set; }
        DbSet<ProductSpecs> ProductSpecs { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartLine> CartLines { get; set; }
        DbSet<Sale> Sale { get; set; }
        DbSet<SaleDetails> SaleDetails { get; set; }
        DbSet<FilterSpecs> FilterSpecs { get; set; }



    }
}
