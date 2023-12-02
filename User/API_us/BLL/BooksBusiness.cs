

using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class BooksBusiness : IBooksBusiness
    {
        private IBooksRepository _res;
        public BooksBusiness(IBooksRepository res)
        {
            _res = res;
        }
        public BookDetailsModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<BooksModel> Search(int pageIndex, int pageSize, out long total, string Title)
        {
            return _res.Search(pageIndex, pageSize, out total, Title);
        }

        public List<GetByGenresBookModel> getGenresBook()
        {
            return _res.getGenresBook();
        }

        public List<BooksModel> GetAll()
        {
            return _res.GetAll();
        }
        public List<BooksModel> GetByBookHot()
        {
            return _res.GetByBookHot();
        }
    }
}