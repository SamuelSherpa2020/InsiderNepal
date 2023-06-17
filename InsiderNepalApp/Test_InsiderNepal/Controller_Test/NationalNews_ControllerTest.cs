using InsiderNepalApp.Controllers;
using InsiderNepalApp.Data;
using InsiderNepalApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_InsiderNepal.Controller_Test
{
    public class NationalNews_ControllerTest
    {
        private NationalNews _nationalNews;
        private readonly InsiderNepalDbContext _ctx;
        public NationalNews_ControllerTest(InsiderNepalDbContext ctx)
        {
            _ctx = ctx;


            //Arrange
            var controller = new NationalNewsController(_ctx);
            
            //Action
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.NotNull(result);
        }
    }
}
