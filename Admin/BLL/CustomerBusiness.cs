

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
        public CustomerModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(CustomerModel model)
        {
            return _res.Create(model);
        }
       public bool Update(CustomerModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string Name, string Address)
        {
            return _res.Search(pageIndex, pageSize, out total, Name, Address);
        }
    }
}