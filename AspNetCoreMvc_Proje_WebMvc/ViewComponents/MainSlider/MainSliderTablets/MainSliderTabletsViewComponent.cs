using AspNetCoreMvc_Proje_Entity.Services;
using AspNetCoreMvc_Proje_Entity.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_Proje_WebMvc.ViewComponents.MainSlider.MainSliderTablets
{
    public class MainSliderTabletsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public MainSliderTabletsViewComponent(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var values = _productService.GetListAllByFilter(x => x.Status == true && x.CategoryId == 2, c => c.Category);
            return View(values);
        }
    }
}
