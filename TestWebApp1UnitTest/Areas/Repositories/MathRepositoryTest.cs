using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TestWebApp1.Areas.Repostories;
using TestWebApp1.Areas.Utilities;
using TestWebApp1.Models;
using Xunit;

namespace TestWebApp1UnitTest.Areas.Repositories
{
    public class MathRepositoryTest
    {
        private IMathRepository mathRepository;
        private ISeries _series { get; }

        private IRulesRepository _rulesRepository { get; }

        private IExpressionBuilder<LiveNationInput> _expressionBuilder { get; }

        public MathRepositoryTest()
        {
            _series = Substitute.For<ISeries>();
            _rulesRepository = Substitute.For<IRulesRepository>();
            _expressionBuilder = Substitute.For<IExpressionBuilder<LiveNationInput>>();

            mathRepository = new MathRepository(_series, _rulesRepository, _expressionBuilder);
        }

        [Fact]
        public void GetFiboNumber_Success()
        {
            //Arrange
            int length = 50;
            _series.GetFiboseries(Arg.Any<int>()).Returns(new BigInteger[length]);
            _series.GetFiboNumber(Arg.Any<BigInteger[]>(), Arg.Any<int>(), Arg.Any<int>()).Returns(1);

            //Act
            var exception = Record.Exception(() => mathRepository.GetFiboNumber(1, 1));

            //Assert
            Assert.Null(exception);
        }
    }
}
