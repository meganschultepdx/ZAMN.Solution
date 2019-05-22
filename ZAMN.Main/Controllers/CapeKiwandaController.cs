using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

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
