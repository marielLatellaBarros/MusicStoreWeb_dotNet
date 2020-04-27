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
            var newRouteData = new RouteData();
            var routeData = new RouteData();
            routeData.Values["controller"] = Guid.NewGuid().ToString();
            routeData.Values["action"] = Guid.NewGuid().ToString();

            _homeController.ControllerContext.RouteData = newRouteData;


            var actionResult = _homeController.Index();

           Assert.That(actionResult, Is.InstanceOf<IActionResult>());
           Assert.That(_homeController.RouteData.Values["homeIndex"], Is.EqualTo("Home:Index"));
        }

        [Test]
        public void About_ReturnsContentContainingControllerNameAndActionName()
        {
            Assert.Pass();
        }

    }
}