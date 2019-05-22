using Microsoft.AspNetCore.Mvc;
using System;

namespace ZAMN.Controllers
{
  public class ShortSandsController : Controller
  {

    [HttpGet("/shortSands")]
    public ActionResult Index()
    {
      return View();
    }

    // [HttpGet("/shortSands/user/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }
    //
    // [HttpPost("/shortSands/{shortSandsId}/users")]
    // public ActionResult Create(int shortSandsId, string shortSandsName, string comment, int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   ShortSands foundShortSands = ShortSands.Find(shortSandsId);
    //   User newUser = new User(userName, userComment, shortSandsId);
    //   newUser.Save();
    //   List<Comments> allComments = Comments.GetAll();
    //   ShortSand selectedShortSand = ShortSand.Find(id);
    //   List<Comment> shortSandComments = selectedShortSand.GetComments();
    //   List<User> shortSandUsers = foundShortSand.GetUsers();
    //   model.Add("clients", shortSandUsers);
    //   model.Add("shortSand", foundShortSand);
    //   model.Add("allComments", allComments);
    //   model.Add("shortSandComments", shortSandComments);
    //   return View("Show", model);
    // }
    //
    // [HttpGet("/shortSands/{shortSandsId}/users/{userId}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   ShortSand selectedShortSand = ShortSand.Find(id);
    //   List<User> shortSandUsers = selectedShortSand.GetUsers();
    //   List<Comment> shortSandComments = selectedShortSand.GetComments();
    //   List<Comment> allComments = Comment.GetAll();
    //   model.Add("shortSand", selectedShortSand);
    //   model.Add("clients", shortSandUsers);
    //   model.Add("shortSandComments", shortSandComments);
    //   model.Add("allComments", allComments);
    //   return RedirectToAction("Index", "shortSands");
    // }

  }
}
