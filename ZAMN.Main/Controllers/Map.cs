using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class MapController : Controller
  {

    [HttpGet("/map")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
