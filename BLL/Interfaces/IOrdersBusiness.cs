using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IOrdersBusiness
    {
        OrderModel GetDatabyID(int id);
        bool Create(OrderModel model);
        bool Update(OrderModel model);
        public List<StatiѕticModel> Search(int pageIndex, int pageSize, out long total, DateTime? from_date, DateTime? to_date);
    }
}
