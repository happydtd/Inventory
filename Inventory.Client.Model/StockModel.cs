using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.Model
{
    public class StockModel : BaseModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
