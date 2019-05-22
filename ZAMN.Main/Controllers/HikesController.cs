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

    // [HttpGet("/hikes/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Hike selectedHike = Hike.Find(id);
    //   List<User> hikeUsers = selectedHike.GetUsers();
    //   List<User> allUsers = User.GetAll();
    //   model.Add("selectedHike", selectedHike);
    //   model.Add("hikeUsers", hikeUsers);
    //   model.Add("allUsers", allUsers);
    //   return View(model);
    // }
    //
    // [HttpPost("/hikes/{hikesId}/users/new")]
    // public ActionResult AddUser(int hikesId, int userId)
    // {
    //   Hike hike = Hike.Find(hikesId);
    //   User user = User.Find(userId);
    //   hike.AddUser(user);
    //   return RedirectToAction("Show",  new { id = hikesId });
    // }

    // [HttpPost("/hikes/{hikesId}/delete-hike")]
    // public ActionResult DeleteHike(int hikeId)
    // {
    //   Hike selectedHike = Hike.Find(hikeId);
    //   selectedHike.DeleteHike(hikeId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   List<Hike> hikeUsers = selectedHike.GetUsers();
    //   model.Add("selectedHike", selectedHike);
    //   return RedirectToAction("Index", "Hikes");
    // }
  }

}
