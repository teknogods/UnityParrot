using System;
using System.Globalization;
using System.IO;

namespace NekoClient.Logging
{
    public class FileLogListener : ILogListener
    {
        private StreamWriter _writer;

        public FileLogListener(string filename, bool append)
        {
            try
            {
                _writer = new StreamWriter(filename, append);
            }
            catch (IOException)
            {
                _writer = null;
            }
        }

        public void LogMessage(string source, string message, LogLevel level)
        {
            if (_writer == null)
            {
                return;
            }

            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string levelS = level.ToString().ToUpper();
            string sourceS = (source == string.Empty) ? string.Empty : ("[" + source + "]");

            //string text = string.Format("{0} - {1} - {2}: {3}", date, sourceS, levelS, message);
            string text = string.Format("{0} - {2}: {3}", date, sourceS, levelS, message);
            _writer.WriteLine(text);
            _writer.Flush();
        }

        public bool WantsFilteredMessages { get { return true; } }
    }
}