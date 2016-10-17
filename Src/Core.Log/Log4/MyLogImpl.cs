using System;
using log4net.Core;

namespace Core.Log.Log4
{
    internal class MyLogImpl : LogImpl, IMyLog
    {
        /// <summary>
        ///     The fully qualified name of this declaring type not the type of any subclass.
        /// </summary>
        private static readonly Type ThisDeclaringType = typeof (MyLogImpl);

        public MyLogImpl(ILogger logger) : base(logger)
        {
        }

        #region Implementation of IMyLog

        public void Debug(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName)
        {
            Debug(operatorId, operand, actionType, message, ip, browser, machineName, null);
        }


        public void Debug(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t)
        {
            if (IsDebugEnabled)
            {
                var loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info,
                    message, t);
                loggingEvent.Properties["Operator"] = operatorId;
                loggingEvent.Properties["Operand"] = operand;
                loggingEvent.Properties["ActionType"] = actionType;
                loggingEvent.Properties["IP"] = ip;
                loggingEvent.Properties["Browser"] = browser;
                loggingEvent.Properties["MachineName"] = machineName;
                Logger.Log(loggingEvent);
            }
        }

        public void Info(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName)
        {
            Info(operatorId, operand, actionType, message, ip, browser, machineName, null);
        }

        public void Info(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t)
        {
            if (IsInfoEnabled)
            {
                var loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info,
                    message, t);
                loggingEvent.Properties["Operator"] = operatorId;
                loggingEvent.Properties["Operand"] = operand;
                loggingEvent.Properties["ActionType"] = actionType;
                loggingEvent.Properties["IP"] = ip;
                loggingEvent.Properties["Browser"] = browser;
                loggingEvent.Properties["MachineName"] = machineName;
                Logger.Log(loggingEvent);
            }
        }


        public void Warn(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName)
        {
            Warn(operatorId, operand, actionType, message, ip, browser, machineName, null);
        }


        public void Warn(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t)
        {
            if (IsWarnEnabled)
            {
                var loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info,
                    message, t);
                loggingEvent.Properties["Operator"] = operatorId;
                loggingEvent.Properties["Operand"] = operand;
                loggingEvent.Properties["ActionType"] = actionType;
                loggingEvent.Properties["IP"] = ip;
                loggingEvent.Properties["Browser"] = browser;
                loggingEvent.Properties["MachineName"] = machineName;
                Logger.Log(loggingEvent);
            }
        }


        public void Error(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName)
        {
            Error(operatorId, operand, actionType, message, ip, browser, machineName, null);
        }


        public void Error(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t)
        {
            if (IsErrorEnabled)
            {
                var loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info,
                    message, t);
                loggingEvent.Properties["Operator"] = operatorId;
                loggingEvent.Properties["Operand"] = operand;
                loggingEvent.Properties["ActionType"] = actionType;
                loggingEvent.Properties["IP"] = ip;
                loggingEvent.Properties["Browser"] = browser;
                loggingEvent.Properties["MachineName"] = machineName;
                Logger.Log(loggingEvent);
            }
        }


        public void Fatal(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName)
        {
            Fatal(operatorId, operand, actionType, message, ip, browser, machineName, null);
        }


        public void Fatal(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t)
        {
            if (IsFatalEnabled)
            {
                var loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info,
                    message, t);
                loggingEvent.Properties["Operator"] = operatorId;
                loggingEvent.Properties["Operand"] = operand;
                loggingEvent.Properties["ActionType"] = actionType;
                loggingEvent.Properties["IP"] = ip;
                loggingEvent.Properties["Browser"] = browser;
                loggingEvent.Properties["MachineName"] = machineName;
                Logger.Log(loggingEvent);
            }
        }

        #endregion Implementation of IMyLog
    }
}