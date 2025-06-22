using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorHelpersTests
    {
        [Theory]
        [InlineData(1600, true)]
        [InlineData(1999, true)]
        [InlineData(2000, false)]
        public void IncomeLow_Test(int income, bool e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.IncomeLow(income));
        }

        [Theory]
        [InlineData(700, 0, true, "Eligible")]
        [InlineData(700, 2, false, "Review Manually")]
        [InlineData(650, 0, true, "Review Manually")]
        [InlineData(600, 0, false, "Not Eligible")]
        [InlineData(540, 1, true, "Not Eligible")]
        public void EvaluateCrediteScore_Test(int creditScore, int dependents, bool OwnHouse, string e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.EvaluateCrediteScore(creditScore, dependents, OwnHouse));
        }

        [Theory]
        [InlineData(0, "Eligible")]
        [InlineData(2, "Review Manually")]
        [InlineData(3, "Not Eligible")]
        public void EvaluateDepndents_Test(int dependents, string e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.EvaluateDependents(dependents));
        }

        [Theory]
        [InlineData(true, "Review Manually")]
        [InlineData(false, "Not Eligible")]
        public void ownHouse_Test(bool ownsHouse, string e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.OwnHouse(ownsHouse));
        }

        [Theory]
        [InlineData(750, 6000, true, true)]
        [InlineData(749, 6000, true, false)]
        public void EvaluateDontHasJob1_Test(int creditScore, int income, bool ownsHouse, bool e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.EvaluateDontHasJob1(creditScore, income, ownsHouse));
        }

        [Theory]
        [InlineData(650, 0, true)]
        [InlineData(649, 0, false)]
        [InlineData(700, 2, false)]
        public void EvaluateDontHasJob2_Test(int creditScore, int dependents, bool e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.EvaluateDontHasJob2(creditScore, dependents));
        }

        [Theory]
        [InlineData(750, 6000, true, 1, "Eligible")]
        [InlineData(660, 3000, false, 0, "Review Manually")]
        [InlineData(600, 4000, false, 2, "Not Eligible")]
        public void DontHaseJobWithHighIncome_Test(int creditScore, int income, bool ownsHouse, int dependents, string e)
        {
            Assert.Equal(e, LoanEvaluatorHelpers.DontHaseJobWithHighIncome(creditScore, income, ownsHouse, dependents));
        }
    }
}
