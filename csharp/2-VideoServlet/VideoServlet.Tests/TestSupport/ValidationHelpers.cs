using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VideoServlet.Tests.TestSupport
{
    public static class ValidationHelpers
    {
        /// <summary>
        /// This is a helper method to trigger model validation on a controller method
        /// so that we can test that our model is correctly handled.
        /// This code was taken from http://philmunro.wordpress.com/2011/10/23/unit-testing-asp-net-mvc-views-and-view-models/
        /// </summary>
        /// <remarks>For those not familiar with C#, this is an extension method.
        /// The compiler will make it look like a method on any controller in the
        /// source code.</remarks>
        /// <param name="controller">The controller to do validation</param>
        /// <param name="model">The model to validate</param>
        public static void ValidateModel(this Controller controller, object model)
        {
            controller.ModelState.Clear();

            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                foreach (var name in result.MemberNames)
                {
                    controller.ModelState.AddModelError(name, result.ErrorMessage);
                }
            }
        }
    }
}
