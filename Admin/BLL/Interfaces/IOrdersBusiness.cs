﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IOrdersBusiness
    {
        GetOrderDetailsModel GetDatabyID(int id);
        bool Create(OrderModel model);
        bool Update(OrderModel model);
        bool Delete(int id);
        List<GetOrderDetailsModel> GetAll();
        public List<StatiѕticModel> ThongKe(int pageIndex, int pageSize, out long total, DateTime? from_date, DateTime? to_date);
        public List<SearchOrderModel> Search(int pageIndex, int pageSize, out long total, string name);
    }
}
