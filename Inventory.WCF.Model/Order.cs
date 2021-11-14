using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Model
{
    [DataContract]
    public class Order : BaseModel
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Quantity { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }
    }
}
