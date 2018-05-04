using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
      public class HairSalonTests : IDisposable
      {
          public void Dispose()
          {
              Item.DeleteAll();
          }
          public HairSalonTests()
          {
              DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=justin_roller_test;";
          }
          [TestMethod]
            public void GetAll_DbStartsEmpty_0()
            {
            //Arrange
            //Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
            }
      }

}
