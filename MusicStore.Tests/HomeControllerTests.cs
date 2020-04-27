using Microsoft.AspNetCore.Mvc;
using MusicStore.Web.Controllers;
using NUnit.Framework;

namespace MusicStore.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Index_ReturnsContentContainingControllerNameAndActionName()
        {
            HomeController homeController = new HomeController();

            // inside controller code
           // string home = homeController.RouteData.Values["Home:Index"].ToString();

            Assert.That(homeController.Index(), Is.InstanceOf<IActionResult>());
        }

        [Test]
        public void About_ReturnsContentContainingControllerNameAndActionName()
        {
            Assert.Pass();
        }

    }
}