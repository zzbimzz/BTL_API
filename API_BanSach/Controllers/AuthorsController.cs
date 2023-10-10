using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsBusiness _authorsBusiness;
        public AuthorsController(IAuthorsBusiness tacgiaBusiness)
        {
            _authorsBusiness = tacgiaBusiness;
        }
        [Route("get-author/{id}")]
        [HttpGet]
        public AuthorsModel GetDatabyID(int id)
        {
            return _authorsBusiness.GetDatabyID(id);
        }
        [Route("create-author")]
        [HttpPost]
        public AuthorsModel CreateItem([FromBody] AuthorsModel model)
        {
            _authorsBusiness.Create(model);
            return model;
        }
        [Route("update-author")]
        [HttpPost]
        public AuthorsModel UpdateItem([FromBody] AuthorsModel model)
        {
            _authorsBusiness.Update(model);
            return model;
        }
        [Route("delete-author")]
        [HttpPost]  
        public bool DeleteID(int id)
        {
            return _authorsBusiness.Delete(id);
        }
        [Route("get-all")]
        [HttpGet]
        public List<AuthorsModel> GetAll()
        {
            return _authorsBusiness.GetAll();
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
