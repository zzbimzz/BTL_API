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
        public CustomerModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_customer_get_by_id",
                     "@UserID", id);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_AddNewCustomer",
                "@Name", model.Name,
                "@Email", model.Email,
                "@Phone", model.Phone,  
                "@Address", model.Address);

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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateCustomer",
                "@CustomerID", model.CustomerID,
                "@Name", model.Name,
                "@Email", model.Email,
                "@Phone", model.Phone,
                "@Address", model.Address);
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
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DeleteCustomer",
                     "@CustomerID", id);
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

        public List<CustomerModel> Search(int pageIndex, int pageSize, out long total, string Name, string Address)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_customer_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Name", Name,
                    "@Address", Address);
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
