using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDBContext _db;
        private IMapper _mapper;
        private ResponseDto _response;

        public CouponController(AppDBContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons;
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons);
                //IEnumerable<Coupon> Coupons = _db.Coupons;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Produces("application/xml")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon C = _db.Coupons.First(item => item.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(C);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message; 
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCouponCode/{code}")]
        public ResponseDto GetByCouponCode(string code)
        {
            try
            {
                Coupon C = _db.Coupons.First(item => item.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(C);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
