using Demo_10_Testing.App.Exceptions;
using Demo_10_Testing.App.Services;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace Demo_10_Testing.UnitTest.Services
{
    public class CalculServiceTest
    {
        [Fact]
        public void Addition_TwoInteger_ReturnSumOfThem()
        {
            // Arrange
            CalculService calculService = new CalculService();
            long nb1 = 22;
            long nb2 = 20;
            long expected = 42;

            // Action
            long actual = calculService.Addition(nb1, nb2);

            // Assert
            // - Syntaxe classique
            Assert.Equal(expected, actual);
            // - Syntaxe FluentAssertions
            actual.Should().Be(expected);
        }

        [Fact]
        public void Addition_TwoInteger_ThrowExceptionOverFlow()
        {
            // Arrange
            CalculService calculService = new CalculService();
            long nb1 = long.MaxValue;
            long nb2 = 3;

            // Action + Assert
            CalculOverFlowException error = Assert.Throws<CalculOverFlowException>(() =>
            {
                calculService.Addition(nb1, nb2);
            });
        }
        [Fact]
        public void Addition_TwoInteger_ThrowExceptionOverFlow_CheckOperationType()
        {
            // Arrange
            CalculService calculService = new CalculService();
            long nb1 = long.MaxValue;
            long nb2 = 3;
            string expectedOperation = "Addition";

            // Action + Assert
            CalculOverFlowException error = Assert.Throws<CalculOverFlowException>(() =>
            {
                calculService.Addition(nb1, nb2);
            });
            string actualOperation = error.OperationType;
            
            actualOperation.Should().Be(expectedOperation);
        }
        [Fact]
        public void Addition_TwoInteger_ThrowExceptionOverFlow_CheckMessage()
        {
            // Arrange
            CalculService calculService = new CalculService();
            long nb1 = long.MaxValue;
            long nb2 = 3;
            Regex expectedErrorMessageRegex = new Regex("^Dépassement lors de l'addition de [0-9]+ et [0-9]+.$");
            
            // Action + Assert
            CalculOverFlowException error = Assert.Throws<CalculOverFlowException>(() =>
            {
                calculService.Addition(nb1, nb2);
            });
            string actualErrorMessage = error.Message;

            actualErrorMessage.Should().MatchRegex(expectedErrorMessageRegex);
            actualErrorMessage.Should().ContainAll([nb1.ToString(), nb2.ToString()]);
        }


        [Theory]
        [InlineData(0.5, 1.5, 2)]
        [InlineData(0.1, 0.2, 0.3)]
        [InlineData(9.99, 0.01, 10)]
        public void Addition_TwoReal_ReturnSumOhThem(double nb1, double nb2, double expected)
        {
            // Arrange 
            CalculService calculService = new CalculService();

            // Action
            double actual = calculService.Addition(nb1, nb2);

            // Assert
            actual.Should().Be(expected);
        }
       
        [Theory]
        [InlineData(0.0005, 1.111, 1.112)]
        [InlineData(0.0005, 2.222, 2.223)]
        [InlineData(0.0005, 3.333, 3.334)]
        [InlineData(0.0005, 4.444, 4.445)]
        [InlineData(0.0005, 5.555, 5.556)]
        public void Addition_TwoReal_CheckRouding(double nb1, double nb2, double expected)
        {
            // Par default l'arrondi utilise le « MidpointRounding » dependant de si le nombre est pair ou impaire !
            // Dans notre cas, on souhaite toujours arrondir vers le haut.

            // Arrange 
            CalculService calculService = new CalculService();

            // Action
            double actual = calculService.Addition(nb1, nb2);

            // Assert
            actual.Should().Be(expected);
        }


        public static IEnumerable<object[]> SoustractionTestValues => [
            [420, 13, 407, true,],
            [-420, 13, -437, false],
            [50, 8, 42, true],
            [-50, -8, -42, false],
        ];

        [Theory]
        [MemberData(nameof(SoustractionTestValues))]
        public void Soustraction_TwoInteger_ReturnDiffOfThem(long nb1, long nb2, long expectedResult, bool expectedSign)
        {
            // Arrange 
            CalculService calculService = new CalculService();

            // Action
            double actual = calculService.Soustraction(nb1, nb2);

            // Assert
            actual.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(SoustractionTestValues))]
        public void Soustraction_TwoInteger_ReturnDiffOfThem_CheckSign(long nb1, long nb2, long expectedResult, bool expectedSign)
        {
            // Arrange 
            CalculService calculService = new CalculService();

            // Action
            double actual = calculService.Soustraction(nb1, nb2);
            bool actualSign = actual > 0;

            // Assert
            actualSign.Should().Be(expectedSign);
        }
    }
}
