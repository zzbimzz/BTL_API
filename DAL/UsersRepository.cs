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
    }
}
