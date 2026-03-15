using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Loans.Domain.Applications;
using NUnit.Framework.Constraints;

namespace Loans.Tests
{
    public class MonthlyRepaymentGreaterThaZeroConstraint : Constraint
    {
        public string ExpectedProductName { get; }
        public decimal ExpectedIntrestRate { get; }
        public MonthlyRepaymentGreaterThaZeroConstraint(string expectedproductName,decimal expectedintrestRate)
        {
            ExpectedProductName = expectedproductName;
            ExpectedIntrestRate = expectedintrestRate;
        }
        public override string Description => throw new NotImplementedException();

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
           MonthlyRepaymentComparison comparison=actual as MonthlyRepaymentComparison;
            if (comparison is null)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            }
            if(comparison.InterestRate==ExpectedIntrestRate && comparison.ProductName==ExpectedProductName
                && comparison.MonthlyRepayment>0)
            {
                return new ConstraintResult(this,actual, ConstraintStatus.Success);
            }
            return new ConstraintResult(this,actual,ConstraintStatus.Failure);
        }
    }
}
