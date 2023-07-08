using Microsoft.AspNetCore.Mvc;
using Points.Interfaces;

namespace Points.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPoints()
        {
            return Json(repository.GetPoints());
        }

        [HttpPost]
        public JsonResult DeletePoint(int id)
        {
            if (repository.DeletePointById(id))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}