using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.Interface
{
    public interface ILogHelper
    {
        void Debug(object source, string msg);

        void Info(object source, string msg);

        void Error(object source, string msg);
    }
}
