using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAMN.Models;

namespace ZAMN.Controllers
{
  public class IndianBeachController : Controller
  {
    [HttpGet("/indianbeach")]
    public ActionResult Index()
    {
      List<IndianBeach> allIndianBeachComments = IndianBeach.GetAll();
      return View(allIndianBeachComments);
    }

    [HttpGet("/indianbeach/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/indianbeach")]
    public ActionResult Create(string userName, string userComment, DateTime timePost)
    {
      IndianBeach newPost = new IndianBeach(userName, userComment, timePost);
      newPost.Save();
      List<IndianBeach> allPosts = IndianBeach.GetAll();
      return View("Index", allPosts);
    }

    [HttpPost("/indianbeach/delete")]
    public ActionResult DeleteAll()
    {
      IndianBeach.ClearAll();
      return View();
    }
  }
}
