using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuineaPig.Tests.Specs
{
    [TestClass]
    public class AAA
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Arrange();
            Act();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CleanUp();
        }

        protected virtual void Act() { }
        protected virtual void Arrange() { }
        protected virtual void CleanUp() { }

    }
}
