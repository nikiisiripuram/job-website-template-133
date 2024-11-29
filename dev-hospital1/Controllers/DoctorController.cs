using Microsoft.AspNetCore.Mvc;

namespace dev_hospital1.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
