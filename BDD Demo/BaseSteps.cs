using BDD_Demo.Pages;
using OpenQA.Selenium;
using System;

namespace BDD_Demo
{
    public class BaseSteps
    {
        public BaseSteps()
        {
            CalculatorNet = new CalculatorNet();
        }

        protected CalculatorNet CalculatorNet { get; private set; }

        protected double CalculateMonthlyPayment(int loanAmount, double interestRate, int loanPeriod)
        {
            //P (r (1+r)^n) / ( (1+r)^n -1 )
            return Math.Round(loanAmount * (interestRate * Math.Pow((1 + interestRate), loanPeriod)) / (Math.Pow(1.0 + interestRate, loanPeriod) - 1), 2);
        }

        protected int GetYear(string type)
        {
            if (type == "valid")
            {
                return new Random(1).Next(1, 30);
            }

            if (type == "boundary")
            {
                return 1;
            }

            if (type == "invalid")
            {
                return -1;
            }

            return int.Parse(type);
        }

        protected double GetRate(string type)
        {
            if (type == "valid")
            {
                return new Random(1).NextDouble() + 0.01;
            }

            if (type == "boundary")
            {
                return 0.01;
            }

            if (type == "invalid")
            {
                return -1;
            }

            return double.Parse(type);
        }

        protected int GetAmount(string type)
        {
            if (type == "valid")
            {
                return new Random(1).Next(1000, 10000);
            }

            if (type == "boundary")
            {
                return 1;
            }

            if (type == "invalid")
            {
                return -1;
            }

            return int.Parse(type);
        }
    }
}
