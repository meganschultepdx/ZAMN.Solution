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

    [HttpGet("/capeKiwanda/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/capeKiwanda")]
    public ActionResult Create(string userName, string userComment)
    {
      SurfLocation newComment = new SurfLocation(userName, userComment);
      newComment.Save();

      List<SurfLocation> allComments = SurfLocation.GetAll();

      return View("Index", allComments);
    }

    // [HttpGet("/capeKiwanda/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object> ();
    //   SurfLocation selectedSurfLocation = SurfLocation.Find(id);
    //   List<User> allUserComments = User.GetAll();
    //   List<User> locationCommentsByUser = selectedSurfLocation.GetUsers();
    //
    //   model.Add("surfLocation", selectedSurfLocation);
    //   model.Add("allUserComments", allUserComments);
    //   model.Add("locationCommentsByUser", locationCommentsByUser);
    //
    //   return View(model);
    // }
  }
}
