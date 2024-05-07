using AutoMapper;
using Mango.Services.Coupon.API.Models;
using Mango.Services.Coupon.API.Models.DTO;

namespace Mango.Services.Coupon.API.Mapper
{
    public class MappingConfig
    {
        public static IMapper RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupons>();
                config.CreateMap<Coupons, CouponDto>();
            });

            // Create and return an IMapper instance using the configuration
            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
