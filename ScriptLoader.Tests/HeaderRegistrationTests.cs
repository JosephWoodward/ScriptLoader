using NUnit.Framework;
using Shouldly;

namespace ScriptLoader.Tests
{
    [TestFixture]
    public class HeaderRegistrationTests : BaseTest
    {
        public readonly string TestFileReference = "/Scripts/angular.min.js";

        [Test]
        public void ShouldOutputSingleFileReference()
        {
            Core.ScriptLoader.Header().Register(TestFileReference);

            string result = Core.ScriptLoader.Header().Load();

            result.ShouldContain($"<script type=\"text/javascript\" src=\"{TestFileReference}\">");
        }
    }
}