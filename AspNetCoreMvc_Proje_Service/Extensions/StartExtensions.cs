using AspNetCoreMvc_Proje_DataAccess.Repositories;
using AspNetCoreMvc_Proje_Entity.Interfaces;
using AspNetCoreMvc_Proje_Service.Manager;
using AspNetCoreMvc_Proje_Entity.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AspNetCoreMvc_Proje_Entity.UnitOfWorks;
using AspNetCoreMvc_Proje_DataAccess.UnitOfWorks;
using AspNetCoreMvc_Proje_Entity.Entities.Identity.Models;
using AspNetCoreMvc_Proje_DataAccess.Context;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMvc_Proje_Service.Extensions
{
    public static class StartExtensions
    {
        public static void ScopeExtensions(this IServiceCollection services)
        {

            services.AddIdentity<AppUser, AppRole>(
            opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.MaxFailedAccessAttempts = 3;    //default : 5
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5 dk
            }
            ).AddEntityFrameworkStores<ECommerceDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true; //10 dk dolmadan kullanıcı login olursa süre baştan başlar.
                opt.Cookie = new CookieBuilder()
                {
                    Name = "Identity.App.Cookie",
                    HttpOnly = true
                };
            });




            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, ProductRepository>();
            services.AddScoped<IProductSpecsDal, ProductSpecsRepository>();
            services.AddScoped<IProductSpecsService, ProductSpecsManager>();
            services.AddScoped<ICartDal,CartRepository>();
            services.AddScoped<ICartService,CartManager>();
            services.AddScoped<ICartLineService,CartLineManager>();
            services.AddScoped<ICartLineDal,CartLineRepository>();
            services.AddScoped<IFilterSpecService,FilterSpecManager>();
            services.AddScoped<IFilterSpecDal,FilterSpecRepository>();
            services.AddScoped<IUnitOfWorks,UnitOfWork>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IAccountService),typeof(AccountService));
        }
    }
}
