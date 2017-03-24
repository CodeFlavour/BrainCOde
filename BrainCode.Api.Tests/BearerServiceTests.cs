using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrainCode.Api.Services;
using System.Collections.Generic;

namespace BrainCode.Api.Tests
{
    [TestClass]
    public class BearerServiceTests
    {
        [TestMethod]
        public void Completed()
        {
            BearerService service = new BearerService();
            KeyValuePair<string,string> result = service.GetBearerHeader().Result;

            Assert.AreEqual("Authorization", result.Key);
            Assert.IsNotNull(result.Value);
        }
    }
}
