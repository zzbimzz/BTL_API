using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private IRegisterUserBusiness _dangkyBusiness;

        public RegisterUserController(IRegisterUserBusiness hoadonBusiness)
        {
            _dangkyBusiness = hoadonBusiness;
        }

        [Route("create-registerUser")]
        [HttpPost]
        public RegisterUserModel CreateItem([FromBody] RegisterUserModel model)
        {
            _dangkyBusiness.Create(model);
            return model;
        }






    }
}
