using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp1.Areas.Utilities
{
    public interface ISeries
    {
        BigInteger[] GetFiboseries(int length);
        BigInteger GetFiboNumber(BigInteger[] series, int position, int divisor);
    }
}
