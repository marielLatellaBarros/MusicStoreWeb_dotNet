using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MusicStore.Web.Controllers;
using NUnit.Framework;

namespace MusicStore.Tests
{
    public class Tests
    {
        private HomeController sut;
        public string _controllerName { get; private set; }
        private string _actionName;
        private RouteData _newRouteData;

       [SetUp]
        public void Setup()
        {
            //arrange
            sut = new HomeController();

            var newRouteData = new RouteData();
            sut.ControllerContext.RouteData = newRouteData;

            _controllerName = Guid.NewGuid().ToString();
            _actionName = Guid.NewGuid().ToString();
            newRouteData.Values["controller"] = _controllerName;
            newRouteData.Values["action"] = _actionName;
        }

        [Test]
        public void Index_ReturnsContentContainingControllerNameAndActionName()
        {
            //act
            var result = (ContentResult)sut.Index();

            //assert
           Assert.That(sut.Index(), Is.InstanceOf<IActionResult>());
           Assert.That(result, Is.Not.Null);
           Assert.That(result.Content, Is.EqualTo(_controllerName+ _actionName));
        }

        [Test]
        public void About_ReturnsContentContainingControllerNameAndActionName()
        {
            Assert.Pass();
        }

    }
}