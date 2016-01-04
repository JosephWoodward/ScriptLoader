using NUnit.Framework;

namespace ScriptLoader.Tests
{
    public class BaseTest
    {
        [SetUp]
        public void TestSetup()
        {
            Core.ScriptLoader.DefaultStore = new MockStore();
        }
    }
}