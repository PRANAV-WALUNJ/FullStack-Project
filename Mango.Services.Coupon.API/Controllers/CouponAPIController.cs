using Mango.Services.Coupon.API.Interface;
using Mango.Services.Coupon.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.Coupon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly IMango _mango;
        
        public CouponAPIController(IMango mango)
        {
           
            _mango = mango;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var result = _mango.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _mango.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/Code")]
        public IActionResult GetByIdCode(string code)
        {
            var result = _mango.GetByIdCode(code);
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CouponDto couponDto)
        {
            var result = _mango.Create(couponDto);
            return Ok(result);
        }


        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CouponDto couponDto)
        {
            var result = _mango.Update(couponDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public IActionResult DeleteById(int id)
        {

            var result = _mango.DeleteById(id);
            return Ok(result);
        }
    }
}
