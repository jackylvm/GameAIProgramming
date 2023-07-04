using System;
using System.Collections.Generic;
using UnityEngine;

namespace MS.Log4Unity
{
    public static class AppendersRegister
    {
        private static Dictionary<string, Type> _appenderTypes = new Dictionary<string, Type>();

        static AppendersRegister()
        {
            RegisterAppenderType("UnityLogAppender", typeof(UnityLogAppender));
            RegisterAppenderType("FileAppender", typeof(FileAppender));
            RegisterAppenderType("CatagoryFilterAppender", typeof(CatagoryFilterAppender));
        }

        public static void RegisterAppenderType(string typeName, Type type)
        {
            _appenderTypes.Add(typeName, type);
        }

        internal static Type TryGetAppenderType(string typeName)
        {
            Type type = null;
            if (_appenderTypes.TryGetValue(typeName, out type))
            {
                return type;
            }

            return type;
        }
    }

    internal class AppendersManager
    {
        private static Dictionary<string, IAppender> _appenders = new Dictionary<string, IAppender>();

        private static Type TryGetAppenderType(string typeName)
        {
            Type type = AppendersRegister.TryGetAppenderType(typeName);
            if (type != null)
            {
                return type;
            }

            string fullTypeName = Configurator.GetAppenderTypeFullName(typeName);
            if (fullTypeName != null)
            {
                type = Type.GetType(typeName);
            }

            if (type == null)
            {
                type = Type.GetType(typeName);
            }

            return type;
        }

        public static IAppender GetAppender(string appenderName)
        {
            if (_appenders.ContainsKey(appenderName))
            {
                return _appenders[appenderName];
            }

            var appenderCfg = Configurator.GetAppender(appenderName);
            if (appenderCfg == null)
            {
                Debug.LogWarning("unknown appender name:" + appenderName);
                return null;
            }

            var tp = TryGetAppenderType(appenderCfg.type);
            if (tp == null)
            {
                Debug.LogWarning("unknown appender type:" + appenderCfg.type);
                return null;
            }

            var appender = Activator.CreateInstance(tp) as IAppender;
            appender.OnInitialize(appenderCfg.GetConfigsReader());
            _appenders.Add(appenderName, appender);
            return appender;
        }
    }
}