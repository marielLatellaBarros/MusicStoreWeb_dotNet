using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicStore.Web.Controllers;
using MusicStoreCore.Data.DomainClasses;
using NUnit.Framework;
using System.Collections.Generic;
using MusicStoreCore.Data.Interfaces;

namespace MusicStore.Tests
{
    public class StoreControllerTests
    {
        private StoreController _sut;
        private Mock<IGenreRepository> _genreRepoMock;

        [SetUp]
        public void Setup()
        {
            //arrange
            _genreRepoMock = new Mock<IGenreRepository>();
            _sut = new StoreController(_genreRepoMock.Object);
        }


        [Test]
        public void Index_ShowsListOfMusicGenres()
        {
            //arrange
            IReadOnlyList<Genre> genres = new List<Genre>();
            _genreRepoMock.Setup(m => m.GetAll()).Returns(genres);

            //act
            var viewResult = (ViewResult) _sut.Index();

            //assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult, Is.InstanceOf<IActionResult>());

        }
    }
}
