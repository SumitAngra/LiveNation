using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TestWebApp1.Models.Response;

namespace TestWebApp1.Areas.Repostories
{
    public interface IMathRepository
    {
        BigInteger GetFiboNumber(int position, int divisor);
        LiveNationResponse GetLiveNation(int startRange, int endRange);
    }
}
