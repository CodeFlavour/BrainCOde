using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrainCode.Api.Services;
using System.Collections.Generic;
using BrainCode.Api.Models;

namespace BrainCode.Api.Tests
{
    [TestClass]
    public class BearerServiceTests
    {
        [TestMethod]
        public void Completed()
        {
            BearerService service = new BearerService();
            Header result = service.GetBearerHeader().Result;

            Assert.AreEqual("Authorization", result.Name);
            Assert.IsNotNull(result.Value);
        }
    }
}
