﻿using System;
using MS.Log4Unity.Configurations;
using UnityEngine;

namespace MS.Log4Unity
{
    public struct LogEvent
    {
        public ULogger logger;
        public LogType logType;
        public object message;
    }

    public interface IAppender
    {
        void OnInitialize(ConfigsReader configs);

        bool HandleLogEvent(ref LogEvent logEvent);


        Env env { get; set; }
    }

    public abstract class BaseAppender : IAppender
    {
        public Env env { get; set; }

        public LogLevel logLevel { get; set; }

        public virtual void OnInitialize(ConfigsReader configs)
        {
            var envStr = configs.GetString("env", null);
            if (envStr == null)
            {
                this.env = Env.All;
            }
            else
            {
                Env ret;
                if (Enum.TryParse<Env>(envStr, true, out ret))
                {
                    this.env = ret;
                }
                else
                {
                    Debug.LogWarning($"failed to parse {envStr} to Env");
                    this.env = Env.All;
                }
            }

            this.logLevel = Configurator.ParseLogLevel(configs.GetString("level", null));
        }


        public virtual bool HandleLogEvent(ref LogEvent logEvent)
        {
            return CheckEnv() && CheckLevel(logEvent.logType);
        }

        private bool CheckLevel(LogType logType)
        {
            return Configurator.CheckLogOn(logType, this.logLevel);
        }

        private bool CheckEnv()
        {
#if UNITY_EDITOR
            return (this.env & Env.EditorPlayer) == Env.EditorPlayer;
#else
            return (this.env & Env.BuiltPlayer) == Env.BuiltPlayer;
#endif
        }
    }


    public abstract class LayoutAppender : BaseAppender
    {
        private Layout _layout;

        public override void OnInitialize(ConfigsReader configs)
        {
            base.OnInitialize(configs);
            if (configs.Has("layout"))
            {
                var dict = configs.GetConfigs("layout");
                _layout = new Layout(dict);
            }
            else
            {
                _layout = new Layout();
            }
        }

        private string FormatMessage(ULogger logger, LogType type, object message)
        {
            return PatternHelper.FormatWithLayout(_layout, logger, type, message);
        }

        public override bool HandleLogEvent(ref LogEvent logEvent)
        {
            if (base.HandleLogEvent(ref logEvent))
            {
                logEvent.message = FormatMessage(logEvent.logger, logEvent.logType, logEvent.message);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}