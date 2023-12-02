using DataModel;

namespace DataAccessLayer
{
    public class UsersRepository : IUsersRepository
    {
        private IDatabaseHelper _dbHelper;
        public UsersRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public UsersModel Login(string taikhoan, string matkhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@Username", taikhoan,
                     "@Password", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UsersModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(UsersModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_add_login",
                "@Username", model.Username,
                "@Password", model.Password,
                "@Role ", model.Role

                );


                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
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
