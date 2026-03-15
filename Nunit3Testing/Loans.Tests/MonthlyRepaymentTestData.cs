using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Loans.Tests
{
    public  class MonthlyRepaymentTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(200_000, (decimal)6.5, 30, 1264.14m);
                yield return new TestCaseData(200_000, (decimal)10, 30, 1755.14m);
            }
        }
    }
}
