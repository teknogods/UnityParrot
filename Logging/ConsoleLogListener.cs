using System;

namespace NekoClient.Logging
{
    public class ConsoleLogListener : ILogListener
    {
        public void LogMessage(string source, string message, LogLevel level)
        {
            string levelS = level.ToString().ToUpper();
            string sourceS = (source == string.Empty) ? string.Empty : ("[" + source + "]");

            string text = string.Format("{0} - {2}", sourceS, levelS, message);
            Console.WriteLine(text);
        }

        public bool WantsFilteredMessages { get { return true; } }
    }
}