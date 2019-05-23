using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ZAMN.Models;
using System;

namespace ZAMN.Tests
{
  [TestClass]
  public class ShortSandsTest : IDisposable
  {

    public void Dispose()
    {
      ShortSands.ClearAll();
    }

    public ShortSandsTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=shortsands;";
    }

    // [TestMethod]
    // public void ShortSandsPost_ReturnsUserNameOfPost_String()
    // {
    //   //Arrange
    //   string name = "Test Name";
    //   DateTime time = '17:14:20';
    //
    //   ShortSands newPost = new ShortSands(1, name, "comment", time);
    //
    //   //Act
    //
    //   string posted = newPost.Name;
    //
    //   //Assert
    //   Assert.AreEqual(name, posted);
    // }

    //
    [TestMethod]
    public void GetAll_ReturnsPosts_AllPosts()
    {
      //Arrange
      string nameOne = "Name1";
      string nameTwo = "Name2";

      string commentOne = "Comment";
      string commentTwo = "Comment";

      DateTime timeOne = new DateTime(2019,05,07);
      DateTime timeTwo = new DateTime(2019,05,07);

      ShortSands post1 = new ShortSands(nameOne, commentOne, timeOne);

      post1.Save();

      ShortSands post2 = new ShortSands(nameTwo, commentTwo, timeTwo);
      post2.Save();

      List<ShortSands> newPost = new List<ShortSands> { post1, post2 };

      //Act
      List<ShortSands> allPosts = ShortSands.GetAll();

      //Assert
      CollectionAssert.AreEqual(newPost, allPosts);
    }

    // [TestMethod]
    // public void Equals_ReturnsTrueIfPostsAreEqual_Posts()
    // {
    //
    //   string commentOne = "Comment";
    //   string commentTwo = "Comment";
    //
    //   // Arrange, Act
    //   ShortSands postOne = new ShortSands(1, "Name2", commentOne, DateTime(2019,05,07));
    //   ShortSands postTwo = new ShortSands(1, "Name2", commentTwo, DateTime(2019,05,07));
    //
    //   // Assert
    //   Assert.AreEqual(postOne, postTwo);
    // }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      string nameOne = "Name1";
      string commentOne = "Comment";
      DateTime timeOne = new DateTime(2019,05,07);

      ShortSands testPost = new ShortSands(nameOne, commentOne, timeOne);

      //Act
      testPost.Save();

      ShortSands savedPost = ShortSands.GetAll()[0];

      int result = savedPost.GetId();
      int testId = testPost.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

  }
}
