using Microsoft.AspNetCore.Mvc;
using Points.Interfaces;
using System.Threading.Tasks;

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
        public async Task<JsonResult> GetPointsAsync()
        {
            var points = await repository.GetPointsAsync();
            return Json(points);
        }

        [HttpPost]
        public async Task<JsonResult> DeletePointAsync(int pointId)
        {
            if (await repository.DeletePointByIdAsync(pointId))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}