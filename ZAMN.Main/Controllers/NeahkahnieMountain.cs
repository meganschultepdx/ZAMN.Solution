using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class NeahkahnieMountainController : Controller
  {

    [HttpGet("/neahkahnieMountain")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
