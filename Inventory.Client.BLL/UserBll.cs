using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class UserBll :IUserBll
    {
        IUserDal _userDal;

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userDal.GetAll();
        }
    }
}
