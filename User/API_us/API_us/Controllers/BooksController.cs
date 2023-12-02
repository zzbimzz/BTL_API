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
        public BookDetailsModel GetDatabyID(int id)
        {
            return _bookBusiness.GetDatabyID(id);
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string Title = "";
                if (formData.Keys.Contains("Title") && !string.IsNullOrEmpty(Convert.ToString(formData["Title"]))) { Title = Convert.ToString(formData["Title"]); }

                long total = 0;
                var data = _bookBusiness.Search(page, pageSize, out total, Title);
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

        [Route("get-all")]
        [HttpGet]
        public List<BooksModel> GetAll()
        {
            return _bookBusiness.GetAll();
        }
        [Route("get-by-genre")]
        [HttpGet]
        public List<GetByGenresBookModel> getGenresBook()
        {
            return _bookBusiness.getGenresBook();
        }

        [Route("get-bookHot")]
        [HttpGet]
        public List<BooksModel> GetByBookHot()
        {
            return _bookBusiness.GetByBookHot();
        }

    }
}
