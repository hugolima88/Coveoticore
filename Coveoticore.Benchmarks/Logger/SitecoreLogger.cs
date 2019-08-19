using System;

namespace Coveoticore.Benchmarks.Logger
{
    public class SitecoreLogger : ILogger
    {
        private readonly Type m_LoggerType;

        public SitecoreLogger(Type p_LoggerType)
        {
            m_LoggerType = p_LoggerType;
        }

        public void Info(string p_Message)
        {
            Sitecore.Diagnostics.Log.Info(p_Message, m_LoggerType);
        }
    }
}