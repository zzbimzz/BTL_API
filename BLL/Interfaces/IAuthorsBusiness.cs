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
        AuthorsModel GetDatabyID(int id);
        bool Create(AuthorsModel model);
        bool Update(AuthorsModel model);
        bool Delete(int id);
/*        List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string Name);*/
    }
}
