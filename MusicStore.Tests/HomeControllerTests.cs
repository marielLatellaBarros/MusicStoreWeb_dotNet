using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MusicStore.Web.Controllers;
using NUnit.Framework;

namespace MusicStore.Tests
{
    public class HomeControllerTests
    {
        private HomeController _sut;
        private string _controllerName;
        private string _actionName;

        [SetUp]
        public void Setup()
        {
            //arrange
            _sut = new HomeController();

            var newRouteData = new RouteData();
            _sut.ControllerContext.RouteData = newRouteData;

            _controllerName = Guid.NewGuid().ToString();
            _actionName = Guid.NewGuid().ToString();
            newRouteData.Values["controller"] = _controllerName;
            newRouteData.Values["action"] = _actionName;
        }

        [Test]
        public void Index_ReturnsContentContainingControllerNameAndActionName()
        {
            //act
            var result = (ContentResult)_sut.Index();

            //assert
           Assert.That(_sut.Index(), Is.InstanceOf<IActionResult>());
           Assert.That(result, Is.Not.Null);
           Assert.That(result.Content, Is.EqualTo(_controllerName+ _actionName));
        }

        [Test]
        public void About_ReturnsContentContainingControllerNameAndActionName()
        {
            //act
            var result = (ContentResult)_sut.About();

            //assert
            Assert.That(_sut.About(), Is.InstanceOf<IActionResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(_controllerName + _actionName));
        }

        [Test]
        public void Details_ReturnsContentContainingControllerNameActionNameAndParamName()
        {
            //act
            const int id = 1;
            var result = (ContentResult)_sut.Details(id);

            //assert
            Assert.That(_sut.Details(id), Is.InstanceOf<IActionResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(_controllerName + _actionName + id));
        }

        [Test]
        public void Search_Rock_PermanentRedirect()
        {
            //act
            string genre = "rock";
            var result = (RedirectResult)_sut.SearchMusic(genre);

            //assert
            Assert.That(_sut.SearchMusic(genre), Is.InstanceOf<IActionResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Permanent, Is.True);
            Assert.That(result.Url, Is.EqualTo(HomeController.RockUrl));
        }

    }
}