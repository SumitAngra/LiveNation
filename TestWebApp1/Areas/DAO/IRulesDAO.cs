using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp1.Models;

namespace TestWebApp1.Areas.DAO
{
    public interface IRulesDAO
    {
        List<Rules> GetRules();
    }
}
