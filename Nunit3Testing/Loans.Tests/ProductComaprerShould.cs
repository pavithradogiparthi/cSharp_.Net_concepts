using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    [ProductComparison]
    public class ProductComaprerShould
    {
        private List<LoanProduct> products;
        private ProductComparer sut;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            products = new List<LoanProduct>
            {
                new LoanProduct(1, "a", 1),
                new LoanProduct(2, "b", 2),
                new LoanProduct(3, "c", 3)

            };
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }
        [SetUp]
        public void Setup()
        {
            
            sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]

        public void ReturnCorrectNumberofComparisons()
        {
          
            List<MonthlyRepaymentComparison> comparisons
                = sut.CompareMonthlyRepayments(new LoanTerm(30));
            Assert.That(comparisons, Has.Exactly(3).Items);
        }

        [Test]
        public void ReturnCorrectNumberofComparisonss()
        {
           
            List<MonthlyRepaymentComparison> comparisons
                = sut.CompareMonthlyRepayments(new LoanTerm(30));
         
            Assert.That(comparisons, Is.Unique);
        }
        [Test]
        public void ReturnComparisonsForfirstProduct()
        {
           
            List<MonthlyRepaymentComparison> comparisons
                = sut.CompareMonthlyRepayments(new LoanTerm(30));
            var expectedproduct = new MonthlyRepaymentComparison("a", 1, 643.28m);
            Assert.That(comparisons, Does.Contain(expectedproduct));
        }
        [Test]
        public void ReturnComparisonsForFirstProduct_withPartialKnownExpectedValues()
        {
            List<MonthlyRepaymentComparison> comparisons
                = sut.CompareMonthlyRepayments(new LoanTerm(30));
            Assert.That(comparisons, Has.Exactly(1).Property("ProductName").
                EqualTo("a").And.Property("InterestRate").EqualTo(1));
            Assert.That(comparisons, Has.Exactly(1).Matches<MonthlyRepaymentComparison>(item => item.ProductName == "a"));
         Assert.That(comparisons,Has.Exactly(1).Matches(new MonthlyRepaymentGreaterThaZeroConstraint("a",1)));
        }
    }
}

