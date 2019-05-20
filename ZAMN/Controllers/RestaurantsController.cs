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
    public ActionResult Create(string name, string address, string type)
    {
      Restaurant newRestaurant = new Restaurant(name, address, type);
      newRestaurant.Save();
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      return View("Index", allRestaurants);
    }

    [HttpPost("/restaurants/delete")]
    public ActionResult DeleteAll()
    {
      Restaurant.ClearAll();
      return View();
    }

    // [HttpGet("/restaurants/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Restaurant selectedRestaurant = Restaurant.Find(id);
    //   List<User> restaurantUsers = selectedRestaurant.GetUsers();
    //   List<User> allUsers = User.GetAll();
    //   model.Add("selectedRestaurant", selectedRestaurant);
    //   model.Add("restaurantUsers", restaurantUsers);
    //   model.Add("allUsers", allUsers);
    //   return View(model);
    // }
    //
    // [HttpPost("/restaurants/{restaurantsId}/users/new")]
    // public ActionResult AddUser(int restaurantsId, int userId)
    // {
    //   Restaurant restaurant = Restaurant.Find(restaurantsId);
    //   User user = User.Find(userId);
    //   restaurant.AddUser(user);
    //   return RedirectToAction("Show",  new { id = restaurantsId });
    // }

    // [HttpPost("/restaurants/{restaurantsId}/delete-restaurant")]
    // public ActionResult DeleteRestaurant(int restaurantId)
    // {
    //   Restaurant selectedRestaurant = Restaurant.Find(restaurantId);
    //   selectedRestaurant.DeleteRestaurant(restaurantId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   List<Restaurant> restaurantUsers = selectedRestaurant.GetUsers();
    //   model.Add("selectedRestaurant", selectedRestaurant);
    //   return RedirectToAction("Index", "Restaurants");
    // }
  }

}
