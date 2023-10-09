using DataModel;
using System.Collections.Generic;
using System.Linq;
using System;
using BusinessLogicLayer;
using DAL.Interfaces;

namespace DataAccessLayer
{
    public class BooksRepository : IBooksRepository
    {
        private IDatabaseHelper _dbHelper;
        public BooksRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public BooksModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_Book",
                     "@BookID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BooksModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(BooksModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_AddNewBook",
                "@Title", model.Title,
                "@AuthorID ", model.AuthorID,
                "@GenreID ", model.GenreID,
                "@Price", model.Price,
                "@Stock", model.Stock
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
        public bool Update(BooksModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateBook",
                "@BookID", model.BookID,
                "@Title", model.Title,
                "@AuthorID ", model.AuthorID,
                "@GenreID ", model.GenreID,
                "@Price", model.Price,
                "@Stock", model.Stock);

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
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DeleteBook",
                     "@BookID", id);
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
