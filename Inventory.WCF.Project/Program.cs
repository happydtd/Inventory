using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceInit.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
