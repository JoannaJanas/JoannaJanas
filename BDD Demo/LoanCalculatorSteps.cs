using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

//[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.ClassLevel)]
namespace BDD_Demo
{
    [Binding]
    public class LoanCalculatorSteps : BaseSteps
    {
        [BeforeFeature]
        public static void BeforeAppFeature()
        {
            SeleniumHelper.Browser = new ChromeDriver();
            //SeleniumHelper.WebDriver = new System.Threading.ThreadLocal<IWebDriver>(() => { return new ChromeDriver(); });
            SeleniumHelper.Browser.Manage().Window.Maximize();
        }

        [AfterFeature]
        public static void AfterAppFeature()
        {
            SeleniumHelper.Browser.Quit();
        }

        [Given(@"that the personal loan calculator page is open")]
        public void GivenThatThePersonalLoanCalculatorPageIsOpen()
        {
            SeleniumHelper.Browser.Navigate().GoToUrl("https://www.calculator.net/personal-loan-calculator.html");
        }

        [Given(@"that the auto loan calculator page is open")]
        public void GivenThatTheAutoLoanCalculatorPageIsOpen()
        {
            SeleniumHelper.Browser.Navigate().GoToUrl("https://www.calculator.net/auto-loan-calculator.html");
        }

        [When(@"I enter the down payment (.*)")]
        public void WhenIEnterTheDownPayment(string down)
        {
            CalculatorNet.AutoLoan.DownPayment.Clear();
            CalculatorNet.AutoLoan.DownPayment.SendKeys(down);
        }

        [When(@"I enter the trade in value (.*)")]
        public void WhenIEnterTheTradeInValue(string trade)
        {
            CalculatorNet.AutoLoan.TradeInValue.Clear();
            CalculatorNet.AutoLoan.TradeInValue.SendKeys(trade);
        }

        [When(@"I enter the loan amount (.*)")]
        public void WhenIEnterTheLoanAmount(string amount)
        {
            CalculatorNet.PersonalLoan.LoanAmount.Clear();
            CalculatorNet.PersonalLoan.LoanAmount.SendKeys(GetAmount(amount).ToString());
        }

        [When(@"I enter the interest rate (.*)")]
        public void WhenIEnterTheInterestRate(string rate)
        {
            CalculatorNet.PersonalLoan.InterestRate.Clear();
            CalculatorNet.PersonalLoan.InterestRate.SendKeys(GetRate(rate).ToString());
        }

        [When(@"I enter the insurance rate (.*)")]
        public void WhenIEnterTheInsuranceRate(string insurance)
        {
            CalculatorNet.PersonalLoan.Insurance.Clear();
            CalculatorNet.PersonalLoan.Insurance.SendKeys(insurance);
        }

        [When(@"I enter the loan term in years (.*)")]
        public void WhenIEnterTheLoanTermInYears(string years)
        {
            CalculatorNet.PersonalLoan.LoanTermYears.Clear();
            CalculatorNet.PersonalLoan.LoanTermYears.SendKeys(GetYear(years).ToString());
        }

        [When(@"I press the calculate button")]
        public void WhenIPressTheCalculateButton()
        {
            CalculatorNet.PersonalLoan.CalculateLoan();
        }
        
        [Then(@"the monthly pay is calculated (.*)")]
        public void ThenTheMonthlyPayIsCalculated(string pay)
        {
            var valueOfMonthlyPay = CalculatorNet.PersonalLoan.ReadMonthlyPay();
            Assert.IsTrue(valueOfMonthlyPay.Contains(pay));
        }

        [Then(@"the error message is displayed (.*)")]
        public void ThenTheErrorMessageIsDisplayed(string error)
        {
            var valueErrorMessage = CalculatorNet.PersonalLoan.ReadErrorMessage();
            Assert.IsTrue(valueErrorMessage.Contains(error));
        }

        [Then(@"the monthly pay for loan amount interest rate and loan term in years is calculated (.*) (.*) (.*)")]
        public void ThenTheMonthlyPayForLoanAmountInterestRateAndLoanTermInYearsIsCalculated(string amount, string rate, string years)
        {
            var pay = CalculateMonthlyPayment(GetAmount(amount), GetRate(rate) / 100 / 12, GetYear(years) * 12).ToString();
            var valueOfMonthlyPay = CalculatorNet.PersonalLoan.ReadMonthlyPay();
            Assert.IsTrue(valueOfMonthlyPay.Contains(pay));
        }

    }
}
