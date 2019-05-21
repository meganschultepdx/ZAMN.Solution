using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class CascadeHeadController : Controller
  {

    [HttpGet("/cascadeHead")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
