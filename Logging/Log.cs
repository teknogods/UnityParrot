using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace NekoClient.Logging
{
    public static class Log
    {
        private static List<ILogListener> _listeners;
        private static LogLevel _filter;

        public static void Initialize(LogLevel filter)
        {
            _listeners = new List<ILogListener>();
            _filter = filter;
        }

        public static void AddListener(ILogListener listener)
        {
            _listeners.Add(listener);
        }

        public static void Write(LogLevel level, string message, params object[] args)
        {
            Write(level, string.Format(message, args));
        }

        public static void Write(LogLevel level, string message)
        {
            // get the source
            string source = GetSource();

            // check filteredness
            bool isAllowed = IsLevelAllowed(level);

            // and, well, what do we do next? transmit it to all the listeners?
            foreach (ILogListener listener in _listeners)
            {
                if (!listener.WantsFilteredMessages || isAllowed)
                {
                    listener.LogMessage(source, message, level);
                }
            }
        }

        public static void Debug(string message)
        {
            Write(LogLevel.Debug, message);
        }

        public static void Debug(string format, params object[] args)
        {
            Debug(String.Format(format, args));
        }

        public static void Info(string message)
        {
            Write(LogLevel.Info, message);
        }

        public static void Info(string format, params object[] args)
        {
            Info(String.Format(format, args));
        }

        public static void Error(string message)
        {
            Write(LogLevel.Error, message);
        }

        public static void Error(Exception e)
        {
            Error(e.ToString());
        }

        public static void Error(string format, params object[] args)
        {
            Error(String.Format(format, args));
        }

        private static bool IsLevelAllowed(LogLevel level)
        {
            return (_filter & level) == level;
        }

        private static string GetSource()
        {
            // skip 2 frames: GetSource and its caller
            StackTrace trace = new StackTrace(2);
            StackFrame[] frames = trace.GetFrames();

            // might not need a foreach, but doing to to be sure
            foreach (StackFrame frame in frames)
            {
                MethodBase method = frame.GetMethod();
                Type type = method.DeclaringType;

                Assembly assembly = type.Assembly;

                // only remove System?
                if (assembly.GetName().Name == "System")
                {
                    continue;
                }

                // in case there are > 2 frames
                if (type.Name == "Log")
                {
                    continue;
                }

                string method_t = method.Name;
                if (method_t == ".ctor") method_t = type.Name; // contructor

                method_t = method_t.Replace("<", "").Replace(">g__", "::").Split('|')[0]; // clean up nested funcs

                // that sounds just about nice
                return string.Format("{0}::{1}", type.Name, method_t);
            }

            return "";
        }
    }
}