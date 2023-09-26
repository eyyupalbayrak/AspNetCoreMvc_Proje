using AspNetCoreMvc_Proje_Entity.ViewModels;
using AspNetCoreMvc_Proje_Entity.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc_Proje_Entity.Entities;

namespace AspNetCoreMvc_Proje_WebMvc.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductSpecsService _productSpecsService;
        private readonly IMapper _mapper;
        private readonly IFilterSpecService _filterSpecService;

        public UrunlerController(IProductService productService, IMapper mapper, IProductSpecsService productSpecsService, IFilterSpecService filterSpecService)
        {
            _productService = productService;
            _mapper = mapper;
            _productSpecsService = productSpecsService;
            _filterSpecService = filterSpecService;
        }

        public IActionResult Index(int? id, string[]? value)
        {
            

            var products = _productService.GetListAllByFilter(x => x.Status == true && x.CategoryId == id);
            
            if (value.Count() > 0)
            {
                var specs = _productSpecsService.GetAll();
                List<Products> list = new List<Products>();
                foreach (var item in value)
                {
                    foreach (var spec in specs)
                    {
                        if (spec.Value == item)
                        {
                            //list.Add(products.Where(x => x.Id == spec.ProductId).FirstOrDefault());
                        }
                    }
                }
                ViewBag.specs = _filterSpecService.GetListAllByFilter(x => x.CategoryId == id);
                return View(_mapper.Map<List<ProductViewModel>>(list));
            }



            ViewBag.specs = _filterSpecService.GetListAllByFilter(x => x.CategoryId == id);
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
    }
}
