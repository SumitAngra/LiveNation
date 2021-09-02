using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using TestWebApp1.Areas.Repostories;
using TestWebApp1.Controllers;
using TestWebApp1.Models.Response;
using Xunit;

namespace TestWebApp1UnitTest.Controllers
{
    public class MathControllerTest
    {
        private MathController mathController;
        private IMathRepository _mathRepository { get; }
        public MathControllerTest()
        {
            _mathRepository = Substitute.For<IMathRepository>();
            mathController = new MathController(_mathRepository);
        }

        [Fact]
        public void GetFiboNumber_Success()
        {
            //Arrange
            _mathRepository.GetFiboNumber(Arg.Any<int>(), Arg.Any<int>()).Returns(1);

            //Act
            var exception =  Record.Exception(() => mathController.GetFiboNumber(1, 1));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void GetFiboNumber_Fail()
        {
            //Arrange
            _mathRepository.GetFiboNumber(Arg.Any<int>(), Arg.Any<int>()).Throws(new Exception());

            //Act
            var exception = Record.Exception(() => mathController.GetFiboNumber(1, 1));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void GetLiveNation_Success()
        {
            //Arrange
            _mathRepository.GetLiveNation(Arg.Any<int>(), Arg.Any<int>()).Returns(new LiveNationResponse());

            //Act
            var exception = Record.Exception(() => mathController.GetLiveNation(1, 20));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void GetLiveNation_Fail()
        {
            //Arrange
            _mathRepository.GetLiveNation(Arg.Any<int>(), Arg.Any<int>()).Throws(new Exception());

            //Act
            var exception = Record.Exception(() => mathController.GetLiveNation(1, 20));

            //Assert
            Assert.NotNull(exception);
        }
    }
}
