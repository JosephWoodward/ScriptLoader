using System;
using System.Collections.Generic;

namespace ScriptLoader.Core
{
    public class HttpContextStore : IScriptStore
    {
        public void Push(ScriptPosition position)
        {
            throw new NotImplementedException();
        }

        public void Push(string filePath, ScriptPosition position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ScriptReference> Pop(ScriptPosition position)
        {
            throw new NotImplementedException();
        }
    }
}