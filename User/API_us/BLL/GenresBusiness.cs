

using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class GenresBusiness : IGenresBusiness
    {
        private IGenresRepository _res;
        public GenresBusiness(IGenresRepository res)
        {
            _res = res;
        }
        public GenresModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<GenresModel> GetAll()
        {
            return _res.GetAll();
        }
        /*        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string Name)
                {
                    return _res.Search(pageIndex, pageSize, out total, Name);
                }*/
    }
}