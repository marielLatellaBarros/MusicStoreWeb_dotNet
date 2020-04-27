using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MusicStore.Web.Controllers;
using NUnit.Framework;

namespace MusicStore.Tests
{
    public class Tests
    {
        private HomeController _homeController;

       [SetUp]
        public void Setup()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void Index_ReturnsContentContainingControllerNameAndActionName()
        {
            //arrange
            var newRouteData = new RouteData();
            newRouteData.Values["controller"] = Guid.NewGuid().ToString();
            newRouteData.Values["action"] = Guid.NewGuid().ToString();

            _homeController.ControllerContext.RouteData = newRouteData;

            //act
            var contentResult = _homeController.Index();

            //assert
           Assert.That(_homeController.Index(), Is.InstanceOf<IActionResult>());
           Assert.That(contentResult, Is.Not.Null);

           //TODO: No "Content" property for contentResult
           //Assert.That(contentResult.Content );
        }

        [Test]
        public void About_ReturnsContentContainingControllerNameAndActionName()
        {
            Assert.Pass();
        }

    }
}