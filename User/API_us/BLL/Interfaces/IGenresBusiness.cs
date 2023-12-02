using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IGenresBusiness
    {
        GenresModel GetDatabyID(int id);

        List<GenresModel> GetAll();
        /*        List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string Name);*/
    }
}
