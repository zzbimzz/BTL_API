using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IUsersBusiness
    {
/*        public UsersModel GetLoginbyId(string id);
        bool Create(UsersModel model);
        bool Update(UsersModel model);*/
        UsersModel Login(string taikhoan, string matkhau);
    }
}
