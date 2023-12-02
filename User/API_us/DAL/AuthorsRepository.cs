using DataModel;
using System.Collections.Generic;
using System.Linq;
using System;
using BusinessLogicLayer;

namespace DataAccessLayer
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private IDatabaseHelper _dbHelper;
        public AuthorsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public List<AuthorsModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_Author_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<AuthorsModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string AuthorName)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_author_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@AuthorName", AuthorName
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<AuthorsModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
