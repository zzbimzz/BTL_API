using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IRegisterUserRepository
    {
        bool Create(RegisterUserModel model);
    }
}
