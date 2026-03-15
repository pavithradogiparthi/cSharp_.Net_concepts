using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
public  class LoanRepaymentCalculatorShould
    {
        [Test]
        [TestCase(200_000,6.5,30,1264.14)]
        [TestCase(200_000,10,30,1755.14)]
        public void CalculateCorrectMonthlyRepayment(decimal principal,decimal intrestRate,
            int years,decimal  expectedmonthlyrepayment)
        {
            var sut=new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));
            Assert.That(monthlyPayment, Is.EqualTo(expectedmonthlyrepayment));
        }
        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        public decimal CalculateCorrectMonthlyRepayment_SimplifiedTestCase(decimal principal, decimal intrestRate,
            int years)
        {
            var sut = new LoanRepaymentCalculator();
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));
        }
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData),"TestCases")]
        public void CalculateCorrectMonthlyRepayment_Centralized(int principal, decimal intrestRate,
            int years, decimal expectedmonthlyrepayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));
            Assert.That(monthlyPayment, Is.EqualTo(expectedmonthlyrepayment));
        }
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn),"TestCases")]
        public decimal CalculateCorrectMonthlyRepayment_CentralizedWithReturn(decimal principal, decimal intrestRate,
           int years)
        {
            var sut = new LoanRepaymentCalculator();
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));
        }
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCases",new object[] {"Data.csv"})]
        public void CalculateCorrectMonthlyRepayment_Csv(decimal principal, decimal intrestRate,
           int years, decimal expectedmonthlyrepayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));
            Assert.That(monthlyPayment, Is.EqualTo(expectedmonthlyrepayment));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Combinatorial(
            [Values(100_000, 200_000, 500_000)] decimal principal,
           [Values(6.5, 10, 20)] decimal intrestRate,
           [Values(10, 20, 30)] int years
          )
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));

        }
        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyRepayment_Sequential(
    [Values(100_000, 200_000, 500_000)] decimal principal,
   [Values(6.5, 10, 20)] decimal intrestRate,
   [Values(10, 20, 30)] int years,
            [Values(1135.48,1930.04,8355.09)]decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }
        [Test]
        public void CalculateCorrectMonthlyRepayment_Range(
         [Range(50_000, 1_000_000, 500_000)] decimal principal,
        [Range(0.5, 20.00, 0.5)] decimal intrestRate,
        [Values(10, 20, 30)] int years
       )
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), intrestRate, new LoanTerm(years));

        }


    }
}
