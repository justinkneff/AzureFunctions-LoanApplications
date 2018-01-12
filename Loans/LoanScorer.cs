namespace Loans
{
    public class LoanScorer
    {
        public bool LoanAccepted(LoanApplication application)
        {
            return application.Age >= 18;
        }
    }
}
