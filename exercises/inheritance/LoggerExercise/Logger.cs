using System;
using System.Collections.Generic;
using System.IO;

namespace LoggerExercise
{
    public abstract class Logger
    {
        public abstract void Log(string message);
        public virtual void Close() { }
    }

    public class NullLogger : Logger
    {
        public override void Log(string message)
        {}
    }

    public class StreamLogger : Logger
    {
        private readonly StreamWriter writer;

        public StreamLogger(StreamWriter writer)
        {
            this.writer = writer;
        }
        public override void Log(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
    }

    public class FileLogger : StreamLogger
    {
        private FileStream FileStream;
        private FileLogger(FileStream fileStream) : base(new StreamWriter(fileStream))
        {
            this.FileStream = fileStream;
        }

        public static Logger Create(string filename)
        {
            var fileStream = File.OpenWrite(filename);
            return new FileLogger(fileStream);
        }

        public override void Close()
        {
            this.FileStream.Close();
        }
    }

    public class LogBroadcaster : Logger
    {
        private IEnumerable<Logger> loggers;
        public LogBroadcaster(IEnumerable<Logger> loggers)
        {
            this.loggers = loggers;
        }
        public override void Log(string message)
        {
            foreach(Logger logger in loggers)
            {
                logger.Log(message);
            }
        }
    }
}