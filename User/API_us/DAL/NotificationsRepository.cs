using DataModel;
using System.Collections.Generic;
using System.Linq;
using System;
using BusinessLogicLayer;

namespace DataAccessLayer
{
    public class NotificationsRepository : INotificationsRepository
    {
        private IDatabaseHelper _dbHelper;
        public NotificationsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }



        public List<NotificationsModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _dbHelper.ExecuteQuery("sp_Notifi_getAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<NotificationsModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
