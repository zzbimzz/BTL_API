using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private ICartsBusiness _cartsBusiness;

        public CartsController(ICartsBusiness giohangBusiness)
        {
            _cartsBusiness = giohangBusiness;
        }
        [Route("get-all")]
        [HttpGet]
        public List<CartsModel> GetAll()
        {
            return _cartsBusiness.GetAll();
        }
    }
}