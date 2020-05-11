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
            IList<Genre> genres = new List<Genre>
            {
                new Genre(),
                new Genre()
            };
            //TODO: this line fails. NullReferenceException: genreRepoMock somehow is NULL
            _genreRepoMock.Setup(m => m.GetAll()).Returns(genres);

            var viewResult = (ViewResult) _sut.Index();

            //assert
            Assert.That(viewResult, Is.Not.Null);

        }
    }
}
