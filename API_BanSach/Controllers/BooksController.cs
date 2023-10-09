using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksBusiness _bookBusiness;
        public BooksController(IBooksBusiness SachBusiness)
        {
            _bookBusiness = SachBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public BooksModel GetDatabyID(int id)
        {
            return _bookBusiness.GetDatabyID(id);
        }
        [Route("create-book")]
        [HttpPost]
        public BooksModel CreateItem([FromBody] BooksModel model)
        {
            _bookBusiness.Create(model);
            return model;
        }
        [Route("update-book")]
        [HttpPost]
        public BooksModel UpdateItem([FromBody] BooksModel model)
        {
            _bookBusiness.Update(model);
            return model;
        }
        [Route("delete-book")]
        [HttpPost]
        public bool DeleteID(int id)
        {
            return _bookBusiness.Delete(id);
        }
        /*[Route("search")]
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
