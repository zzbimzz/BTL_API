using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private IGenresBusiness _genresBusiness;
        public GenresController(IGenresBusiness theloaiBusiness)
        {
            _genresBusiness = theloaiBusiness;
        }
        [Route("get-genre/{id}")]
        [HttpGet]
        public GenresModel GetDatabyID(int id)
        {
            return _genresBusiness.GetDatabyID(id);
        }
        [Route("create-genre")]
        [HttpPost]
        public GenresModel CreateItem([FromBody] GenresModel model)
        {
            _genresBusiness.Create(model);
            return model;
        }
        [Route("update-genre")]
        [HttpPost]
        public GenresModel UpdateItem([FromBody] GenresModel model)
        {
            _genresBusiness.Update(model);
            return model;
        }
        [Route("delete-genre")]
        [HttpPost]
        public bool DeleteID(int id)
        {
            return _genresBusiness.Delete(id);
        }
    }
}