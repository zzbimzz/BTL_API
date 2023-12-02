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
        public CustomerModel GetDatabyID(int id)
        {
            return _customerBusiness.GetDatabyID(id);
        }


    }
}
