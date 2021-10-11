
using OpenQA.Selenium;

namespace BDD_Demo.Pages
{
    public class AutoLoanPage : BaseLoanPage, ILoanPage
    {
        public By DownPayment
        {
            get
            {
                return By.Id("cdownpayment");
            }
        }

        public By TradeInValue
        {
            get
            {
                return By.Id("ctradeinvalue");
            }
        }

        public By SalesTax
        {
            get
            {
                return By.Id("csaletax");
            }
        }

        public By OtherFees
        {
            get
            {
                return By.Id("ctitlereg");
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
