using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLoader.Core
{
    public class ScriptConfig
    {
        public void Register(string scriptPath)
        {
        }
    }

    public static class ScriptLoader
    {
        public static IScriptStore DefaultStore = new HttpContextStore();

        public static ScriptConfig Header()
        {
            return new ScriptConfig();
        }

        public static void RegisterHeader(string scriptPath)
        {
            RegisterScripts(ScriptPosition.Header, scriptPath);
        }

        public static void RegisterHeader(params string[] scriptPath)
        {
            RegisterScripts(ScriptPosition.Header, scriptPath);
        }

        public static void RegisterFooter(string scriptPath)
        {
            RegisterScripts(ScriptPosition.Footer, scriptPath);
        }
        
        public static string LoadFoot()
        {
            IEnumerable<ScriptReference> footerScripts = DefaultStore.Pop(ScriptPosition.Footer);
            return ScriptOutput(footerScripts);
        }

        public static string LoadHeader()
        {
            IEnumerable<ScriptReference> headerScripts = DefaultStore.Pop(ScriptPosition.Header);
            return ScriptOutput(headerScripts);
        }

        private static string ScriptOutput(IEnumerable<ScriptReference> scripts)
        {
            var output = new StringBuilder();
            foreach (ScriptReference reference in scripts)
            {
                output.Append($"<script type=\"text/javascript\" src=\"{reference.ScriptPath}\">");
            }

            return output.ToString();
        }

        private static void RegisterScripts(ScriptPosition position, params string[] filePath)
        {
            foreach (string scriptPath in filePath)
            {
                DefaultStore.Push(scriptPath, position);
            }
        }
    }
}