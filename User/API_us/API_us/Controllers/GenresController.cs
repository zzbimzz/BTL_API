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


        [Route("get-all")]
        [HttpGet]
        public List<GenresModel> GetAll()
        {
            return _genresBusiness.GetAll();
        }
    }
}