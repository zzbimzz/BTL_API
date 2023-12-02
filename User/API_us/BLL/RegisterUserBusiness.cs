
using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class RegisterUserBusiness : IRegisterUserBusiness
    {
        private IRegisterUserRepository _res;
        public RegisterUserBusiness(IRegisterUserRepository res)
        {
            _res = res;
        }

        public bool Create(RegisterUserModel model)
        {
            return _res.Create(model);
        }

    }
}