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
    public class MonthlyRepaymentComaprisonShould
    {
        [Test]
        [Category("product Comparison")]
        [Category("xyxx")]
        public void respectValueEquality()
        {
            var a=new MonthlyRepaymentComparison("a",42.42m,22.22m);
            var b = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
            Assert.That(a, Is.EqualTo(b));
        }
        [Test]
        [Category("xyxx")]
        public void RespectValueInEquality()
        {
            var a = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
            var b = new MonthlyRepaymentComparison("a", 42.42m, 23.22m);
            Assert.That(a, Is.Not.EqualTo(b));
        }
    }
}
