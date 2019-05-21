using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class CapeKiwandaController : Controller
  {

    [HttpGet("/capeKiwanda")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
