using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class ShortSandsController : Controller
  {
    [HttpGet("/shortsands")]
    public ActionResult Index()
    {
      List<ShortSands> allShortSandsComments = ShortSands.GetAll();
      return View(allShortSandsComments);
    }

    [HttpGet("/shortsands/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/shortsands")]
    public ActionResult Create(string userName, string userComment, DateTime timePost)
    {
      ShortSands newPost = new ShortSands(userName, userComment, timePost);
      newPost.Save();
      List<ShortSands> allPosts = ShortSands.GetAll();
      return View("Index", allPosts);
    }

    [HttpPost("/shortsands/delete")]
    public ActionResult DeleteAll()
    {
      ShortSands.ClearAll();
      return View();
    }
  }
}
