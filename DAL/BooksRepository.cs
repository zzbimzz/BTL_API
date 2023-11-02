using DataModel;
using System.Collections.Generic;
using System.Linq;
using System;
//using BusinessLogicLayer;
using DAL.Interfaces;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class BooksRepository : IBooksRepository
    {
        private IDatabaseHelper _dbHelper;
        public BooksRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public BookDetailsModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_Book",
                     "@BookID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BookDetailsModel>().FirstOrDefault();
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
                "@ImageBook", model.ImageBook,
                "@AuthorID ", model.AuthorID,
                "@GenreID ", model.GenreID,
                "@SupplierID", model.SupplierID,
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
        public List<BooksModel> Search(int pageIndex, int pageSize, out long total, string Title)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_book_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Title", Title
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<BooksModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BooksModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_Book_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<BooksModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GetByGenresBookModel> getGenresBook()
        {
            string msgError = ""; 

            try
            {
                var data = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_book_by_genre"
                     );

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return data.ConvertTo<GetByGenresBookModel>().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BooksModel> GetByBookHot()
        {
            string msgError = "";

            try
            {
                var data = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_book_hot"
                     );

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return data.ConvertTo<BooksModel>().ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
