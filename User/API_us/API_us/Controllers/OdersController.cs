using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdersController : ControllerBase
    {
        private IOrdersBusiness _hoadonBusiness;

        public OdersController(IOrdersBusiness hoadonBusiness)
        {
            _hoadonBusiness = hoadonBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public PrintOrderModel GetDatabyID(int id)
        {
            return _hoadonBusiness.GetDatabyID(id);
        }

        [Route("create-hoadon")]
        [HttpPost]
        public OrderModel CreateItem([FromBody] OrderModel model)
        {
            _hoadonBusiness.Create(model);
            return model;
        }






    }
}
