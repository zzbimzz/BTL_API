

using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerRepository _res;
        public CustomerBusiness(ICustomerRepository res)
        {
            _res = res;
        }
        public CustomerModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        /*public bool Create(CustomerModel model)
        {
            return _res.Create(model);
        }
        public bool Update(CustomerModel model)
        {
            return _res.Update(model);
        }
        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach, dia_chi);
        }*/
    }
}