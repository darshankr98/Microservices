using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;

namespace Mango.Services.CouponAPI
{
    public class Mapping
    {
       public static MapperConfiguration RegisterMaps()
        {
            var config = new MapperConfiguration(cfg=>
                {
                    cfg.CreateMap<Coupon, CouponDto>();
                    cfg.CreateMap<CouponDto, Coupon>();
                }
            );
            return config;
        }
    }
}
