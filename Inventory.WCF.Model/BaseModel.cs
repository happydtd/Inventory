using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Model
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; set; }
    }
}
