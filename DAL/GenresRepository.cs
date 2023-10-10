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
        public bool Create(GenresModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_AddNewGenre",
                "@GenreName", model.GenreName);


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
        public bool Update(GenresModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateGenre",
                "@GenreID", model.GenreID,
                "@GenreName", model.GenreName);

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
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DeleteGenre",
                     "@GenreID", id);
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
