using NUnit.Framework;
using Shouldly;

namespace ScriptLoader.Tests
{
    [TestFixture]
    public class FooterRegistrationTests : BaseTest
    {
        public readonly string ScriptReference1 = "/Scripts/angular.min.js";
        public readonly string ScriptReference2 = "/Scripts/jquery.min.js";

        [Test]
        public void Can_Register_Single_Script()
        {
            Core.ScriptLoader.Footer().Register(ScriptReference1);

            string result = Core.ScriptLoader.Footer().Scripts();

            result.ShouldContain($"<script type=\"text/javascript\" src=\"{ ScriptReference1}\">");
        }

        [Test]
        public void Can_Register_Multiple_Script()
        {
            Core.ScriptLoader.Header().Register(ScriptReference1, ScriptReference2);

            string[] scripts = Core.ScriptLoader.Header().Scripts().Split('\n');

            scripts.Length.ShouldBe(2);
            scripts.ShouldContain($"<script type=\"text/javascript\" src=\"{ ScriptReference1 }\">");
            scripts.ShouldContain($"<script type=\"text/javascript\" src=\"{ ScriptReference2 }\">");
        }
    }
}