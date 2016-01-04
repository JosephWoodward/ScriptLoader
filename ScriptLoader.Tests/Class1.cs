using NUnit.Framework;
using Shouldly;

namespace ScriptLoader.Tests
{
    [TestFixture]
    public class Class1 : BaseTest
    {
        public readonly string TestFileReference = "/Scripts/angular.min.js";

        [Test]
        public void ShouldOutputSingleFileReference()
        {
            //Core.ScriptLoader.Header().Register(TestFileReference);

            Core.ScriptLoader.RegisterHeader(TestFileReference);
            string result = Core.ScriptLoader.LoadHeader();

            result.ShouldContain($"<script type=\"text/javascript\" src=\"{TestFileReference}\">");
        }
    }
}