using DataModel;
using System.Collections.Generic;
using System.Linq;
using System;
using BusinessLogicLayer;

namespace DataAccessLayer
{
    public class GenresRepository : IGenresRepository
    {
        private IDatabaseHelper _dbHelper;
        public GenresRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public GenresModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_genre",
                     "@GenreID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GenresModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GenresModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_Genre_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<GenresModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
