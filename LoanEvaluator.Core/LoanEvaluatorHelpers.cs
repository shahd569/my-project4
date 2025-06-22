namespace LoanApp
{
    public class LoanEvaluatorHelpers
    {

        public static bool IncomeLow(int income) => income < 2000;

        public static string EvaluateCrediteScore(int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 700)
            {
                return EvaluateDependents(dependents);
            }
            else if (creditScore >= 600)
            {
                return OwnHouse(ownsHouse);
            }
            else
            {
                return "Not Eligible";
            }

        }

        public static string EvaluateDependents(int dependents)
        {
            if (dependents == 0)
                return "Eligible";
            else if (dependents <= 2)
                return "Review Manually";
            else
                return "Not Eligible";
        }

        public static string OwnHouse(bool ownsHouse)
        {
            return (ownsHouse) ? "Review Manually" : "Not Eligible";
        }

        public static string DontHaseJobWithHighIncome(int creditScore, int income, bool ownsHouse, int dependents)
        {
            if (EvaluateDontHasJob1(creditScore, income, ownsHouse))
                return "Eligible";
            else if (EvaluateDontHasJob2(creditScore, dependents))
                return "Review Manually";
            else
                return "Not Eligible";
        }
        public static bool EvaluateDontHasJob1(int creditScore, int income, bool ownsHouse) => creditScore >= 750 && income > 5000 && ownsHouse;
        public static bool EvaluateDontHasJob2(int creditScore, int dependents) => creditScore >= 650 && dependents == 0;

    }
}
