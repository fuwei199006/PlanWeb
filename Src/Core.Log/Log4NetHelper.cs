﻿using System;
using System.IO;
using System.Text;
using Core.Config;
using Core.Encrypt;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace Core.Log
{
    public static class Log4NetHelper
    {
        static Log4NetHelper()
        {
            //初始化log4net配置
            var config = LocalCachedConfigContext.Current.ConfigService.GetConfig("LOG-LOG4NET");
            //测试配置
            //var config = File.ReadAllText("Log4net.xml");
            //重写log4net配置里的连接字符串
            config = config.Replace("{connectionString}",
                DESEncrypt.Decode(LocalCachedConfigContext.Current.DaoConfig.Log));
            var ms = new MemoryStream(Encoding.Default.GetBytes(config));
            XmlConfigurator.Configure(ms);
        }

        public static void Debug(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Debug(SerializeObject(message), e); //123test
        }

        public static void Error(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Error(SerializeObject(message), e);
        }

        public static void Info(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Info(SerializeObject(message), e);
        }

        public static void Fatal(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Fatal(SerializeObject(message), e);
        }

        public static void Warn(LoggerType loggerType, object message, Exception e)
        {
            var logger = LogManager.GetLogger(loggerType.ToString());
            logger.Warn(SerializeObject(message), e);
        }

        private static object SerializeObject(object message)
        {
            if (message is string || message == null)
                return message;
            return JsonConvert.SerializeObject(message,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        }
    }

    public enum LoggerType
    {
        WebExceptionLog,
        ServiceExceptionLog
    }
}