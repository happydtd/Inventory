using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class UserService : BaseService
    {
        private UserService() { }

        private static UserService instance = null;

        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();
                }
                return instance;
            }
        }

        public List<User> Users { get; set; }

        public override void InitializeList()
        {
            if (Users == null)
            {
                Users = new List<User>() { 
                    new User(){Id=1, UserName="Chris"},
                    new User(){Id=2, UserName="Daniel"},
                };
            }
        }
    }
}
