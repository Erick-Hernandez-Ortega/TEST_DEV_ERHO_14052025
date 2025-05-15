using FrontPruebaToka.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontPruebaToka.Controllers
{
    public class ReportsController : Controller
    {

        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }
    }
}
