using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Model
{
    [DataContract]
    public class Product : BaseModel
    {
        [DataMember]
        public string ProductName { get; set; }

    }
}
