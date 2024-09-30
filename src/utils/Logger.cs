using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osussist.src.utils
{
	public class Logger
	{
		public bool FileLogging;
		public string LogFile;
		public int LogLevel;

		public static Logger LoggingInstance { get; set; }

		public Logger (bool fileLogging, string logFile, int logLevel) 
		{

            if (LoggingInstance != null)
                throw new Exception("Logger instance already exists!");

			FileLogging = fileLogging;
			LogFile = logFile;
			LogLevel = logLevel;

			LoggingInstance = this;
		}

		public void Error (string traceback, string message)
		{
            try
            {
                if (LogLevel >= (int)LogLevels.ERROR)
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string completeMessage = $"[{timestamp}] [ERROR] | {traceback} - {message}";

                    Console.WriteLine(completeMessage);
                    if (FileLogging)
                        FileLogger(completeMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to log error: {e.Message}");
            }

        }

		public void Info (string traceback, string message)
		{
            try
            {
                if (LogLevel >= (int)LogLevels.INFO)
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string completeMessage = $"[{timestamp}] [INFO]  | {traceback} - {message}";

                    Console.WriteLine(completeMessage);
                    if (FileLogging)
                        FileLogger(completeMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to log info: {e.Message}");
            }
        }

		public void Warning (string traceback, string message)
		{
            try
            {
                if (LogLevel >= (int)LogLevels.WARNING)
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string completeMessage = $"[{timestamp}] [WARN]  | {traceback} - {message}";

                    Console.WriteLine(completeMessage);
                    if (FileLogging)
                        FileLogger(completeMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to log warning: {e.Message}");
            }
        }

		public void Debug (string traceback, string message)
		{
            try
            {
                if (LogLevel >= (int)LogLevels.DEBUG)
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string completeMessage = $"[{timestamp}] [DEBUG] | {traceback} - {message}";

                    Console.WriteLine(completeMessage);
                    if (FileLogging)
                        FileLogger(completeMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to log debug: {e.Message}");
            }
        }

		private void FileLogger(string message)
		{
            try
            {
                File.AppendAllText(LogFile, message + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to log to file: {e.Message}");
            }
        }
	}
    public enum LogLevels
    {
        DISABLED,
        ERROR,
        WARNING,
        INFO,
        DEBUG
    }
}
