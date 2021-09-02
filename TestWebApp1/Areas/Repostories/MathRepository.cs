using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using TestWebApp1.Areas.Utilities;
using TestWebApp1.Models;
using TestWebApp1.Models.Response;

namespace TestWebApp1.Areas.Repostories
{
    public class MathRepository : IMathRepository
    {
        private ISeries _series { get; }
        private IRulesRepository _rulesRepository { get; }

        private IExpressionBuilder<LiveNationInput> _expressionBuilder { get; }

        public MathRepository(ISeries series, IRulesRepository rulesRepository, IExpressionBuilder<LiveNationInput> expressionBuilder)
        {
            _series = series;
            _rulesRepository = rulesRepository;
            _expressionBuilder = expressionBuilder;
        }
        public BigInteger GetFiboNumber(int position, int divisor)
        {
            int length = 50;

            var series = _series.GetFiboseries(length);

            var number = _series.GetFiboNumber(series, position, divisor);

            return number;
        }

        public LiveNationResponse GetLiveNation(int startRange, int endRange)
        {
            LiveNationResponse response = new LiveNationResponse()
            {
                Result = string.Empty,
                Summary = new SummaryResponse()
            };

            if (startRange >= 1 && endRange > startRange)
            {
                var arrRange = Enumerable.Range(startRange, (endRange - startRange) + 1).ToArray();
                if (arrRange.Length > 0)
                {
                    var rules = _rulesRepository.GetRules();
                    Type summaryType = response.Summary.GetType();

                    foreach (var value in arrRange)
                    {
                        var output = string.Empty;
                        foreach (var rule in rules)
                        {
                            LiveNationInput liveNationInput = new LiveNationInput();
                            liveNationInput.Input = value;
                            var expression = _expressionBuilder.GenerateExpression(rule);
                            var result = ((LambdaExpression)expression).Compile().DynamicInvoke(liveNationInput);
                            if ((bool)result)
                            {
                                output = rule.Output;
                            }
                        }

                        if (!string.IsNullOrEmpty(output))
                        {
                            if (!string.IsNullOrEmpty(response.Result))
                            {
                                response.Result = response.Result + " " + output;
                            }
                            else
                            {
                                response.Result = output;
                            }
                            var summaryVal = (int)summaryType.GetProperty(output).GetValue(response.Summary, null) + 1;
                            summaryType.GetProperty(output).SetValue(response.Summary, summaryVal);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.Result))
                            {
                                response.Result = response.Result + " " + value.ToString();
                            }
                            else
                            {
                                response.Result = value.ToString();
                            }

                            response.Summary.Integer = response.Summary.Integer + 1;
                        }
                    }
                }
            }

            return response;
        }
    }
}