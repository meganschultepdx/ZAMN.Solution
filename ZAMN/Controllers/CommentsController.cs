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
    [HttpGet("/comments")]
    public ActionResult Index()
    {
      List<Comment> allComments = Comment.GetAll();
      return View(allComments);
    }

    [HttpGet("/comments/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/comments")]
    public ActionResult Create(string description)
    {
      Comment newComment = new Comment(description);
      newComment.Save();
      List<Comment> allComments = Comment.GetAll();
      return View("Index", allComments);
    }

    [HttpGet("/comments/{id}")]
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

    [HttpPost("/comments/{commentsId}/restaurants/new")]
    public ActionResult AddRestaurant(int commentsId, int restaurantId)
    {
      Comment comment = Comment.Find(commentsId);
      Restaurant restaurant = Restaurant.Find(restaurantId);
      comment.AddRestaurant(restaurant);
      return RedirectToAction("Show",  new { id = commentsId });
    }

    // [HttpPost("/comments/{commentsId}/delete-comment")]
    // public ActionResult DeleteComment(int commentId)
    // {
    //   Comment selectedComment = Comment.Find(commentId);
    //   selectedComment.DeleteComment(commentId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   List<Comment> commentRestaurants = selectedComment.GetRestaurants();
    //   model.Add("selectedComment", selectedComment);
    //   return RedirectToAction("Index", "Comments");
    // }
  }

}
