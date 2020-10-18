using Microsoft.AspNetCore.Mvc;

namespace CSERP.WEB.Areas.HRM.Controllers
{
    [Area("HRM")]
    public class HRMBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}