using Microsoft.AspNetCore.Mvc;

namespace Casgem_Consume_Api.Controllers
{
    public class AboutController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
