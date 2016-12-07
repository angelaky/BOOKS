using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksBlog.Tests.ViewModels;
using BooksBlog.Areas.Administration.ViewModels;

namespace BooksBlog.Tests
{
    [TestClass]
    public class CategoryViewModelUnitTests
    {
        [TestMethod]
        public void Validate_Model_Given_Valid_Model_ExpectNoValidationErrors()
        {
            var model = new CategoryViewModel()
            {
                Name = "12345678901234567890"
            };

            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Validate_Model_Given_Category_Name_Is_Null_ExpectOneValidationError()
        {
            var model = new CategoryViewModel();

            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Category Name field is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Validate_Model_Given_Category_Name_Exeeded_Lenght_ExpectOneValidationError()
        {
            var model = new CategoryViewModel()            
            {
                Name = "12345678901234567890123456789012345678901"
            };
            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The field Category Name must be a string with a maximum length of 20.", results[0].ErrorMessage);
        }
    }
}
