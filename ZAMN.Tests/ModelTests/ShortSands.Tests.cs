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

    [TestMethod]
    public void ShortSandsPost_ReturnsUserNameOfPost_String()
    {
      //Arrange
      string name = "Test Name";

      ShortSands newPost = new ShortSands(name, "The waves are charging!", 1);

      //Act

      string posted = newPost.Name;

      //Assert
      Assert.AreEqual(name, posted);
    }


    [TestMethod]
    public void Find_ReturnCorrectPostFromDatabase_Post()
    {
      //Arrange
      ShortSands testPost = new ShortSands(1, "Name", "8080000000");
      testShortSands.Save();

      //Act
      ShortSands selectShortSands = ShortSands.Find(testShortSands.GetId());

      //Assert
      Assert.AreEqual(testShortSands, selectShortSands);
    }

  }
}
