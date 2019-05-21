using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class ClatsopLoopController : Controller
  {

    [HttpGet("/clatsopLoop")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
