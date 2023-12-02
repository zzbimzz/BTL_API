using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IUsersRepository
    {
        UsersModel Login(string taikhoan, string matkhau);
        /*UsersModel GetDatabyID(int id);
        bool Create(UsersModel model);
        bool Update(UsersModel model);
        bool Delete(int id);
                List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string Name);*/
    }
}
