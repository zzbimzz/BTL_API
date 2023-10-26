using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBooksBusiness
    {
        BooksModel GetDatabyID(int id);
        bool Create(BooksModel model);
        bool Update(BooksModel model);
        bool Delete(int id);
        List<BooksModel> GetAll();

        List<BooksModel> GetByBookHot();
        List<GetByGenresBookModel> getGenresBook();


        List<BooksModel> Search(int pageIndex, int pageSize, out long total, string Title);
    }
}
