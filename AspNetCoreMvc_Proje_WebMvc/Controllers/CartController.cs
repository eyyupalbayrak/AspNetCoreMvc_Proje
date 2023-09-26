using AspNetCoreMvc_Proje_Entity.Entities;
using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using AspNetCoreMvc_Proje_WebMvc.SessionExtensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_Proje_WebMvc.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartLineService _cartLineService;

        public CartController(IProductService productService, ICartLineService cartLineService)
        {
            _productService = productService;
            _cartLineService = cartLineService;
        }
        List<CartLineViewModel> Cart;


        public IActionResult Index()
        {
            Cart = GetCart();
            ViewBag.total = _cartLineService.TotalPrince(Cart);
            return View(Cart);
        }
        public void AddCart(int id,int quantity)
        {
            Cart = GetCart();
            Cart = _cartLineService.AddCart(Cart,id,quantity);
            SaveCart(Cart);
        }
        public List<CartLineViewModel> GetCart()
        {
            var cart = HttpContext.Session.GetJson<List<CartLineViewModel>>("cart") ?? new List<CartLineViewModel>();
            return cart;
        }
        public IActionResult DeleteCart(int id)
        {
            Cart = GetCart();
            Cart = _cartLineService.RemoveCart(Cart, id);
            SaveCart(Cart);
            return RedirectToAction("Index");
        }
        public void SaveCart(List<CartLineViewModel> cartline)
        {
            HttpContext.Session.SetJson("cart", cartline);
        }
        public IActionResult DropdownRefresh()
        {
            Cart = GetCart();
            ViewBag.total = _cartLineService.TotalPrince(Cart);
            return ViewComponent("CartDropdown", Cart);
        }
        public IActionResult CartCount()
        {
            int count = GetCart().Count();
            return ViewComponent("CartCount",count);
        }
    }
}
