using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public delegate void EventLog(string message);
    public delegate void ExceptionLog(Exception ex);

    class Log
    {
        public static event EventLog Logger;
        public static event ExceptionLog ExceptionLogger;

        public static void Message(String message)
        {
            if (Logger != null)
            {
                lock (Logger)
                {
                    Logger(message + Environment.NewLine);
                }
            }
        }

        public static void Exception(Exception ex)
        {
            if (ExceptionLogger != null)
            {
                lock (ExceptionLogger)
                {
                    ExceptionLogger(ex);
                }
            }
        }
    }
}
