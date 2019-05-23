using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class LoginController : Controller
  {
    // [HttpGet("/login")]
    // public ActionResult Index()
    // {
    //   List<Login> allLogin = Login.GetAll();
    //   return View(allLogin);
    // }

    [HttpGet("/login/new")]
    public ActionResult New()
    {
      return View();
    }

    // [HttpPost("/login")]
    // public ActionResult Create(string description)
    // {
    //   Login newLogin = new Login(description);
    //   newLogin.Save();
    //   List<Login> allLogin = Login.GetAll();
    //   return View("Index", allLogin);
    // }
  }
}
    //
    // [HttpGet("/login/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Login selectedLogin = Login.Find(id);
    //   List<Restaurant> loginRestaurants = selectedLogin.GetRestaurants();
    //   List<Restaurant> allRestaurants = Restaurant.GetAll();
    //   model.Add("selectedLogin", selectedLogin);
    //   model.Add("loginRestaurants", loginRestaurants);
    //   model.Add("allRestaurants", allRestaurants);
    //   return View(model);
    // }
    //
    // [HttpPost("/login/{loginId}/restaurants/new")]
    // public ActionResult AddRestaurant(int loginId, int restaurantId)
    // {
    //   Login login = Login.Find(loginId);
    //   Restaurant restaurant = Restaurant.Find(restaurantId);
    //   login.AddRestaurant(restaurant);
    //   return RedirectToAction("Show",  new { id = loginId });
    // }
