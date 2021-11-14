﻿using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.Interface
{
    public interface IProductDal
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
