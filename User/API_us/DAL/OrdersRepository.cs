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


        public PrintOrderModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_get_by_id",
                     "@OrderID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PrintOrderModel>().FirstOrDefault();
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












    }
}
