using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using NumbersApi.Controllers;
using NumbersApi.Models;
using System.Web.Http.Results;

namespace NumbersApi.Tests.TestNumbersController.GeneralTests
{
    [TestClass]
    public class TestWriteNumber
    {
        [TestMethod]
        public void if_culturefallback_not_allowed_then_cultures_other_than_en_gb_are_not_supported_and_returns_badrequest()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "0",
                CultureName = "it-IT"
            };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.IsTrue(result.Message.ToLower().Contains("not supported"));
        }

        [TestMethod]
        public void if_culturefallback_is_allowed_then_engb_is_used_as_fallback_culture()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "0",
                CultureName = "it-IT",
                AllowCultureFallback = true
            };

            //Act
            var result = controller.WriteNumber(options) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content.Error);
            Assert.AreEqual("Culture is currently not supported.", result.Content.Error);
        }

        [TestMethod]
        public void if_options_are_null_a_bad_request_error_is_returned_with_proper_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = null;

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual("Options must be specified in the request body.", result.Message);
            
        }

        [TestMethod]
        public void if_input_value_is_null_then_a_bad_request_error_is_returned_with_a_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = null,
                CultureName = "en-gb"
            };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual("Parameter must be specified. \r\nParameter name: Value", result.Message);
        } 

        [TestMethod]
        public void if_input_value_is_outside_int32_limits_then_a_bad_request_error_is_returned_with_a_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
                {
                    Value= "-12309283230928320198",
                    CultureName= "en-gb"
                };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.IsTrue(result.Message.Contains(Int32.MinValue.ToString()));
            Assert.IsTrue(result.Message.Contains(Int32.MaxValue.ToString()));
            Assert.IsTrue(result.Message.Contains("The integer must be between "));
        }

        [TestMethod]
        public void if_input_value_has_an_invalid_format_for_int32_then_a_bad_request_error_is_returned_with_a_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "qwerty48534",
                CultureName = "en-gb"
            };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);            
            Assert.AreEqual("The number is not valid.", result.Message);
        }

        [TestMethod]
        public void if_input_value_has_one_or_more_dots_then_a_bad_request_error_is_returned_with_a_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "48534.23",
                CultureName = "en-gb"
            };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual("The number is not valid.", result.Message);
        }

        [TestMethod]
        public void if_input_value_has_one_or_more_commas_then_a_bad_request_error_is_returned_with_a_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "48534,23",
                CultureName = "en-gb"
            };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual("The number is not valid.", result.Message);
        }

        [TestMethod]
        public void if_input_culture_is_null_then_a_bad_request_error_is_returned_with_a_user_level_message()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "48534,23",
                CultureName = null
            };

            //Act
            var result = controller.WriteNumber(options) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual("Parameter must be specified. \r\nParameter name: CultureName", result.Message);
        }

    }
}
