namespace ScriptLoader.Core
{
    public static class ScriptLoader
    {
        public static IScriptStore DefaultScriptStore = new HttpContextStore();

        public static IScriptRegistrationConfig Header()
        {
            return new ScriptRegistrationConfig(ScriptPosition.Header, DefaultScriptStore);
        }

        public static IScriptRegistrationConfig Footer()
        {
            return new ScriptRegistrationConfig(ScriptPosition.Footer, DefaultScriptStore);
        }
    }
}