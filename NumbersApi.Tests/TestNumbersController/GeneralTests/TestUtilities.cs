using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NumbersApi.Tests.TestNumbersController.GeneralTests
{
    [TestClass]
    public class TestUtilities
    {
        [TestMethod]
        public void getsettingslist_should_return_the_list_of_settings_for_the_key()
        {
            List<String> expectedList = new List<String>();
            expectedList.Add("test");
            expectedList.Add("123");
            expectedList.Add("true");
            expectedList.Add("-2123");
            expectedList.Add("");

            Assert.IsTrue(expectedList.SequenceEqual(Utilities.SplitToList("test;123;true;-2123;", Resources.Numbers.SettingsArraySeparator)));
        }
    }
}
