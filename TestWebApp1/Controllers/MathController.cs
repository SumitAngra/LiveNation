using System;
using System.Numerics;
using System.Web.Http;
using TestWebApp1.Areas.Repostories;
using TestWebApp1.Areas.Utilities.Caching;
using TestWebApp1.Models.Response;

namespace TestWebApp1.Controllers
{
    [RoutePrefix("api/math")]
    public class MathController : ApiController
    {
        private IMathRepository _mathRepository { get; }

        public MathController(IMathRepository mathRepository)
        {
            _mathRepository = mathRepository;
        }

        [Route("Fibo/{position}/{divisor}")]
        [HttpGet]
        public BigInteger GetFiboNumber(int position, int divisor)
        {
            BigInteger response;
            try
            {
                response = _mathRepository.GetFiboNumber(position, divisor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reteriving fibo number.", ex.InnerException);
            }
            return response;
        }

        [CacheOutput(120,60,false)]
        [Route("LiveNation/{startRange}/{endRange}")]
        [HttpGet]
        public LiveNationResponse GetLiveNation(int startRange, int endRange)
        {
            LiveNationResponse response;
            try
            {
                response = _mathRepository.GetLiveNation(startRange, endRange);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reteriving Live Nation response.", ex.InnerException);
            }
            return response;
        }
    }
}