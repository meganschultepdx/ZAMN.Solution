using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class ShortSandsController : Controller
  {

    [HttpGet("/shortSands")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
