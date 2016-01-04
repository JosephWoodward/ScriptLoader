using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace ScriptLoader.Tests
{
    [TestFixture]
    public class Class1 : BaseTest
    {
        [Test]
        public void Test()
        {
            Core.ScriptLoader.DefaultStore = new MockStore();
            Core.ScriptLoader.RegisterHeader("res.js");
            string res = Core.ScriptLoader.LoadHead();

            res.ShouldContain("res.js");
        }
    }
}