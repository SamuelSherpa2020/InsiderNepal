using Xunit;
using InsiderNepalApp;
using Microsoft.AspNetCore.Mvc.Testing;
using InsiderNepalApp.Controllers;
using Microsoft.EntityFrameworkCore;
using InsiderNepalApp.Data;
using Microsoft.AspNetCore.Mvc;
using FakeItEasy;
using FluentAssertions;
using InsiderNepalApp.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Security.Policy;
using InsiderNepalApp.Models;
using Bogus;
//We will be building three different types of unit tests.
// 1. Test the view returned by a controller action.
// 2. Test the View Data returned by a controller action
// 3. Test whether one controller action redirects you to a second controlelr action

namespace Test_InsiderNepal
{
    public class Test_NationalNewsController
    {

        //private readonly InsiderNepalDbContext _context;

        //public Test_NationalNewsController()
        //{
        //      _context = A.Fake<InsiderNepalDbContext>();


        [Fact]
        public void Test_Index_Of_NationalNews_Controller_returns_View()
        {

            //Arrange
            var dbContextOptions = new DbContextOptionsBuilder<InsiderNepalDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var dbContext = new InsiderNepalDbContext(dbContextOptions);
            var controller = new NationalNewsController(dbContext);

            //Action
            var result = controller.Index();

            //Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Test_AddNews_Of_NationalNews_Controller()
        {
            //Arrange
            var dbContextOptions = new DbContextOptionsBuilder<InsiderNepalDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var dbContext = new InsiderNepalDbContext(dbContextOptions);
            var controller = new NationalNewsController(dbContext);
            var faker = new Faker();
            var fakeId = faker.Random.Number();
            var newsImage = A.Fake<IFormFile>();

            var nationalNews = new NationalNewsVM
            {
                NationalNewsId = fakeId,
                Title = "New PM elected",
                Author = "Kailash",
                PublishDateTime = DateTime.Parse("2023-04-11"),
                Content = "This is content",
                ImageUrl = "E:\\Silicon Soft\\InsiderNepal\\InsiderNepalApp\\Test_InsiderNepal\\bin\\Debug\\net7.0\\wwwroot\\images\\National\\a5764ead-1e5f-42fa-b07a-738612c40d79_",
                Avatar = newsImage,
            };

            //act
            var result = controller.AddNews(nationalNews);

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact]
        public void Test_Delete_Of_NationalNews_Controller()
        {
            //Arrange
            var dbContextOptions = new DbContextOptionsBuilder<InsiderNepalDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDB")
                    .Options;

            var dbContext = new InsiderNepalDbContext(dbContextOptions);
            var controller = new NationalNewsController(dbContext);

            var faker = new Faker();
            int fakeId = faker.Random.Number();
            var nationalNews = new NationalNewsVM()
            {
                NationalNewsId = fakeId,
                Title = "Hello",
                Author = "Samuel",
                PublishDateTime = DateTime.Parse("2023-04-11"),
                Content = "I will delete this news",
                ImageUrl = "hello/hello",
            };


            // Action
            var result = controller.DeleteNN(nationalNews);

            //Assert 

            Assert.IsType<RedirectToActionResult>(result);

        }

        [Fact]
        public void Test_ReadNationalNews_Contoller_return_View()
        {
            //Arrange
            var dbContextOptions = new DbContextOptionsBuilder<InsiderNepalDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var dbContext = new InsiderNepalDbContext(dbContextOptions);
            var controller = new NationalNewsController(dbContext);
            //Action
            var result = controller.ReadNationalNews();

            //Assert
            //Assert.IsType<RedirectToActionResult>(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Test_ShowNewsInDetail_return_View()
        {
            //Arrange
            var dbContextOptions = new DbContextOptionsBuilder<InsiderNepalDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var dbContext = new InsiderNepalDbContext(dbContextOptions);
            var controller = new NationalNewsController(dbContext);

            var fakeId = new Faker();
            var newsId = fakeId.Random.Number();

            //action
            var result = controller.ShowNewsInDetail(newsId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }
    }

}