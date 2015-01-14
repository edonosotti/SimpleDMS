using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleDMS
{
    public class LogManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public enum LogType
        {
            General = 0,
            Data = 1,
            Content = 2,
            Storage = 3,
            Client = 4
        }

        public static void Debug(LogType logType, string message)
        {
            log.DebugFormat("({0}) {1}", logType, message);
        }
        
        public static void Debug(LogType logType, Exception error)
        {
            var message = string.Format("({0}) {1}", logType, error.Message);

            while (error.InnerException != null)
            {
                error = error.InnerException;
                message += "\n\nINNER: " + error.Message;
            }

            log.Debug(message, error);
        }

        public static void Info(LogType logType, string message)
        {
            log.InfoFormat("({0}) {1}", logType, message);
        }

        public static void Info(LogType logType, Exception error)
        {
            var message = string.Format("({0}) {1}", logType, error.Message);

            while (error.InnerException != null)
            {
                error = error.InnerException;
                message += "\n\nINNER: " + error.Message;
            }

            log.Info(message, error);
        }

        public static void Warn(LogType logType, string message)
        {
            log.WarnFormat("({0}) {1}", logType, message);
        }

        public static void Warn(LogType logType, Exception error)
        {
            var message = string.Format("({0}) {1}", logType, error.Message);

            while (error.InnerException != null)
            {
                error = error.InnerException;
                message += "\n\nINNER: " + error.Message;
            }

            log.Warn(message, error);
        }

        public static void Error(LogType logType, string message)
        {
            log.ErrorFormat("({0}) {1}", logType, message);
        }

        public static void Error(LogType logType, Exception error)
        {
            var message = string.Format("({0}) {1}", logType, error.Message);

            while (error.InnerException != null)
            {
                error = error.InnerException;
                message += "\n\nINNER: " + error.Message;
            }

            log.Error(message, error);
        }

        public static void Fatal(LogType logType, string message)
        {
            log.FatalFormat("({0}) {1}", logType, message);
        }

        public static void Fatal(LogType logType, Exception error)
        {
            var message = string.Format("({0}) {1}", logType, error.Message);

            while (error.InnerException != null)
            {
                error = error.InnerException;
                message += "\n\nINNER: " + error.Message;
            }

            log.Fatal(message, error);
        }

        public static string GetSerializedValue(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
