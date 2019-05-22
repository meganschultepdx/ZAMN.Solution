using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class IndianBeachController : Controller
  {

    [HttpGet("/indianBeach")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
