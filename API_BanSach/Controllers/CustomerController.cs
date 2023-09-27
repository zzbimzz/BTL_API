using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness _customerBusiness;
        public CustomerController(ICustomerBusiness khachBusiness)
        {
            _customerBusiness = khachBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public CustomerModel GetDatabyID(string id)
        {
            return _customerBusiness.GetDatabyID(id);
        }
        /*[Route("create-khach")]
        [HttpPost]*/
        /*public CustomerModel CreateItem([FromBody] CustomerModel model)
        {
            _customerBusiness.Create(model);
            return model;
        }
        [Route("update-khach")]
        [HttpPost]
        public CustomerModel UpdateItem([FromBody] CustomerModel model)
        {
            _customerBusiness.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_khach = "";
                if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
                string dia_chi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
                long total = 0;
                var data = _customerBusiness.Search(page, pageSize, out total, ten_khach, dia_chi);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }*/
        /*}*/
    }
}
