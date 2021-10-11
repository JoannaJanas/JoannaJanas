using OpenQA.Selenium;

namespace BDD_Demo.Pages
{
    public class PersonalLoanPage : BaseLoanPage, ILoanPage
    {
        public By LoanTermYears
        {
            get
            {
                return By.Id("cyears");
            }
        }

        public By LoanTermMonths
        {
            get
            {
                return By.Id("cmonths");
            }
        }

        public By StartDateMonth
        {
            get
            {
                return By.Id("cstartmonth");
            }
        }

        public By StartDateYear
        {
            get
            {
                return By.Id("cstartyear");
            }
        }

        public By Insurance
        {
            get
            {
                return By.Id("cinsurance");
            }
        }

        public void CalculateLoan()
        {
            CalculateButton.Click();
        }

        public string ReadErrorMessage()
        {
            return SeleniumHelper.Browser.FindElement(ErrorMessage).Text;
        }

        public string ReadMonthlyPay()
        {
            return SeleniumHelper.Browser.FindElement(MonthlyPay).Text;
        }
    }
}
