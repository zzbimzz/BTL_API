using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IBooksRepository
    {
        BooksModel GetDatabyID(int id);
        bool Create(BooksModel model);
        bool Update(BooksModel model);
        bool Delete(int id);
    }
}
