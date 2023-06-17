//using FakeItEasy;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test_InsiderNepal.Controller_Test
//{
//    public class JobsControllerTest
//    {
//        [Fact]
//        public async Task Index_Post_ValidData_ShouldSaveAndRedirect()
//        {
//            // Arrange
//            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDB")
//                .Options;

//            var dbContext = new ApplicationDbContext(dbContextOptions);

//            var controller = new AddJobController(dbContext);

//            var job = new Job
//            {
//                JobTitle = "Software Engineer",
//                JobType = "Full-time",
//                Location = "New York",
//                NumberOfPost = 1,
//                CompanyName = "MyCompany",
//                JobDescription = "Looking for a skilled software engineer",
//                Qualification = "Bachelor's degree in Computer Science or related field",
//                Experience = "2+ years of experience in software development",
//                Salary = 100000.00f,
//                EmployerId = "employer123",
//                Deadline = DateTime.UtcNow.AddDays(30)
//            };

//            var companyLogo = A.Fake<IFormFile>(options => options.ConfigureFake(fake => A.CallTo(() => fake.Length).Returns(4)));
//            A.CallTo(() => companyLogo.Length).Returns(4);

//            // Act
//            var result = await controller.Index(job, companyLogo);

//            //// Assert
//            //A.CallTo(() => dbContext.Add(job)).MustHaveHappenedOnceExactly();
//            //A.CallTo(() => dbContext.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();

//            Assert.IsType<RedirectToActionResult>(result);
//        }
//        [Fact]
//        public async Task Index_Post_InValidData_ShouldnotSaveAndRedirect()
//        {
//            // Arrange
//            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDB")
//                .Options;

//            var dbContext = new ApplicationDbContext(dbContextOptions);

//            var controller = new AddJobController(dbContext);

//            var job = new Job();

//            var companyLogo = A.Fake<IFormFile>(options => options.ConfigureFake(fake => A.CallTo(() => fake.Length).Returns(4)));
//            A.CallTo(() => companyLogo.Length).Returns(4);

//            // Act
//            var result = await controller.Index(job, companyLogo);

//            Assert.IsType<ViewResult>(result);
//        }
//    }

//}
