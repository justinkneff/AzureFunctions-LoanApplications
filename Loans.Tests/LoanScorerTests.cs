using Xunit;
using Loans;

namespace Loans.Tests
{
    public class LoanScorerTests
    {
        [Theory]
        [InlineData(17)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void ShouldDeclineYoungerApplications(int age)
        {
            LoanScorer sut = new LoanScorer();

            LoanApplication application = new LoanApplication { Age = age };

            Assert.False(sut.LoanAccepted(application));
        }


        [Theory]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(int.MaxValue)]
        public void ShouldAcceptOlderApplications(int age)
        {
            LoanScorer sut = new LoanScorer();

            LoanApplication application = new LoanApplication { Age = age };

            Assert.True(sut.LoanAccepted(application));
        }
    }
}
