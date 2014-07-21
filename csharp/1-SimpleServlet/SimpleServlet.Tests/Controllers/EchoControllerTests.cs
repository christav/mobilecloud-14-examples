using System;
using System.Web.Mvc;
using SimpleServlet.Controllers;
using Xunit;

namespace SimpleServlet.Tests.Controllers
{
    public class EchoControllerTests
    {
        [Fact]
        public void EchoActionEchosMessage()
        {
            var controller = new EchoController();
            var message = "1234";
            var result = (ContentResult)(controller.Index(message));

            Assert.Equal("Echo:" + message, result.Content);
        }
    }
}
