using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICustomerBusiness
    {
        CustomerModel GetDatabyID(string id);
        /*bool Create(CustomerModel model);
        bool Update(CustomerModel model);
        List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi);*/
    }
}
