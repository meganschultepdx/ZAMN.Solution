using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class RestaurantsController : Controller
  {
    [HttpGet("/restaurants")]
    public ActionResult Index()
    {
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      return View(allRestaurants);
    }

    [HttpGet("/restaurants/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/restaurants")]
    public ActionResult Create(string name, string address, string type, string description)
    {
      Restaurant newRestaurant = new Restaurant(name, address, type, description);
      newRestaurant.Save();
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      return View("Index", allRestaurants);
    }

    [HttpGet("/restaurants/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Restaurant selectedRestaurant = Restaurant.Find(id);
      List<Comment> restaurantComments = selectedRestaurant.GetComments();

      model.Add("selectedRestaurant", selectedRestaurant);
      model.Add("restaurantComments", restaurantComments);

      return View(model);
    }

    [HttpPost("/restaurants/{restaurantId}/comments/new")]
    public ActionResult AddComment(int restaurantId, string comment)
    {
      Restaurant restaurant = Restaurant.Find(restaurantId);
      restaurant.AddComment(comment);
      return RedirectToAction("Show",  new { id = restaurantId });
    }
  }

}
