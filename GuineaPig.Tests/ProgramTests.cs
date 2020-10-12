using GuineaPig.DataAccess.Data;
using GuineaPig.Tests.Specs;
using GuineaPig.WebUI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuineaPig.WebUI.Tests
{
    [TestClass]
    public class ProgramTests : AAA
    {
        [TestClass]
        public class Calling_CreatHostBuilder_With_No_Args : ProgramTests
        {
            protected IHostBuilder sut;

            protected override void Act()
            {
                sut = Program.CreateHostBuilder(new string[0]);
            }

            [TestMethod()]
            public void Configures_Startup()
            {
                // assert
                Assert.AreEqual(typeof(Startup), sut.Properties["UseStartup.StartupType"]);
            }
        }

        [TestClass]
        public class Building_Host_With_No_Args_On_Create : ProgramTests
        {
            private IHost host;

            protected override void Act()
            {
                host = Program.CreateHostBuilder(new string[0]).Build();
            }

            [TestMethod]
            public void Returns_Not_Null_Host()
            {
                Assert.IsNotNull(host);
            }

            [TestMethod]
            public void Returns_Configured_DataContext()
            {
                Assert.IsNotNull(host.Services.GetService<ApplicationDbContext>());
            }

            [TestMethod]
            public void Returns_Configured_ILogger_For_Controllers()
            {
                Assert.IsNotNull(host.Services.GetService<ILogger<HomeController>>());
            }
        }
    }
}
