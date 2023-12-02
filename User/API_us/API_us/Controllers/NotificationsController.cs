using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private INotificationsBusiness _notificationsBusiness;
        public NotificationsController(INotificationsBusiness thongbaoBusiness)
        {
            _notificationsBusiness = thongbaoBusiness;
        }

       
        [Route("getAll-notifi")]
        [HttpGet]
        public List<NotificationsModel> GetAll()
        {
            return _notificationsBusiness.GetAll();
        }
        /*       [Route("search")]
               [HttpPost]
               public IActionResult Search([FromBody] Dictionary<string, object> formData)
               {
                   try
                   {
                       var page = int.Parse(formData["page"].ToString());
                       var pageSize = int.Parse(formData["pageSize"].ToString());
                       string Name = "";
                       if (formData.Keys.Contains("Name") && !string.IsNullOrEmpty(Convert.ToString(formData["Name"]))) { Name = Convert.ToString(formData["Name"]); }
                       string Address = "";
                       if (formData.Keys.Contains("Address") && !string.IsNullOrEmpty(Convert.ToString(formData["Address"]))) { Address = Convert.ToString(formData["Address"]); }
                       long total = 0;
                       var data = _customerBusiness.Search(page, pageSize, out total, Name, Address);
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
                   }
               }*/
    }
}
