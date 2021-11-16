using Inventory.Client.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.WPF
{
    public class LogHelper : ILogHelper
    {
        public void Debug(object source, string msg)
        {
            log4net.ILog Logger = LogManager.GetLogger(source.GetType());
            Logger.Debug(msg);

        }

        public void Error(object source, string msg)
        {
            log4net.ILog Logger = LogManager.GetLogger(source.GetType());
            Logger.Error(msg);
        }

        public void Info(object source, string msg)
        {
            log4net.ILog Logger = LogManager.GetLogger(source.GetType());
            Logger.Info(msg);
        }
    }
}
