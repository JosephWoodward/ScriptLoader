using System.Collections.Generic;
using System.Text;

namespace ScriptLoader.Core
{
    public class ScriptRegistrationConfig : IScriptRegistrationConfig
    {
        public ScriptPosition ScriptPosition { get; }

        private IList<string> _scriptPaths = new List<string>();

        private readonly IScriptStore store;

        public ScriptRegistrationConfig(ScriptPosition scriptPosition, IScriptStore store)
        {
            ScriptPosition = scriptPosition;
            this.store = store;
        }

        public void Register(string scriptPath)
        {
            _scriptPaths.Add(scriptPath);
            store.Push(scriptPath, ScriptPosition);
        }

        public string Scripts()
        {
            IEnumerable<ScriptReference> footerScripts = store.Pop(ScriptPosition);
            return ScriptOutput(footerScripts);
        }

        public void Register(params string[] scriptPaths)
        {
            _scriptPaths = scriptPaths;
            foreach (string scriptPath in scriptPaths)
            {
                store.Push(scriptPath, ScriptPosition);
            }
        }

        private static string ScriptOutput(IEnumerable<ScriptReference> scripts)
        {
            var output = new StringBuilder();
            foreach (ScriptReference reference in scripts)
            {
                output.Append($"<script type=\"text/javascript\" src=\"{reference.ScriptPath}\">\n");
            }

            return output.ToString().TrimEnd('\n');
        }
    }

    public interface IScriptRegistrationConfig
    {
        ScriptPosition ScriptPosition { get; }

        void Register(string scriptPath);

        void Register(params string[] scriptPaths);

        string Scripts();
    }
}