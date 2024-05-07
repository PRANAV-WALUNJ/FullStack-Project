using AutoMapper;
using Mango.Services.Coupon.API.Data;
using Mango.Services.Coupon.API.Interface;
using Mango.Services.Coupon.API.Models;
using Mango.Services.Coupon.API.Models.DTO;

namespace Mango.Services.Coupon.API.Repository
{
    public class MangoRepositoycs : IMango
    {
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        public MangoRepositoycs(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        public ResponseDto Create(CouponDto couponDto)
        {
            try
            {
                Coupons result = _mapper.Map<Coupons>(couponDto);
                _appDbContext.Add(result);
                _appDbContext.SaveChangesAsync();
                _response.Result = _mapper.Map<CouponDto>(result);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto DeleteById(int id)
        {
            try
            {
                var result = _appDbContext.coupons.First(x => x.CounponId == id);
                _appDbContext.coupons.Remove(result);
                _appDbContext.SaveChangesAsync();
                _response.Success = true;
                _response.Message = "Delete Sucessfully";
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupons> result = _appDbContext.coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(result);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto GetById(int id)
        {
            try
            {
                var result = _appDbContext.coupons.FirstOrDefault(x => x.CounponId == id);
                _response.Result = _mapper.Map<CouponDto>(result);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        public ResponseDto GetByIdCode(string code)
        {
            try
            {
                var result = _appDbContext.coupons.First(x => x.CounponCode == code);
                _response.Result = _mapper.Map<CouponDto>(result);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        public ResponseDto Update(CouponDto couponDto)
        {
            try
            {
                Coupons result = _mapper.Map<Coupons>(couponDto);
                _appDbContext.Update(result);
                _appDbContext.SaveChangesAsync();
                _response.Result = _mapper.Map<CouponDto>(result);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
