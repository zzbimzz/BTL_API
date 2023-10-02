

using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class AuthorsBusiness : IAuthorsBusiness
    {
        private IAuthorsRepository _res;
        public AuthorsBusiness(IAuthorsRepository res)
        {
            _res = res;
        }
        public AuthorsModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(AuthorsModel model)
        {

            return _res.Create(model);
        }
        public bool Update(AuthorsModel model)
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