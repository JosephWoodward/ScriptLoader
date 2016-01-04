namespace ScriptLoader.Core
{
    public static class ScriptLoader
    {
        public static IScriptStore DefaultStore = new HttpContextStore();

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
            return DefaultStore.Pop(ScriptPosition.Footer);
        }

        public static string LoadHead()
        {
            return DefaultStore.Pop(ScriptPosition.Header);
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