﻿using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdersController : ControllerBase
    {
        private IOrdersBusiness _hoadonBusiness;

        public OdersController(IOrdersBusiness hoadonBusiness)
        {
            _hoadonBusiness = hoadonBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public OrderModel GetDatabyID(int id)
        {
            return _hoadonBusiness.GetDatabyID(id);
        }
        [Route("create-hoadon")]
        [HttpPost]
        public OrderModel CreateItem([FromBody] OrderModel model)
        {
            _hoadonBusiness.Create(model);
            return model;
        }
        [Route("update-hoadon")]
        [HttpPost]
        public OrderModel Update([FromBody] OrderModel model)
        {
            _hoadonBusiness.Update(model);
            return model;
        }
        [Route("ThongKe")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                DateTime? from_date = null;
                if (formData.Keys.Contains("from_date") && formData["from_date"] != null && formData["from_date"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["from_date"].ToString());
                    from_date = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_date = null;
                if (formData.Keys.Contains("to_date") && formData["to_date"] != null && formData["to_date"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_date"].ToString());
                    to_date = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _hoadonBusiness.Search(page, pageSize, out total, from_date, to_date);
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