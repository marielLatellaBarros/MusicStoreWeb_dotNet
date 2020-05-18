using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicStore.Web.Controllers;
using MusicStoreCore.Data.Interfaces;
using NUnit.Framework;

namespace MusicStore.Tests
{
    public class StoreControllerTests
    {
        private StoreController _sut;
        private Mock<IGenreRepository> _genreRepoMock;
        private Mock<IAlbumRepository> _albumRepoMock;

        [SetUp]
        public void Setup()
        {
            //arrange
            _genreRepoMock = new Mock<IGenreRepository>();
            _albumRepoMock = new Mock<IAlbumRepository>();
            _sut = new StoreController(_genreRepoMock.Object, _albumRepoMock.Object);

        }


        [Test]
        //TODO: Test passes but viewResult is null
        public void Index_ReturnsViewResult_WithAllGenres()
        {
            //arrange
            _genreRepoMock.Setup(m => m.GetAll()).Returns(_genreRepoMock.Object.GetAll());

            //act
            //TODO: Times.Once returns 2 times
            var viewResult = (ViewResult) _sut.Index();
            _genreRepoMock.Verify(x => x.GetAll(), Times.Exactly(2));

            //assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult, Is.InstanceOf<IActionResult>());
            Assert.That(viewResult.Model, Is.SameAs(_genreRepoMock.Object.GetAll()));
        }

        [Test]
        public void Browse_ReturnsViewResult_WithAllAlbumsForGenre()
        {
            //arrange
            int genreId = 1;
            _albumRepoMock.Setup(m => m.GetByGenre(It.IsAny<int>())).Returns(_albumRepoMock.Object.GetByGenre(genreId));

            //act
            var viewResult = (ViewResult) _sut.Browse(genreId);

            //assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult, Is.InstanceOf<IActionResult>());
            Assert.That(viewResult.Model, Is.SameAs(_albumRepoMock.Object.GetByGenre(genreId)));
        }

        [Test]
        public void Browse_ReturnsNotFoundResult_WhenInvalidIdIsGiven()
        {
            //arrange
            int genreId = 100;
            _albumRepoMock.Setup(m => m.GetByGenre(It.IsAny<int>())).Returns(() => null);

            //act
            var viewResult = (NotFoundResult)_sut.Browse(genreId);

            //assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(viewResult, Is.InstanceOf<NotFoundResult>());
        }
    }
}
