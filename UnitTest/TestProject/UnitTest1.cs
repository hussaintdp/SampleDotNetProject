using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using UnitTest.Controllers;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            HomeController home = new HomeController();
            string result = home.GetEmployeeName(1);
            Assert.AreEqual("Jignesh", result);
        }
        [Test]
        public void Test2()
        {
            HomeController home = new HomeController();
            string result = home.GetEmployeeName(1);
            Assert.AreEqual("Rakesh", result);
        }

        [TestCase(1, "Jignesh")]
        [TestCase(2, "Rakesh")]
        [TestCase(3, "Not Found")]
        public void Test3(int empId, string name)
        {
            HomeController home = new HomeController();
            string result = home.GetEmployeeName(empId);
            Assert.AreEqual(name, result);
        }

        [Test]
        public void Test4()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<TestController>();
            TestController home = new TestController(logger);
            string result = home.GetMessage();
            Assert.AreEqual("Hi! Reader", result);
        }
    }
}