using System.Runtime.Serialization;

namespace WebApiJwtAuthentication.Logging
{
    public sealed class SimpleLogger
    {
        private static SimpleLogger _instance;
        private static object _lock = new object();



        private SimpleLogger()  { }

        public static SimpleLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SimpleLogger();
                        }
                    }
                }
                return _instance;
            }
        }




        public Level CurrentLogLevel { get; set; } = Level.INFO;



        public void Log(Level level, string message)
        {
            if (level >= CurrentLogLevel)
            {
                Console.WriteLine($"[{level}] {message}");
            }
        }




        //
        // Сводка:
        //     Defines logging severity levels.
        public enum Level
        {
            //
            // Сводка:
            //     Logs that contain the most detailed messages. These messages may contain sensitive
            //     application data. These messages are disabled by default and should never be
            //     enabled in a production environment.
            TRACE = 0,
            //
            // Сводка:
            //     Logs that are used for interactive investigation during development. These logs
            //     should primarily contain information useful for debugging and have no long-term
            //     value.
            DEBUG = 1,
            //
            // Сводка:
            //     Logs that track the general flow of the application. These logs should have long-term
            //     value.
            INFO = 2,
            //
            // Сводка:
            //     Logs that highlight an abnormal or unexpected event in the application flow,
            //     but do not otherwise cause the application execution to stop.
            WARNING = 3,
            //
            // Сводка:
            //     Logs that highlight when the current flow of execution is stopped due to a failure.
            //     These should indicate a failure in the current activity, not an application-wide
            //     failure.
            ERROR = 4,
            //
            // Сводка:
            //     Logs that describe an unrecoverable application or system crash, or a catastrophic
            //     failure that requires immediate attention.
            CRITICAL = 5,
            //
            // Сводка:
            //     Not used for writing log messages. Specifies that a logging category should not
            //     write any messages.
            NONE = 6
        }
    }
}

