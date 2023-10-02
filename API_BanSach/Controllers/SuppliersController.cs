using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace API_BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private ISuppliersBusiness _supplieBusiness;
        public SuppliersController(ISuppliersBusiness nccBusiness)
        {
            _supplieBusiness = nccBusiness;
        }
        [Route("get-supplie/{id}")]
        [HttpGet]
        public SuppliersModel GetDatabyID(int id)
        {
            return _supplieBusiness.GetDatabyID(id);
        }
        [Route("create-supplie")]
        [HttpPost]
        public SuppliersModel CreateItem([FromBody] SuppliersModel model)
        {
            _supplieBusiness.Create(model);
            return model;
        }
        [Route("update-supplie")]
        [HttpPost]
        public SuppliersModel UpdateItem([FromBody] SuppliersModel model)
        {
            _supplieBusiness.Update(model);
            return model;
        }
        [Route("delete-supplie")]
        [HttpPost]
        public bool DeleteID(int id)
        {
            return _supplieBusiness.Delete(id);
        }
    }
}
