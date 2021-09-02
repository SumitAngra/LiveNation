using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace TestWebApp1.Areas.Utilities
{
    public class Series : ISeries
    {
        public BigInteger[] GetFiboseries(int length)
        {
            BigInteger [] series = new BigInteger [length];
            if (length > 0)
            {
                BigInteger val = 0;
                for (int i = 0; i <= length - 1; i++)
                {                  
                    if(i>1)
                    {
                        val += series[i-2];
                    }
                    if(i==1)
                    {
                        val += 1;
                    }
                    series[i] = val;
                }
            }
            return series;
        } 

        public BigInteger GetFiboNumber(BigInteger[] series, int position, int divisor)
        {
            BigInteger val = 0;
            if (divisor > 0)
            {
                if (position > 0)
                {
                    var count = 0;
                    foreach (var item in series)
                    {   
                        if (item != 0 && (item%divisor == 0))
                        {
                            ++count;
                            if (count == position)
                            {
                                val = item;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Divisior should be greater than zero.");
            }
            return val;
        }
    }
}