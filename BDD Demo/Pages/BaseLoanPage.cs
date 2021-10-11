using OpenQA.Selenium;

namespace BDD_Demo.Pages
{
    public class BaseLoanPage
    {
        public By LoanAmount
        { 
            get 
            { 
                return By.Id("cloanamount"); 
            } 
        }

        public By InterestRate
        {
            get
            {
                return By.Id("cinterestrate");
            }
        }

        public By CalculateButton
        {
            get
            {
                return By.XPath("//input[@value='Calculate']");
            }
        }

        public By MonthlyPay
        {
            get
            {
                return By.XPath("//h2[@class='h2result']");
            }
        }

        public By ErrorMessage
        {
            get
            {
                return By.XPath("//font[@color='red']");
            }
        }
    }
}
