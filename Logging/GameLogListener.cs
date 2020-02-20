namespace NekoClient.Logging
{
    public class GameLogListener : ILogListener
    {
        public void LogMessage(string source, string message, LogLevel level)
        {
            UnityEngine.Debug.Log($"[{source}:{level.ToString()}] {message}");
        }

        public bool WantsFilteredMessages { get { return true; } }
    }
}