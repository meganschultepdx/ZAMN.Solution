using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        // return View(Item.GetAll());
        return View();
      }

    }
}
