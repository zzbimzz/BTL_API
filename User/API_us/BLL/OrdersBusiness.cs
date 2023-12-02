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
        public PrintOrderModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }

        public bool Create(OrderModel model)
        {
            return _res.Create(model);
        }

    }
}