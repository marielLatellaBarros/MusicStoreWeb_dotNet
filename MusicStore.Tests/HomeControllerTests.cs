using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using MusicStore.Web.Controllers;
using MusicStore.Web.Services;
using NUnit.Framework;
using System;

namespace MusicStore.Tests
{
    public class HomeControllerTests
    {
        private HomeController _sut;
        private string _controllerName;
        private string _actionName;
        private Mock<IFileProvider> _fileProviderMock;
        private byte[] _fileBytes;

        [SetUp]
        public void Setup()
        {
            //arrange
            _fileProviderMock = new Mock<IFileProvider>();
            _fileBytes = Guid.NewGuid().ToByteArray();
            _fileProviderMock.Setup(m => m.GetBytes(It.IsAny<string>())).Returns(_fileBytes);

            _sut = new HomeController(_fileProviderMock.Object);

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
            const string genre = "rock";
            var result = (RedirectResult)_sut.SearchMusic(genre);

            //assert
            Assert.That(_sut.SearchMusic(genre), Is.InstanceOf<IActionResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Permanent, Is.True);
            Assert.That(result.Url, Is.EqualTo(HomeController.RockUrl));
        }

        [Test]
        public void Search_Jazz_RedirectToIndexAction()
        {
            //act
            const string genre = "jazz";
            var result = (RedirectToActionResult)_sut.SearchMusic(genre);

            //assert
            Assert.That(_sut.SearchMusic(genre), Is.InstanceOf<IActionResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Search_Metal_RedirectToDetailsActionWithRandomId()
        {
            //act
            const string genre = "metal";
            var result = (RedirectToActionResult)_sut.SearchMusic(genre);

            //assert
            Assert.That(_sut.SearchMusic(genre), Is.InstanceOf<IActionResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Details"));
            Assert.That(result.RouteValues.Values.Count, Is.EqualTo(1));
        }

        [Test]
        public void Search_Classic_ReturnsContentOfSiteCssFile()
        {
            //act
            const string genre = "classic";
            var result = (FileContentResult)_sut.SearchMusic(genre);

            //assert
            Assert.That(_sut.SearchMusic(genre), Is.InstanceOf<IActionResult>());
            Assert.That(result.FileContents, Is.Not.Null);
        }
    }
}