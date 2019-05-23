using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class HikesController : Controller
  {
    [HttpGet("/hikes")]
    public ActionResult Index()
    {
      List<Hike> allHikes = Hike.GetAll();
      return View(allHikes);
    }

    [HttpGet("/hikes/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/hikes")]
    public ActionResult Create(string name, string address, string type, string description)
    {
      Hike newHike = new Hike(name, address, type, description);
      newHike.Save();
      List<Hike> allHikes = Hike.GetAll();
      return View("Index", allHikes);
    }

    [HttpPost("/hikes/delete")]
    public ActionResult DeleteAll()
    {
      Hike.ClearAll();
      return View();
    }
  }

}
