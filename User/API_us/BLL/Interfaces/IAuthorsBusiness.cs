using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IAuthorsBusiness
    {
        List<AuthorsModel> GetAll();
        List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string AuthorName);
    }
}
