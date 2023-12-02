

using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class SuppliersBusiness : ISuppliersBusiness
    {
        private ISuppliersRepository _res;
        public SuppliersBusiness(ISuppliersRepository res)
        {
            _res = res;
        }
        public SuppliersModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(SuppliersModel model)
        {

            return _res.Create(model);
        }
        public bool Update(SuppliersModel model)
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