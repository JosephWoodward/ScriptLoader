using NUnit.Framework;
using Shouldly;

namespace ScriptLoader.Tests
{
    [TestFixture]
    public class FooterRegistrationTests : BaseTest
    {
        public readonly string TestFileReference = "/Scripts/angular.min.js";

        [Test]
        public void ShouldOutputSingleFileReference()
        {
            Core.ScriptLoader.Footer().Register(TestFileReference);

            string result = Core.ScriptLoader.Footer().Load();

            result.ShouldContain($"<script type=\"text/javascript\" src=\"{TestFileReference}\">");
        }
    }
}