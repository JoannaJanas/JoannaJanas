namespace BDD_Demo.Pages
{
    public class CalculatorNet
    {
        public CalculatorNet()
        {
            PersonalLoan = new PersonalLoanPage();
            AutoLoan = new AutoLoanPage();
        }

        public PersonalLoanPage PersonalLoan { get; private set; }
        public AutoLoanPage AutoLoan { get; private set; }
    }
}
