using DataModel;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class OrdersRepository : IOrdersRepository
    {
        private IDatabaseHelper _dbHelper;
        public OrdersRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public GetOrderDetailsModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_get_by_id",
                     "@OrderID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GetOrderDetailsModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(OrderModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadon_create",
                "@CustomerID", model.CustomerID,
                "@StatusOrder", model.StatusOrder,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? JsonConvert.SerializeObject(model.list_json_chitiethoadon) : null);

                if (result != null && !string.IsNullOrEmpty(result.ToString()) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(OrderModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadon_update",
                "@OrderID", model.OrderID,
                "@CustomerID", model.CustomerID,
                "@StatusOrder", model.StatusOrder,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? JsonConvert.SerializeObject(model.list_json_chitiethoadon) : null);

                if (result != null && !string.IsNullOrEmpty(result.ToString()) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_delete",
                     "@OrderID", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StatiѕticModel> ThongKe(int pageIndex, int pageSize, out long total, DateTime? from_date, DateTime? to_date)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_khach",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@from_date", from_date,
                    "@to_date", to_date
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                    return dt.ConvertTo<StatiѕticModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SearchOrderModel> Search(int pageIndex, int pageSize, out long total, string name)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_order_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@CustomerName", name
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SearchOrderModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
