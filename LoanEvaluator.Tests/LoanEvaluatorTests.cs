// using Xunit;
// using LoanApp;
// namespace LoanApp.Tests
// {
//     public class LoanEvaluatorTests
//     {
//         [Fact]
//         public void GetLoanEligibility_Should_Return_NotEligible_When_Income_Low()
//         {
//             var evaluator = new LoanEvaluator();
//             var result = evaluator.GetLoanEligibility(1500, true, 800, 5, true);
//             Assert.Equal("Not Eligible", result);
//         }
//     }
// }

using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorTests
    {
        [Theory]
        [InlineData(1500, true, 800, 2, true, "Not Eligible")]
        [InlineData(3000, true, 750, 0, false, "Eligible")]
        [InlineData(3000, true, 750, 2, false, "Review Manually")]
        [InlineData(3000, true, 650, 1, true, "Review Manually")]
        [InlineData(3000, true, 650, 1, false, "Not Eligible")]
        [InlineData(6000, false, 760, 2, true, "Eligible")]
        [InlineData(3000, false, 660, 0, false, "Review Manually")]
        [InlineData(3000, false, 660, 1, false, "Not Eligible")]
        public void GetLoanEligibility_Should_ReturnExpectedResult(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse, string e)
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(income, hasJob, creditScore, dependents, ownsHouse);
            Assert.Equal(e, result);
        }
    }
}