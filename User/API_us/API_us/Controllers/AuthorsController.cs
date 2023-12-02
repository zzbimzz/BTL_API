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

        [Route("get-all")]
        [HttpGet]
        public List<AuthorsModel> GetAll()
        {
            return _authorsBusiness.GetAll();
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string AuthorName = "";
                if (formData.Keys.Contains("AuthorName") && !string.IsNullOrEmpty(Convert.ToString(formData["AuthorName"]))) { AuthorName = Convert.ToString(formData["AuthorName"]); }

                long total = 0;
                var data = _authorsBusiness.Search(page, pageSize, out total, AuthorName);
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
        }
    }
}
