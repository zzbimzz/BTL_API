using DataModel;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private IDatabaseHelper _dbHelper;
        public RegisterUserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(RegisterUserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "RegisterUserAndCustomer",

                "@UserName", model.UserName,
                "@PassWord", model.PassWord,
                "@Name", model.Name,
                "@Email", model.Email,
                "@Phone", model.Phone,
                "@Address", model.Address);


                if (result != null && !string.IsNullOrEmpty(result.ToString()) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }












    }
}
