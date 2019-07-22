using System;

namespace Coveoticore.Benchmarks.Logger
{
    public class Logger : ILogger
    {
        private readonly Type m_LoggerType;

        public Logger(Type p_LoggerType)
        {
            m_LoggerType = p_LoggerType;
        }

        public void Info(string p_Message)
        {
            Sitecore.Diagnostics.Log.Info(p_Message, m_LoggerType);
        }
    }

    public interface ILogger
    {
        void Info(string p_Message);
    }
}