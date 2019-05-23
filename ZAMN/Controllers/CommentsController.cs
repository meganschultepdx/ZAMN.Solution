using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class CommentsController : Controller
  {
    [HttpGet("/restaurants/comments")]
    public ActionResult Index()
    {
      List<Comment> allComments = Comment.GetAll();
      return View(allComments);
    }

    [HttpGet("/restaurants/comments/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/restaurants/comments")]
    public ActionResult Create(string description, string date)
    {
      Comment newComment = new Comment(description, date);
      newComment.Save();
      List<Comment> allComments = Comment.GetAll();
      return View("Index", allComments);
    }

    [HttpGet("/restaurants/comments/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Comment selectedComment = Comment.Find(id);
      List<Restaurant> commentRestaurants = selectedComment.GetRestaurants();
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      model.Add("selectedComment", selectedComment);
      model.Add("commentRestaurants", commentRestaurants);
      model.Add("allRestaurants", allRestaurants);
      return View(model);
    }

    [HttpPost("/restaurants/comments/{commentsId}/restaurants/new")]
    public ActionResult AddRestaurant(int commentsId, int restaurantId)
    {
      Comment comment = Comment.Find(commentsId);
      Restaurant restaurant = Restaurant.Find(restaurantId);
      comment.AddRestaurant(restaurant);
      return RedirectToAction("Show",  new { id = commentsId });
    }

  }

}
