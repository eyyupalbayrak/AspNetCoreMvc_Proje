using AspNetCoreMvc_Proje_Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_Proje_WebMvc.ViewComponents.MainSlider.MainSliderAllProducts
{
    public class MainSliderAllProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public MainSliderAllProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _productService.GetListAllByFilter(x => x.Status == true, x => x.Category);
            return View(values);
        }
    }
}
