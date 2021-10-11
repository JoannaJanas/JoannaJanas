using OpenQA.Selenium;

namespace BDD_Demo.Pages
{
    public interface ILoanPage
    {
        void CalculateLoan();
        string ReadMonthlyPay();
        string ReadErrorMessage();
    }
}
