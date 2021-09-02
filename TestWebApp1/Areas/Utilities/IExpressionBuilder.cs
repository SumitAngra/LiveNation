using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestWebApp1.Models;

namespace TestWebApp1.Areas.Utilities
{
    public interface IExpressionBuilder<T>
    {
        Expression<Func<T, bool>> GenerateExpression(Rules rule);
    }
}
