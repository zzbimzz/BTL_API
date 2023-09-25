using DataModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDatabaseHelper _dbHelper;
        public CustomerRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public CustomerModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CustomerModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(CustomerModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_create",
                "@TenKH", model.TenKH,
                "@GioiTinh", model.GioiTinh,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
                "@Email", model.Email);
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
        public bool Update(CustomerModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_update",
                "@Id", model.Id,
                "@TenKH", model.TenKH,
                "@GioiTinh", model.GioiTinh,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
                "@Email", model.Email);
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

        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_khach", ten_khach,
                    "@dia_chi", dia_chi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CustomerModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
