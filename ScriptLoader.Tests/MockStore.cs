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

        public IEnumerable<ScriptReference> Pop(ScriptPosition position)
        {
            return Scripts.Where(x => x.ScriptPosition == position);
        }
    }
}