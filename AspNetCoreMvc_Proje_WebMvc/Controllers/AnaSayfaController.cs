using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_Proje_WebMvc.Controllers
{
    public class AnaSayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
