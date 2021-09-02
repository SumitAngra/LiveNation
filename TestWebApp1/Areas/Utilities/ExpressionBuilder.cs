using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestWebApp1.Models;

namespace TestWebApp1.Areas.Utilities
{
    public class ExpressionBuilder<T>: IExpressionBuilder<T> where T:class
    {
        public Expression<Func<T, bool>> GenerateExpression(Rules rule)
        {
            if(!string.IsNullOrEmpty(rule.PropertyName) && !string.IsNullOrEmpty(rule.Operation) && !string.IsNullOrEmpty(rule.Value))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var leftExpression = Expression.Property(parameter, rule.PropertyName);
                List<int> Values = rule.Value.Split(',').Select(int.Parse).ToList();
                BinaryExpression expression = null;
                ConstantExpression compExpression = null;
                if (!string.IsNullOrEmpty(rule.ComparisonOperation) && !string.IsNullOrEmpty(rule.ComparisonValue))
                {
                    compExpression = Expression.Constant(Convert.ToInt32(rule.ComparisonValue), typeof(int));                  
                }
                
                foreach (var value in Values)
                {
                    var constantExpression = Expression.Constant(Convert.ToInt32(value), typeof(int));
                    if (Enum.TryParse(rule.Operation, out ExpressionType operation))
                    {
                        if(expression != null)
                        {
                            var tempExpression = Expression.MakeBinary(operation, leftExpression, constantExpression);
                            if (compExpression != null && rule.ComparisonOperation.Equals(ExpressionType.Equal.ToString()))
                            {
                                tempExpression = Expression.Equal(tempExpression, compExpression);
                            }
                            expression = Expression.AndAlso(expression, tempExpression);
                        }
                        else
                        {
                            expression = Expression.MakeBinary(operation, leftExpression, constantExpression);
                            if (compExpression != null && rule.ComparisonOperation.Equals(ExpressionType.Equal.ToString()))
                            {
                                expression = Expression.Equal(expression, compExpression);
                            }
                        }
                    }
                }
                return Expression.Lambda<Func<T, bool>>(expression, parameter);
            }
            return null;
        }
    }
}