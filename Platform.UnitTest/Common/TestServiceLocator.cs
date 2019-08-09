using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform.Common.Service;
using Platform.Infrastructure.DataBaseContext;
using Platform.Infrastructure.User.Interface;
using Platform.Infrastructure.User.Repositories;

namespace Platform.UnitTest.Common
{
    [TestClass]
    public class TestServiceLocator
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRepositoryContext context = ServiceLocator.GetService<IRepositoryContext>("Default");
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void TestRepository()
        {
            ITestService testService = ServiceLocator.GetService<ITestService>();
            testService.test();
         
        }
    }
}
