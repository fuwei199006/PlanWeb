using System;

namespace Core.Log.Log4
{
    internal interface IMyLog
    {
        void Debug(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName);

        void Debug(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t);

        void Info(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName);

        void Info(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t);

        void Warn(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName);

        void Warn(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t);  

        void Error(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName);

        void Error(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t);

        void Fatal(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName);

        void Fatal(int operatorId, string operand, int actionType, object message, string ip, string browser,
            string machineName, Exception t);
    }
}