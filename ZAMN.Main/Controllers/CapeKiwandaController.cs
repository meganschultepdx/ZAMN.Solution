using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class CapeKiwandaController : Controller
  {
    [HttpGet("/capekiwanda")]
    public ActionResult Index()
    {
      List<CapeKiwanda> allCapeKiwandaComments = CapeKiwanda.GetAll();
      return View(allCapeKiwandaComments);
    }

    [HttpGet("/capekiwanda/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/capekiwanda")]
    public ActionResult Create(string userName, string userComment)
    {
      CapeKiwanda newPost = new CapeKiwanda(userName, userComment);
      newPost.Save();
      List<CapeKiwanda> allPosts = CapeKiwanda.GetAll();
      return View("Index", allPosts);
    }

    [HttpPost("/capekiwanda/delete")]
    public ActionResult DeleteAll()
    {
      CapeKiwanda.ClearAll();
      return View();
    }
  }
}
