

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