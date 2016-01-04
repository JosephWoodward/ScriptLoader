using System.Collections.Generic;
using System.Linq;
using ScriptLoader.Core;

namespace ScriptLoader.Tests
{
    public class MockStore : IScriptStore
    {
        private readonly IList<ScriptReference> Scripts = new List<ScriptReference>();

        public void Push(string filePath, ScriptPosition position)
        {
            Scripts.Add(new ScriptReference
            {
                ScriptPath = filePath,
                ScriptPosition = position
            });
        }

        public string Pop(ScriptPosition position)
        {
            List<ScriptReference> res = Scripts.Where(x => x.ScriptPosition == position).ToList();

            string output = string.Empty;

            foreach (ScriptReference scriptReference in res)
            {
                output += "<script type=\"text/javascript\" src=\"" + scriptReference.ScriptPath + "\">";
            }

            return output;
        }
    }
}