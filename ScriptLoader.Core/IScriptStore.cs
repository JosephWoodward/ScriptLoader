namespace ScriptLoader.Core
{
    public interface IScriptStore
    {
        void Push(string filePath, ScriptPosition position);

        string Pop(ScriptPosition position);
    }
}