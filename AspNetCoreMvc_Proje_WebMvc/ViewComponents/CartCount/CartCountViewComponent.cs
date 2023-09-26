using AspNetCoreMvc_Proje_Entity.ViewModels;
using AspNetCoreMvc_Proje_WebMvc.SessionExtensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_Proje_WebMvc.ViewComponents.CartCount
{
    public class CartCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.GetJson<List<CartLineViewModel>>("cart") ?? new List<CartLineViewModel>();
            return View(cart.Count());
        }
    }
}
