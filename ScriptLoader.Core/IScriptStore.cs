using System.Collections.Generic;

namespace ScriptLoader.Core
{
    public interface IScriptStore
    {
        void Push(string filePath, ScriptPosition position);

        IEnumerable<ScriptReference> Pop(ScriptPosition position);
    }
}