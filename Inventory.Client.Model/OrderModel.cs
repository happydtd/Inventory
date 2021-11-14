using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.Model
{
    public class OrderModel : BaseModel
    {
        public int ProductId { get; set; }
        public string Quantity { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
