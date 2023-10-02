

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
        public bool Create(GenresModel model)
        {

            return _res.Create(model);
        }
        public bool Update(GenresModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        /*        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string Name)
                {
                    return _res.Search(pageIndex, pageSize, out total, Name);
                }*/
    }
}