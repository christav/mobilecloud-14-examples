using System;
using System.Web.Mvc;
using SimpleServlet.Controllers;
using Xunit;

namespace SimpleServlet.Tests.Controllers
{
    public class EchoControllerTests
    {
        /// <summary>
        /// This test invokes the Index method of the EchoController
        /// and verifies that it returns the correct value.
        /// 
        /// Note that unlike the Java sample, the site does NOT need to
        /// be running; controllers in general can just be newed up like
        /// any other class, a feature that makes it a lot easier to do
        /// fast testing.
        /// </summary>
        [Fact]
        public void EchoActionEchosMessage()
        {
            var controller = new EchoController();
            const string message = "1234";
            var result = (ContentResult)(controller.Index(message));

            Assert.Equal("Echo:" + message, result.Content);
        }
    }
}
