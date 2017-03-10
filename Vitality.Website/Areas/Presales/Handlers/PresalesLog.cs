using log4net;

namespace Vitality.Website.Areas.Presales.Handlers
{
    public static class PresalesLog
    {
        private static ILog _log;

        public static ILog Log
        {
            get { return _log ?? (_log = LogManager.GetLogger(typeof(PresalesLog))); }
        }
    }
}
