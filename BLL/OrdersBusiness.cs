using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class OrdersBusiness : IOrdersBusiness
    {
        private IOrdersRepository _res;
        public OrdersBusiness(IOrdersRepository res)
        {
            _res = res;
        }

        public OrderModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(OrderModel model)
        {
            return _res.Create(model);
        }
        public bool Update(OrderModel model)
        {
            return _res.Update(model);
        }
        public List<StatiѕticModel> Search(int pageIndex, int pageSize, out long total, DateTime? from_date, DateTime? to_date)
        {
            return _res.Search(pageIndex, pageSize, out total, from_date, to_date);
        }
    }
}