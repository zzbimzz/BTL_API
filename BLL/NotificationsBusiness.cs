

using DataAccessLayer;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class NotificationsBusiness : INotificationsBusiness
    {
        private INotificationsRepository _res;
        public NotificationsBusiness(INotificationsRepository res)
        {
            _res = res;
        }
        public NotificationsModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NotificationsModel model)
        {

            return _res.Create(model);
        }
        public bool Update(NotificationsModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<NotificationsModel> GetAll()
        {
            return _res.GetAll();
        }
        /*        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string Name)
                {
                    return _res.Search(pageIndex, pageSize, out total, Name);
                }*/
    }
}