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
        [Route("get-notifi-id/{id}")]
        [HttpGet]
        public NotificationsModel GetDatabyID(int id)
        {
            return _notificationsBusiness.GetDatabyID(id);
        }
        [Route("create-notifi")]
        [HttpPost]
        public NotificationsModel CreateItem([FromBody] NotificationsModel model)
        {
            _notificationsBusiness.Create(model);
            return model;
        }
        [Route("update-notifi")]
        [HttpPost]
        public NotificationsModel UpdateItem([FromBody] NotificationsModel model)
        {
            _notificationsBusiness.Update(model);
            return model;
        }
        [Route("delete-notifi")]
        [HttpPost]
        public bool DeleteID(int id)
        {
            return _notificationsBusiness.Delete(id);
        }
        [Route("getAll-notifi")]
        [HttpPost]
        public IActionResult GetAll()
        {
            var dt = _notificationsBusiness.GetAll().Select(x => new { x.NotificationID, x.Title, x.Description, });
            return Ok(dt);
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
