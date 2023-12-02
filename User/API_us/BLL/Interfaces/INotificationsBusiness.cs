using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface INotificationsBusiness
    {

        List<NotificationsModel> GetAll();
        /*        List<AuthorsModel> Search(int pageIndex, int pageSize, out long total, string Name);*/
    }
}
