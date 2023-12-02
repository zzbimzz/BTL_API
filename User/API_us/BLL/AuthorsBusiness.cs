

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
        public List<AuthorsModel> GetAll()
        {
            return _res.GetAll();
        }
        public List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string AuthorName)
        {
            return _res.Search(pageIndex, pageSize, out total, AuthorName);
        }
    }
}