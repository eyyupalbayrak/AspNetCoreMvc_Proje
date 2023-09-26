using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using AspNetCoreMvc_Proje_WebMvc.SessionExtensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_Proje_WebMvc.ViewComponents.CartDropdown
{
    public class CartDropdownViewComponent : ViewComponent
    {
        private readonly ICartLineService _cartLineService;

        public CartDropdownViewComponent(ICartLineService cartLineService)
        {
            _cartLineService = cartLineService;
        }

        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.GetJson<List<CartLineViewModel>>("cart") ?? new List<CartLineViewModel>();
            ViewBag.total = _cartLineService.TotalPrince(cart);
            return View(cart.TakeLast(3).ToList());
        }
    }
}
